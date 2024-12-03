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

        static void CalculateLoan()
        {
            Console.WriteLine("Podaj cenę samochodu oraz okres kredytowania.");

            Console.Write("Podaj cenę samochodu: ");
            double carPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Podaj okres kredytowania w miesiącach: ");
            int loanTerm = Convert.ToInt32(Console.ReadLine());

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

            double monthlyInterestRate = interestRate / 12;
            double loanAmount = carPrice;
            double monthlyPayment = (loanAmount * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -loanTerm));

            Console.WriteLine($"Dla ceny {carPrice} PLN i okresu {loanTerm} miesięcy, oprocentowanie wynosi {interestRate * 100}%.");
            Console.WriteLine($"Miesięczna rata kredytu wynosi: {Math.Round(monthlyPayment, 2)} PLN.");

            WaitForKeyPress();
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
}
