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
    Seat Exeo = new Seat(1.8, "czarny", 217, 2009, "benzyna", 24999, 10.0, 6.0, 886);
    Seat Tarraco = new Seat(2.0, "szary", 202, 2020, "diesel", 139900, 9.0, 6.3, 1071);
    Porsche Cayenne = new Porsche(3.0, "czarny", 286, 2019,"benzyna", 238000, 11.0, 8.0, 658)
    Porsche Panamera = new Porsche(3.6, "granatowy", 288, 2012, "benzyna", 121900, 13.0, 7.0, 833);
    Porsche Macan_S = new Porsche(3.0, "czarny", 232, 2018, "benzyna", 153999, 11.0, 7.0, 609);
    Porsche Boxster718 = new Porsche(2.0, "szary", 293, 2018, "benzyna", 179900, 11.0, 6.0, 635);
    Seat Ibiza = new Seat(1.2, "czarny", 165, 2009, "benzyna", 13900, 7.6, 5.1, 763);
    Skoda Karoq = new Skoda(1.5, "czerwony", 210, 2017, "benzyna", 81900, 10.2, 6.4, 943);
    Skoda Superb = new Skoda(2.0, "srebrny", 225, 2023, "diesel", 157230, 8.3, 5.3, 1220);
    Audi A7 = new Audi(3.0, "czarny", 250, 2020, "diesel", 229000, 11.2, 6.9, 1086)
    Audi A5 = new Audi(3.0, "srebrny", 250, 2013, "diesel", 61500, 6.8, 5.1, 970);
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
