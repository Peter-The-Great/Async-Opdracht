using Boeken;
namespace AsyncBoekOpdracht
{
    public class Program
    {
        static async Task VoegBoekToe()
        {
            Console.WriteLine("Geef de titel op: ");
            var titel = Console.ReadLine();
            Console.WriteLine("Geef de auteur op: ");
            var auteur = Console.ReadLine();
            Database.VoegToe(new Boek { Titel = titel, Auteur = auteur });
            Database.Logboek("Er is een nieuw boek!");
            Console.WriteLine("De huidige lijst met boeken is: ");
            foreach (var boek in await Database.HaalLijstOp())
            {
                Console.WriteLine(boek.Titel);
            }
        }
        static async Task ZoekBoek()
        {
            Console.WriteLine("Waar gaat het boek over?");
            var beschrijving = Console.ReadLine();
            Boek? beste = null;
            var boeken = await Database.HaalLijstOp();
            if (boeken != null && boeken.Count > 0)
            {
                beste = boeken[0]; // Initialiseren met eerste boek
                foreach (var boek in boeken)
                {
                    if (beste == null || boek.AIScore > beste.AIScore)
                        beste = boek;
                }
            }
            if (beste != null)
            {
                Console.WriteLine("Het boek dat het beste overeenkomt met de beschrijving is: ");
                Console.WriteLine(beste.Titel);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Er zijn geen boeken gevonden die overeenkomen met de beschrijving.");
            }
        }
        static bool Backupping = false;
        // "Backup" kan lang duren. We willen dat de gebruiker niet hoeft te wachten,
        // en direct daarna boeken kan toevoegen en zoeken.
        static async Task Backup()
        {
            if (Backupping)
                return;
            Backupping = true;
            await Willekeurig.Vertraging(2000, 3000);
            Backupping = false;
            Console.WriteLine("Backup is gemaakt.");
        }

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welkom bij de boeken administratie!");
            string? key = null;
            while (key != "q")
            {
                Console.WriteLine("+) Boek toevoegen");
                Console.WriteLine("z) Boek zoeken");
                Console.WriteLine("b) Backup maken van de boeken");
                Console.WriteLine("q) Quit");
                key = Console.ReadLine();
                if (key == "+")
                    await VoegBoekToe();
                else if (key == "z")
                    await ZoekBoek();
                else if (key == "b")
                    await Backup();
                else if (key == "q")
                    Console.WriteLine("Tot ziens!");
                else Console.WriteLine("Ongeldige invoer!");
            }
        }
    }
}