﻿namespace PROJEKT
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
