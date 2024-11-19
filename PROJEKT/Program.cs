namespace PROJEKT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public class Car(double enginecapacity, string suspension, string color, int horsepower, int vmax,
            int year, string fueltype, string brand, double price, double fuelconsumptioncity,
            double fuelconsumptiontrip, int range)
        {
            double EngineCapacity = enginecapacity;
            string Suspension = suspension;
            string Color = color;
            int HorsePower = horsepower;
            int Vmax = vmax;
            int Year = year;
            string Fuel = fueltype;
            string Brand = brand;
            double Price = price;
            double FuelConsumptionCity = fuelconsumptioncity;
            double FuelConsumptionTrip = fuelconsumptiontrip;
            int Range = range;

        }
    }
}
