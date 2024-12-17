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
            initalizeCars();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Witaj! Wybierz jedną z opcji:");
                Console.WriteLine("1. Rejestracja użytkownika");
                Console.WriteLine("2. Obliczanie raty kredytu");
                Console.WriteLine("3. Przelicznik jednostek (kW <-> KM)");
                Console.WriteLine("4. Przelicznik km <-> mil");
                Console.WriteLine("5. Obliczenia związane z paliwem");
                Console.WriteLine("6. Wyświetlenie aut.");
                Console.WriteLine("7. Wyścig aut.");
                Console.WriteLine("8. Kalkulator E30");
                Console.WriteLine("9.Warsztat");
                Console.WriteLine("10. Przegląd");
                Console.WriteLine("11. Filtruj samochody");
                Console.WriteLine("10. Wyjście");
                Console.Write("Wybierz opcję (1-8): ");
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
                        ViewCars();
                        break;
                    case 7:
                        Race();
                        break;
                    case 8:
                        CalculateEthanolPercentage();
                        break;
                    case 9:
                        WorkshopMenu();
                        break;
                    case 10:
                        CalculateInspection();
                        break;
                    case 11:
                        FilterCars();
                        break; 
                    case 12:
                        return;
                    default:
                        Console.WriteLine("Niepoprawny wybór!");
                        break;
                }
            }
        }
        static void WorkshopMenu()
        {
            Console.WriteLine("Wybierz samochód do modyfikacji:");
            for (int i = 0; i < CarList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {CarList[i].GetType().Name} {CarList[i].Model}, Cena: {CarList[i].CarInfo.Price} PLN");
            }

            Console.Write("Podaj numer samochodu: ");
            int carIndex = int.Parse(Console.ReadLine()) - 1;

            if (carIndex < 0 || carIndex >= CarList.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór samochodu.");
                WaitForKeyPress();
                return;
            }

            Car selectedCar = CarList[carIndex];
            Console.WriteLine($"Wybrałeś: {selectedCar.GetType().Name} {selectedCar.Model}");

            Console.WriteLine("Wybierz modyfikację:");
            Console.WriteLine("1. Spoiler (Cena: 2000 PLN)");
            Console.WriteLine("2. Wydech sportowy (Cena: 3000 PLN)");
            Console.WriteLine("3. Folia ochronna (Cena: 1500 PLN)");
            Console.WriteLine("4. Powrót do menu");

            Console.Write("Twój wybór: ");
            int modChoice = int.Parse(Console.ReadLine());

            double modPrice = 0;
            string modName = "";

            switch (modChoice)
            {
                case 1:
                    modPrice = 2000;
                    modName = "Spoiler";
                    break;
                case 2:
                    modPrice = 3000;
                    modName = "Wydech sportowy";
                    break;
                case 3:
                    modPrice = 1500;
                    modName = "Folia ochronna";
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór modyfikacji.");
                    WaitForKeyPress();
                    return;
            }

            selectedCar.CarInfo.Price += modPrice;
            Console.WriteLine($"Dodano modyfikację: {modName}. Nowa cena samochodu: {selectedCar.CarInfo.Price} PLN");
            WaitForKeyPress();
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

        static void CalculateEthanolPercentage()
        {


            Console.Write("Podaj wielkość baku (w litrach): ");
            double bakSize = double.Parse(Console.ReadLine());

            Console.Write("Podaj ilość paliwa w baku (w litrach): ");
            double fuelInTank = double.Parse(Console.ReadLine());

            Console.Write("Podaj procentową ilość etanolu w paliwie (np. 10 dla 10%): ");
            double desiredEthanolPercentage = double.Parse(Console.ReadLine());


            double availableSpace = bakSize - fuelInTank;

            if (availableSpace <= 0)
            {
                Console.WriteLine("Bak jest już pełny lub podano niepoprawne dane.");
                return;
            }


            double ethanolToAdd = (desiredEthanolPercentage / 100) * availableSpace;
            double fuelToAdd = availableSpace - ethanolToAdd;


            Console.WriteLine($"Aby uzyskać {desiredEthanolPercentage}% etanolu w paliwie:");
            Console.WriteLine($"Dodaj {ethanolToAdd:F2} litrów etanolu.");
            Console.WriteLine($"Dodaj {fuelToAdd:F2} litrów paliwa.");

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
                        Console.WriteLine($"Cena naładowanie wynosi około: {Math.Round(priceElectric, 2)} zł, a naładowanie od zera zajmie około: {Math.Round(chargeTime, 3)} godzin.");
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

        static List<Car> CarList = new();
        static public void initalizeCars()
        {
            CarList.Add(new Seat(new CarInfo(2.0, "szary", 202, 240, 2020, "diesel", 139900, 9.0, 6.3, 1071), "Exeo"));
            CarList.Add(new Seat(new CarInfo(2.0, "szary", 202, 240, 2020, "diesel", 139900, 9.0, 6.3, 1071), "Tarraco"));
            CarList.Add(new Audi(new CarInfo(3.0, "czarny", 204, 253, 2018, "benzyna", 239900, 12.0, 8.1, 1200), "A5"));
            CarList.Add(new Audi(new CarInfo(3.0, "czarny", 245, 265, 2021, "benzyna", 269900, 11.5, 7.2, 1350), "A4"));
            CarList.Add(new Audi(new CarInfo(2.5, "srebrny", 185, 245, 2020, "diesel", 249900, 7.0, 5.9, 1250), "Q5"));
            CarList.Add(new Audi(new CarInfo(2.0, "biały", 190, 230, 2022, "benzyna", 279900, 9.0, 7.5, 1300), "Q7"));
            CarList.Add(new BMW(new CarInfo(2.0, "niebieski", 192, 250, 2019, "diesel", 219900, 8.5, 6.5, 1350), "X3"));
            CarList.Add(new BMW(new CarInfo(3.0, "czerwony", 300, 280, 2022, "benzyna", 399900, 12.5, 9.3, 1500), "M4"));
            CarList.Add(new BMW(new CarInfo(3.0, "czarny", 250, 260, 2021, "diesel", 269900, 9.5, 7.8, 1400), "X5"));
            CarList.Add(new Mercedes(new CarInfo(2.0, "złoty", 210, 250, 2020, "benzyna", 239900, 8.5, 6.2, 1320), "C-Class"));
            CarList.Add(new Mercedes(new CarInfo(3.0, "biały", 300, 270, 2022, "diesel", 359900, 10.0, 8.5, 1450), "E-Class"));
            CarList.Add(new Mercedes(new CarInfo(2.5, "czarny", 260, 260, 2021, "benzyna", 299900, 9.0, 7.0, 1400), "S-Class"));
            CarList.Add(new Volkswagen(new CarInfo(1.5, "zielony", 150, 200, 2020, "benzyna", 109900, 6.5, 5.8, 1150), "Golf"));
            CarList.Add(new Volkswagen(new CarInfo(2.0, "niebieski", 180, 220, 2022, "diesel", 139900, 7.5, 6.2, 1250), "Passat"));
            CarList.Add(new Volkswagen(new CarInfo(2.0, "srebrny", 150, 210, 2020, "diesel", 129900, 6.0, 5.5, 1200), "Tiguan"));
            CarList.Add(new Opel(new CarInfo(1.6, "czerwony", 120, 190, 2019, "benzyna", 87900, 6.5, 5.5, 1100), "Astra"));
            CarList.Add(new Opel(new CarInfo(2.0, "żółty", 170, 210, 2021, "diesel", 139900, 7.0, 6.0, 1200), "Insignia"));
            CarList.Add(new Fiat(new CarInfo(1.4, "błękitny", 100, 180, 2018, "benzyna", 67900, 7.0, 6.5, 1000), "Tipo"));
            CarList.Add(new Fiat(new CarInfo(1.6, "czarny", 130, 200, 2020, "diesel", 89900, 6.0, 5.3, 1100), "500X"));

        }
        
        static void FilterCars()
        {
            Console.WriteLine("Filtruj samochody po:");
            Console.WriteLine("1. Typ paliwa");
            Console.WriteLine("2. Kolor");
            Console.WriteLine("3. Przedział cenowy");
            Console.WriteLine("4. Moc silnika (KM)");
            Console.Write("Wybierz kryterium (1-4): ");

            int filterChoice = int.Parse(Console.ReadLine());
            List<Car> filteredCars = new List<Car>();

            switch (filterChoice)
            {
                case 1:
                    Console.Write("Podaj typ paliwa (benzyna/diesel/elektryczne): ");
                    string fuelType = Console.ReadLine().ToLower();
                    filteredCars = CarList.Where(car => car.CarInfo.FuelType.ToLower() == fuelType).ToList();
                    break;

                case 2:
                    Console.Write("Podaj kolor samochodu: ");
                    string color = Console.ReadLine().ToLower();
                    filteredCars = CarList.Where(car => car.CarInfo.Color.ToLower() == color).ToList();
                    break;

                case 3:
                    Console.Write("Podaj minimalną cenę (PLN): ");
                    double minPrice = double.Parse(Console.ReadLine());
                    Console.Write("Podaj maksymalną cenę (PLN): ");
                    double maxPrice = double.Parse(Console.ReadLine());
                    filteredCars = CarList.Where(car => car.CarInfo.Price >= minPrice && car.CarInfo.Price <= maxPrice).ToList();
                    break;

                case 4:
                    Console.Write("Podaj minimalną moc silnika (KM): ");
                    int minHorsePower = int.Parse(Console.ReadLine());
                    Console.Write("Podaj maksymalną moc silnika (KM): ");
                    int maxHorsePower = int.Parse(Console.ReadLine());
                    filteredCars = CarList.Where(car => car.CarInfo.HorsePower >= minHorsePower && car.CarInfo.HorsePower <= maxHorsePower).ToList();
                    break;

                default:
                    Console.WriteLine("Niepoprawny wybór!");
                    return;
            }

            if (filteredCars.Count == 0)
            {
                Console.WriteLine("Brak samochodów spełniających podane kryteria.");
            }
            else
            {
                Console.WriteLine("Znalezione samochody:");
                foreach (var car in filteredCars)
                {
                    Console.WriteLine($"Marka: {car.GetType().Name}, Model: {car.Model}, Cena: {car.CarInfo.Price} PLN");
                }
            }

            WaitForKeyPress();
        }

        static void CalculateInspection()
        {
            Console.WriteLine("Podaj przebieg samochodu (w km): ");
            int currentMileage = int.Parse(Console.ReadLine());
            const int inspectionInterval = 15000;

            int remainingMileage = inspectionInterval - (currentMileage % inspectionInterval);

            Console.WriteLine($"Pozostało {remainingMileage} km do kolejnego przeglądu technicznego.");
            WaitForKeyPress();
        }
        
        static void ViewCars()
        {
            foreach (var car in CarList)
            {
                Console.WriteLine($"Marka: {car.GetType().Name}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Rok produkcji: {car.CarInfo.Year}");
                Console.WriteLine($"Kolor: {car.CarInfo.Color}");
                Console.WriteLine($"Pojemność silnika: {car.CarInfo.EngineCapacity} L");
                Console.WriteLine($"Moc: {car.CarInfo.HorsePower} KM");
                Console.WriteLine($"Prędkość maksymalna: {car.CarInfo.MaxSpeed} km/h");
                Console.WriteLine($"Typ paliwa: {car.CarInfo.FuelType}");
                Console.WriteLine($"Cena: {car.CarInfo.Price} PLN");
                Console.WriteLine();
            }
            WaitForKeyPress();

        }
        static void Race()
        {
            Random random = new Random();


            int carIndex1 = random.Next(CarList.Count);
            int carIndex2 = random.Next(CarList.Count);


            while (carIndex1 == carIndex2)
            {
                carIndex2 = random.Next(CarList.Count);
            }

            var car1 = CarList[carIndex1];
            var car2 = CarList[carIndex2];


            Console.WriteLine("Rozpoczynamy wyścig!");
            Console.WriteLine($"Samochód 1: {car1.Model} z {car1.CarInfo.HorsePower} KM");
            Console.WriteLine($"Samochód 2: {car2.Model} z {car2.CarInfo.HorsePower} KM");


            if (car1.CarInfo.HorsePower > car2.CarInfo.HorsePower)
            {
                Console.WriteLine($"{car1.Model} wygrał wyścig!");
            }
            else if (car1.CarInfo.HorsePower < car2.CarInfo.HorsePower)
            {
                Console.WriteLine($"{car2.Model} wygrał wyścig!");
            }
            else
            {
                Console.WriteLine("Wyścig zakończył się remisem!");
            }


            WaitForKeyPress();
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

    public class CarInfo
    {
        public double EngineCapacity { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public int MaxSpeed { get; set; }
        public string FuelType { get; set; }
        public double Price { get; set; }
        public double CityFuelConsumption { get; set; }
        public double HighwayFuelConsumption { get; set; }
        public double Weight { get; set; }

        public CarInfo(double engineCapacity, string color, int horsePower, int maxSpeed, int year, string fuelType, double price, double cityFuelConsumption, double highwayFuelConsumption, double weight)
        {
            EngineCapacity = engineCapacity;
            Color = color;
            HorsePower = horsePower;
            MaxSpeed = maxSpeed;
            Year = year;
            FuelType = fuelType;
            Price = price;
            CityFuelConsumption = cityFuelConsumption;
            HighwayFuelConsumption = highwayFuelConsumption;
            Weight = weight;
        }
    }

    public class Car
    {
        public CarInfo CarInfo { get; set; }
        public string Model { get; set; }

        public Car(CarInfo carInfo, string model)
        {
            CarInfo = carInfo;
            Model = model;
        }
    }

    public class Seat : Car
    {
        public Seat(CarInfo carInfo, string model) : base(carInfo, model) { }
    }
    public class BMW : Car
    {
        public BMW(CarInfo carInfo, string model) : base(carInfo, model) { }
    }

    public class Audi : Car
    {
        public Audi(CarInfo carInfo, string model) : base(carInfo, model) { }
    }

    public class Mercedes : Car
    {
        public Mercedes(CarInfo carInfo, string model) : base(carInfo, model) { }
    }
    public class Opel : Car
    {
        public Opel(CarInfo carInfo, string model) : base(carInfo, model) { }
    }
    public class Volkswagen : Car
    {
        public Volkswagen(CarInfo carInfo, string model) : base(carInfo, model) { }
    }
    public class Fiat : Car
    {
        public Fiat(CarInfo carInfo, string model) : base(carInfo, model) { }
    }
}
