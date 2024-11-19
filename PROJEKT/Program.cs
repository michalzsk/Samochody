using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Drawing;
using System;
using System.Text;
using System.Dynamic;

namespace PROJEKT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

    }
    Seat Leon = new Seat(1.4, "czerwony", 203, 2017, "benzyna", 54900, 6.0, 4.0, 962);
    Volkswagen Passat = new Volkswagen(1.8, "czerwony", 220, 2016, "benzyna", 70900, 8.0, 7.0, 1119);
    Audi A4_Avant = new Audi(2.0, "biały", 204, 2021, "diesel", 118900, 5.8, 4.7, 1094);
    Audi Q5 = new Audi(2.0, "biały", 190, 218, 2017, "diesel", 70000, 4.0, 5.0, 785);
    Skoda Octavia = new Skoda(2.0, "czarny", 150, 227, 2018, "diesel", 70000, 4.0, 5.0, 818);
    Volkswagen GolfPlus = new Volkswagen(1.4, "szary", 80, 214, 2008, "benzyna", 17500, 8.7, 5.4, 846)
    Skoda RAPIDII = new Skoda(1.0, "niebieski", 110, 189, 2018, "benzyna", 45000, 5.5, 4.0, 1196);
    Volkswagen Scirocco = new Volkswagen(1.4, "niebieski", 150, 218, 2011, "benzyna", 40000, 8.0, 5.0, 833);
    Volkswagen TRoc = new Volkswagen(1.5, "czarny", 150, 207, 2019, "benzyna", 50000, 6.0, 4.0, 733);
    public class CarInfo(double enginecapacity, string color, int horsepower, int vmax,
        int year, string fueltype, double price, double fuelconsumptioncity,
        double fuelconsumptiontrip, int range)
    {
        double EngineCapacity = enginecapacity;
        string Color = color;
        int HorsePower = horsepower;
        int Vmax = vmax;
        int Year = year;
        string Fuel = fueltype;
        double Price = price;
        double FuelConsumptionCity = fuelconsumptioncity;
        double FuelConsumptionTrip = fuelconsumptiontrip;
        int Range = range;

    }
    public class Car(CarInfo cinfo)
    {
        CarInfo CarInfo = cinfo;
    }
    public class Volkswagen(CarInfo cinfo, string model) : Car(cinfo)
    {
        string Model = model;
    }
    public class Audi(CarInfo cinfo, string model) : Car(cinfo)
    {
        string Model = model;
    }
    public class Skoda(CarInfo cinfo, string model) : Car(cinfo)
    {
        string Model = model;
    }
    public class Seat(CarInfo cinfo, string model) : Car(cinfo)
    {
        string Model = model;
    }
    public class Porsche(CarInfo cinfo, string model) : Car(cinfo)
    {
        string Model = model;
    }
}
