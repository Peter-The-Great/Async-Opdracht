namespace Boeken
{
    public static class Willekeurig
    {
        public static Random Random = new Random();
        public static async Task Vertraging(int MinAantalMs = 500, int MaxAantalMs = 1000)
        {
            await Task.Delay(Random.Next(MinAantalMs, MaxAantalMs));
        }
    }
    public class Boek
    {
        public string? Titel { get; set; }
        public string? Auteur { get; set; }
        //Dit is de AI score van het boek. Hoe hoger de score, hoe beter het boek is.
        public float AIScore
        {
            get
            {
                // Deze 'berekening' is eigenlijk een ingewikkeld AI algoritme.
                // Pas de volgende vier regels niet aan.
                double ret = 1.0f;
                for (int i = 0; i < 10000000; i++)
                    for (int j = 0; j < 10; j++)
                        ret = (ret + Willekeurig.Random.NextDouble()) % 1.0;
                return (float)ret;
            }
        }
    }
    public static class Database
    {
        private static List<Boek> lijst = new List<Boek>();
        public static async void VoegToe(Boek b)
        {
            await Willekeurig.Vertraging(); // INSERT INTO ...
            lijst.Add(b);
        }
        public static async Task<List<Boek>> HaalLijstOp()
        {
            await Willekeurig.Vertraging(); // SELECT * FROM ...
            return lijst;
        }
        public static async void Logboek(string melding)
        {
            await Willekeurig.Vertraging(); // schrijf naar logbestand
        }
    }
}
