using System.Security.Cryptography.X509Certificates;

namespace PROJEKT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static void przelicznik()
        {
            Console.WriteLine("Witaj! Wybierz czy chcesz przeliczyć z kW na KM czy na odwrót.");
            Console.WriteLine("1. kW na KM");
            Console.WriteLine("2. KM na kW");
            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Console.WriteLine("Podaj moc w kW");
                    double kw = Convert.ToDouble(Console.ReadLine());
                    double km = kw * 1.36;
                    Console.WriteLine(kw + "kW w przeliczeniu na KM to: " + Math.Round(km, 2) + "KM");

                    break;

                case 2:
                    Console.WriteLine("Podaj moc w KM");
                    double km2 = Convert.ToDouble(Console.ReadLine());
                    double kw2 = km2 * 0.74;
                    Console.WriteLine(km2 + "KM w przeliczeniu na kW to: " + Math.Round(kw2, 2) + "kW");
                    break;


            }
        }
    }
}
