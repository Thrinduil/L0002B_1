using System;
using System.Collections.Generic;

namespace cashier
{
    class Cashier
    {
        static int GetPrice()
        {
            Console.Write("Ange pris: ");
            int price = Convert.ToInt32(Console.ReadLine());
            return price;
        }

        static int GetPayed()
        {
            Console.Write("Betalt: ");
            int payed = Convert.ToInt32(Console.ReadLine());
            return payed;
        }

        static void VerifyPayedGreaterThanPrice(int payed, int price)
        {
            if (payed < price)
            {
                Console.WriteLine("Fel: Kunden betalade för lite. Snåljåp.");
                Environment.Exit(1);
            }
        }

        static int GetBiggestDenomination(int value)
        {
            int[] denominatorsInSweden = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

            for (int i = 0; i < denominatorsInSweden.Length; i++)
            {
                if (denominatorsInSweden[i] - value <= 0)
                {
                    return denominatorsInSweden[i];
                }
            }
            return 0;
        }

        static List<int> GetDenominators(int change)
        {
            List<int> denominators = new List<int>();
            while (change > 0)
            {
                int denominator = GetBiggestDenomination(change);
                denominators.Add(denominator);
                change -= denominator;
            }
            return denominators;
        }

        static void PrintDenominators(List<int> denominators)
        {
            foreach (var denominator in denominators)
            {
                Console.WriteLine(denominator);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int price = GetPrice();
            int payed = GetPayed();

            VerifyPayedGreaterThanPrice(payed, price);

            int change = payed - price;

            List<int> denominators = GetDenominators(change);
            PrintDenominators(denominators);

            Console.ReadLine();
        }
    }
}
