using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PROJEKT
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Witaj! Wybierz jedną z opcji:");
                Console.WriteLine("1. Rejestracja użytkownika");
                Console.WriteLine("2. Obliczanie raty kredytu");
                Console.WriteLine("3. Przelicznik jednostek (kW <-> KM)");
                Console.WriteLine("4. Przelicznik km <-> mil");
                Console.WriteLine("5. Obliczenia związane z paliwem");
                Console.WriteLine("6. Wyjście");
                Console.Write("Wybierz opcję (1-6): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        CalculateLoan();
                        break;
                    case 3:
                        PowerUnitConverter();
                        break;
                    case 4:
                        KmMileConverter();
                        break;
                    case 5:
                        FuelCalculations();
                        break;
                    case 6:

                        return;
                    default:
                        Console.WriteLine("Niepoprawny wybór!");
                        break;
                }
            }
        }
        static void RegisterUser()
        {
            User user = new User();
            user.Register();
            if (user.IsRegistered)
            {
                user.Print();
            }
            else
            {
                Console.WriteLine("Nie udało się zarejestrować użytkownika. Spróbuj ponownie.");
            }

            WaitForKeyPress();
        }
        static void ViewCars()
        {

        }

        static void CalculateLoan()
        {
            Console.WriteLine("Podaj cenę samochodu oraz okres kredytowania.");

                Console.Write("Podaj cenę samochodu (PLN): ");
                double carPrice = Convert.ToDouble(Console.ReadLine());

                Console.Write("Podaj okres kredytowania w miesiącach: ");
                int loanTerm = Convert.ToInt32(Console.ReadLine());

                
                Console.Write("Podaj wysokość wkładu własnego (PLN): ");
                double downPayment = Convert.ToDouble(Console.ReadLine());

                
                Console.Write("Podaj swoją ocenę kredytową (0-10, gdzie 10 to najwyższa): ");
                double creditScore = Convert.ToDouble(Console.ReadLine());

                
                Console.Write("Czy chcesz dodać koszt ubezpieczenia do kredytu? (tak/nie): ");
                string insuranceInput = Console.ReadLine().ToLower();
                double insuranceCost = 0;

                if (insuranceInput == "tak")
                {
                    Console.Write("Podaj koszt ubezpieczenia rocznego (PLN): ");
                    insuranceCost = Convert.ToDouble(Console.ReadLine());
                }

               
                Console.Write("Czy są dodatkowe opłaty za kredyt? (tak/nie): ");
                string additionalFeesInput = Console.ReadLine().ToLower();
                double additionalFees = 0;

                if (additionalFeesInput == "tak")
                {
                    Console.Write("Podaj kwotę dodatkowych opłat (PLN): ");
                    additionalFees = Convert.ToDouble(Console.ReadLine());
                }

                
                double totalLoanAmount = carPrice - downPayment + insuranceCost + additionalFees;

                
                double interestRate = 0;

                if (loanTerm <= 6)
                {
                    interestRate = 0.02;
                }
                else if (loanTerm <= 12)
                {
                    interestRate = 0.04;
                }
                else if (loanTerm <= 24)
                {
                    interestRate = 0.06;
                }
                else
                {
                    interestRate = 0.10;
                }

                
                if (creditScore < 5)
                {
                    interestRate += 0.02;
                }
                else if (creditScore >= 8)
                {
                    interestRate -= 0.01; 
                }


    
                double monthlyInterestRate = interestRate / 12;
                double monthlyPayment = (totalLoanAmount * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -loanTerm));

                Console.WriteLine($"\nPodsumowanie:");
                Console.WriteLine($"Cena samochodu: {carPrice} PLN");
                Console.WriteLine($"Wkład własny: {downPayment} PLN");
                Console.WriteLine($"Okres kredytowania: {loanTerm} miesięcy");
                Console.WriteLine($"Ocena kredytowa: {creditScore}");
                Console.WriteLine($"Oprocentowanie roczne: {interestRate * 100}%");
                Console.WriteLine($"Kwota kredytu: {totalLoanAmount} PLN");
                Console.WriteLine($"Miesięczna rata kredytu wynosi: {Math.Round(monthlyPayment, 2)} PLN");
                Console.ReadKey();
        }

        static void PowerUnitConverter()
        {
            Console.WriteLine("Wybierz opcję przeliczenia:");
            Console.WriteLine("1. kW na KM");
            Console.WriteLine("2. KM na kW");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Podaj wartość w kW: ");
                    double kW = double.Parse(Console.ReadLine());
                    double horsepower = kW * 1.34102;
                    Console.WriteLine($"{kW} kW = {horsepower} KM");
                    break;
                case 2:
                    Console.Write("Podaj wartość w KM: ");
                    double kmPower = double.Parse(Console.ReadLine());
                    double kWValue = kmPower * 0.7457;
                    Console.WriteLine($"{kmPower} KM = {kWValue} kW");
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;
            }

            WaitForKeyPress();
        }

        static void KmMileConverter()
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1 - Przelicz km na mile");
            Console.WriteLine("2 - Przelicz mile na km");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Podaj liczbę kilometrów: ");
                double km = double.Parse(Console.ReadLine());
                double miles = KmToMiles(km);
                Console.WriteLine($"{km} kilometrów to {miles} mil.");
            }
            else if (choice == 2)
            {
                Console.Write("Podaj liczbę mil: ");
                double miles = double.Parse(Console.ReadLine());
                double km = MilesToKm(miles);
                Console.WriteLine($"{miles} mil to {km} kilometrów.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór!");
            }

            WaitForKeyPress();
        }

        static double KmToMiles(double km)
        {
            return Math.Round(km * 0.621371, 2);
        }

        static double MilesToKm(double miles)
        {
            return Math.Round(miles / 0.621371, 2);
        }

       static void FuelCalculations()
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Obliczanie zasięgu");
            Console.WriteLine("2. Cena zalania baku/załadowania");
            int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Podaj typ samochodu");
            Console.WriteLine("1.Spalinowy");
            Console.WriteLine("2.Elektryczne");
            int carTypeChoice = Convert.ToInt32(Console.ReadLine());
            switch (carTypeChoice)
            {
                case 1:
                    Console.Write("Podaj średnie spalanie auta w mieście (l/100km): ");
                    double cityFuelConsumption = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Podaj średnie spalanie na trasie (l/100km): ");
                    double highwayFuelConsumption = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Podaj pojemność baku w litrach: ");
                    int tankCapacity = Convert.ToInt32(Console.ReadLine());

                    double cityRange = (tankCapacity / cityFuelConsumption) * 100;
                    double highwayRange = (tankCapacity / highwayFuelConsumption) * 100;
                    Console.WriteLine($"Zasięg w mieście wynosi: {Math.Round(cityRange, 2)} km, a na trasie wynosi: {Math.Round(highwayRange, 2)} km.");
                break;
                case 2:
                    Console.Write("Podaj średnie zużycie energii auta w mieście (kWh/100km): ");
                    double cityElectricityConsumption = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Podaj średnie zużycie energii na trasie (kWh/100km): ");
                    double highwayElectricityConsumption = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Podaj pojemność akumulatora w kWh: ");
                    int batteryCapacity = Convert.ToInt32(Console.ReadLine());

                    double cityRangeElectric = (batteryCapacity / cityElectricityConsumption) * 100;
                    double highwayRangeElectric = (batteryCapacity / highwayElectricityConsumption) * 100;
                    Console.WriteLine($"Zasięg w mieście wynosi: {Math.Round(cityRangeElectric, 2)} km, a na trasie wynosi: {Math.Round(highwayRangeElectric, 2)} km.");
                break;
            }
            
            break;

        case 2:
            Console.Write("Podaj typ paliwa (benzyna/diesel/elektryczne): ");
            string fuelType = Console.ReadLine().ToLower();
            

            if (fuelType == "benzyna")
            {
                Console.Write("Podaj pojemność baku w litrach: ");
                int fuelTank = Convert.ToInt32(Console.ReadLine());
                double price95 = fuelTank * 6.07;
                double price98 = fuelTank * 6.75;
                Console.WriteLine($"Cena za benzyne 95 wynosi: {Math.Round(price95, 2)} zł, a 98 wynosi: {Math.Round(price98, 2)} zł.");
            }
            else if (fuelType == "diesel")
            {
                Console.Write("Podaj pojemność baku w litrach: ");
                int fuelTank = Convert.ToInt32(Console.ReadLine());
                double priceDiesel = fuelTank * 6.12;
                double priceDieselPlus = fuelTank * 6.34;
                Console.WriteLine($"Cena za ON wynosi: {Math.Round(priceDiesel, 2)} zł, a ON+ wynosi: {Math.Round(priceDieselPlus, 2)} zł.");
            }
            else if (fuelType == "elektryczne")
            {
                Console.Write("Podaj pojemność akumulatora w kWh: ");
                int fuelTank = Convert.ToInt32(Console.ReadLine());
                double priceElectric = fuelTank * 2;
                Console.Write("Podaj szybkość ładowarki");
                double chargerSpeed = Convert.ToDouble(Console.ReadLine());
                double chargeTime = fuelTank / chargerSpeed;
                Console.WriteLine($"Cena naładowanie wynosi około: {Math.Round(priceElectric, 2)} zł, a naładowanie od zera zajmie około: {Math.Round(chargeTime,3)} godzin.");
            }
            else
            {
                Console.WriteLine("Niepoprawny typ paliwa.");
            }
            break;

        default:
            Console.WriteLine("Niepoprawny wybór.");
            break;
    }

    WaitForKeyPress();
}

        static void WaitForKeyPress()
        {
            Console.WriteLine("Naciśnij spację, aby powrócić do menu lub Esc, aby zakończyć program.");
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Spacebar)
                {
                    return;
                }
                else if (key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
        static public void initalizeCars()
        {
            Seat Exeo = new Seat(new CarInfo(2.0, "szary", 202, 240, 2020, "diesel", 139900, 9.0, 6.3, 1071), "Exeo");
            Seat Tarraco = new Seat(new CarInfo(2.0, "szary", 202,240, 2020, "diesel", 139900, 9.0, 6.3, 1071),"Tarraco");
            Porsche Cayenne = new Porsche(new CarInfo(3.0, "czarny", 286, 420,2019, "benzyna", 238000, 11.0, 8.0, 658),"Cayenne ");
            Porsche Panamera = new Porsche(new CarInfo(3.6, "granatowy", 288, 420,2012, "benzyna", 121900, 13.0, 7.0, 833),"Panamera ");
            Porsche Macan_S = new Porsche(new CarInfo(3.0, "czarny", 232, 420,2018, "benzyna", 153999, 11.0, 7.0, 609),"Macan_S ");
            Porsche Boxster718 = new Porsche(new CarInfo(2.0, "szary", 293, 420,2018, "benzyna", 179900, 11.0, 6.0, 635),"Boxster718 ");
            Seat Ibiza = new Seat(new CarInfo(1.2, "czarny", 165, 420,2009, "benzyna", 13900, 7.6, 5.1, 763),"Ibiza ");
            Skoda Karoq = new Skoda(new CarInfo(1.5, "czerwony", 210, 420,2017, "benzyna", 81900, 10.2, 6.4, 943),"Karoq ");
            Skoda Superb = new Skoda(new CarInfo(2.0, "srebrny", 225, 420,2023, "diesel", 157230, 8.3, 5.3, 1220),"Superb ");
            Audi A7 = new Audi(new CarInfo(3.0, "czarny", 250, 420,2020, "diesel", 229000, 11.2, 6.9, 1086),"A7 ");
            Audi A5 = new Audi(new CarInfo(3.0, "srebrny", 250, 420,2013, "diesel", 61500, 6.8, 5.1, 970),"A5 ");
            Seat Leon = new Seat(new CarInfo(1.4, "czerwony", 203, 420,2017, "benzyna", 54900, 6.0, 4.0, 962),"Leon ");
            Volkswagen Passat = new Volkswagen(new CarInfo(1.8, "czerwony", 220, 420,2016, "benzyna", 70900, 8.0, 7.0, 1119),"Passat ");
            Audi A4_Avant = new Audi(new CarInfo(2.0, "biały", 204, 420,2021, "diesel", 118900, 5.8, 4.7, 1094),"A4_Avant ");
            Audi Q5 = new Audi(new CarInfo(2.0, "biały", 190, 420, 2017, "diesel", 70000, 4.0, 5.0, 785),"Q5 ");
            Skoda Octavia = new Skoda(new CarInfo(2.0, "czarny", 150, 420, 2018, "diesel", 70000, 4.0, 5.0, 818),"Octavia ");
            Volkswagen GolfPlus = new Volkswagen(new CarInfo(1.4, "szary", 80, 420, 2008, "benzyna", 17500, 8.7, 5.4, 846),"GolfPlus ");
            Skoda RAPIDII = new Skoda(new CarInfo(1.0, "niebieski", 110, 420, 2018, "benzyna", 45000, 5.5, 4.0, 1196),"RAPIDII ");
            Volkswagen Scirocco = new Volkswagen(new CarInfo(1.4, "niebieski", 150, 420, 2011, "benzyna", 40000, 8.0, 5.0, 833),"Scirocco ");
            Volkswagen TRoc = new Volkswagen(new CarInfo(1.5, "czarny", 150, 420,2019, "benzyna", 50000, 6.0, 4.0, 733), "TRoc ");
        }
    }


    class User
    {
        public bool IsRegistered = false;
        private string Email;
        private string Password;
        private byte[] Salt;

        public void Print()
        {
            Console.WriteLine("Rejestracja zakończona pomyślnie.");
            Console.WriteLine($"Email: {Email}");
        }

        public void Register()
        {
            string password;
            while (true)
            {
                Console.WriteLine("Podaj email:");
                Email = Console.ReadLine();
                if (IsEmailCorrect(Email)) break;
                Console.WriteLine("Niepoprawny email.");
            }

            while (true)
            {
                Console.WriteLine("Podaj hasło (min. 8 znaków, zawierać ma dużą literę, cyfrę i znak specjalny):");
                password = Console.ReadLine();
                if (password.Length >= 8 && HasSpecialChars(password) && HasUpperCase(password) && HasNumber(password)) break;
                Console.WriteLine("Hasło nie spełnia wymagań.");
            }

            Salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(Salt);
            }
            Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                Salt,
                KeyDerivationPrf.HMACSHA256,
                10000,
                256 / 8));

            IsRegistered = true;
        }

        private bool IsEmailCorrect(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool HasSpecialChars(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private bool HasUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool HasNumber(string password)
        {
            return password.Any(char.IsDigit);
        }
    }

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