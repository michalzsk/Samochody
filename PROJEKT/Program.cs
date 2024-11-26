<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
=======
﻿using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Drawing;
using System;
using System.Text;
using System.Dynamic;
>>>>>>> 59249132471343a43b5353ddb47e60ed179315d1

namespace PROJEKT
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            User user = new User();
            user.Register();
            if (user.IsRegistered == true)
            {
                user.Print();
            }
            else {
                Console.WriteLine("Could not register user, try again");
            }
        }
        }
    }
    class User
    {
        public bool IsRegistered = false;
        private string Email;
        private string Password;
        protected byte[] Salt;
        public bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !char.IsLetterOrDigit(ch));
        }
        public bool HasUpperCase(string yourString)
        {
            return yourString.Any(ch => char.IsUpper(ch));
        }
        public bool HasNumber(string yourString)
        {
            return yourString.Any(ch => char.IsNumber(ch));
        }
        public bool IsEmailCorrect(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Print()
        {
            Console.WriteLine($" Email:{this.Email}\n Password:{this.Password}\n Hash:{Convert.ToBase64String(this.Salt)}");
        }
        public void Register()
        {
            string email = Console.ReadLine();
            string password = Console.ReadLine();
            string password2 = Console.ReadLine();
            if (email != null && password != null && password == password2 && IsEmailCorrect(email))
            {
                if (password.Length > 7 && HasSpecialChars(password) && HasUpperCase(password))
                {
                    byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: password!,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));
                    this.Email = email;
                    this.Password = hashed;
                    this.Salt = salt;
                    this.IsRegistered = true;
                    Console.WriteLine("Zarejestrowano pomyślnie");
                }
                else
                {
                    Console.WriteLine("Password must contain atleast 8 characters, 1 special character ,1 uppercase character and 1 number");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawne dane");
            }
=======
            Console.WriteLine("Witaj! Podaj cenę samochodu oraz okres, na który chcesz wziąć raty.");

            Console.Write("Podaj cenę samochodu: ");
            double cenaSamochodu = Convert.ToDouble(Console.ReadLine());

            Console.Write("Podaj okres kredytowania w miesiącach: ");
            int okresKredytowania = Convert.ToInt32(Console.ReadLine());

            
            double oprocentowanie = 0;

            if (okresKredytowania <= 6)
            {
                oprocentowanie = 0.02;  
            }
            else if (okresKredytowania <= 12)
            {
                oprocentowanie = 0.04;  
            }
            else if (okresKredytowania <= 24)
            {
                oprocentowanie = 0.06;  
            }
            else
            {
                oprocentowanie = 0.10;  
            }

            
            double miesięczneOprocentowanie = oprocentowanie / 12;

            double kwotaPożyczki = cenaSamochodu;
            double rata = (kwotaPożyczki * miesięczneOprocentowanie) / (1 - Math.Pow(1 + miesięczneOprocentowanie, -okresKredytowania));

            Console.WriteLine($"Dla ceny {cenaSamochodu} PLN i okresu {okresKredytowania} miesięcy, oprocentowanie wynosi {oprocentowanie * 100}%.");
            Console.WriteLine($"Miesięczna rata kredytu wynosi: {Math.Round(rata,2)} PLN.");
>>>>>>> 59249132471343a43b5353ddb47e60ed179315d1
        }

    }
    // public class CarInfo(double enginecapacity, string suspension, string color, int horsepower, int vmax,
    //     int year, string fueltype, double price, double fuelconsumptioncity,
    //     double fuelconsumptiontrip, int range)
    // {
    //     double EngineCapacity = enginecapacity;
    //     string Suspension = suspension;
    //     string Color = color;
    //     int HorsePower = horsepower;
    //     int Vmax = vmax;
    //     int Year = year;
    //     string Fuel = fueltype;
    //     double Price = price;
    //     double FuelConsumptionCity = fuelconsumptioncity;
    //     double FuelConsumptionTrip = fuelconsumptiontrip;
    //     int Range = range;

    // }
    // public class Car(CarInfo cinfo)
    // {
    //     CarInfo CarInfo = cinfo;
    // }
    // public class BMW(CarInfo cinfo, string model) : Car(cinfo)
    // {
    //     string Model = model;
    // }

    static void przelicznik()
{
    Console.WriteLine("Wybierz opcję przeliczenia:");
    Console.WriteLine("1. kW na KM");
    Console.WriteLine("2. KM na kW");
    int opcja = int.Parse(Console.ReadLine());

    switch (opcja)
    {
        case 1:
            Console.Write("Podaj wartość w kW: ");
            double kW = double.Parse(Console.ReadLine());
            double KM = kW * 1.34102;
            Console.WriteLine($"{kW} kW = {KM} KM");
            break;

        case 2:
            Console.Write("Podaj wartość w KM: ");
            double KM2 = double.Parse(Console.ReadLine());
            double kW2 = KM2 * 0.7457;
            Console.WriteLine($"{KM2} KM = {kW2} kW");
            break;
    } 
        
}
static void przlicznik_km_mil(){  

    Console.WriteLine("Witaj! W tym programie możesz w prosty sposób przeliczyć kilometry na mile i na odwrót!");
    Console.WriteLine("Wybierz opcję:");
    Console.WriteLine("1 - Przelicz km na mile");
    Console.WriteLine("2 - Przelicz mile na km");

    
    int wybor = int.Parse(Console.ReadLine());

    if (wybor == 1)
    {
        
        Console.WriteLine("Podaj liczbę kilometrów:");
        double km = double.Parse(Console.ReadLine());
        double mile = KmNaMile(km);
        Console.WriteLine($"{km} kilometrów to {mile} mil.");
    }
    else if (wybor == 2)
    {
        
        Console.WriteLine("Podaj liczbę mil:");
        double mile = double.Parse(Console.ReadLine());
        double km = MileNaKm(mile);
        Console.WriteLine($"{mile} mil to {km} kilometrów.");
    }
    else
    {
        Console.WriteLine("Niepoprawny wybór!");
        
    }
}
static double KmNaMile(double km)
{
    return Math.Round(km * 0.621371,2); 
}           
static double MileNaKm(double mile)
{
    return Math.Round(mile / 0.621371,2); 
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
