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
    public class CarInfo(double enginecapacity, string suspension, string color, int horsepower, int vmax,
        int year, string fueltype, double price, double fuelconsumptioncity,
        double fuelconsumptiontrip, int range)
    {
        double EngineCapacity = enginecapacity;
        string Suspension = suspension;
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
    public class BMW(CarInfo cinfo, string model) : Car(cinfo)
    {
        string Model = model;
    }

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
