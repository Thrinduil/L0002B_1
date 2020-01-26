using System;
using System.Collections.Generic;
using System.Linq;

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

        static void PrintDenominator(string value, int quantity, bool coin)
        {
            string moneyTypeSingular;
            string moneyTypePlural;

            if (coin)
            {
                moneyTypeSingular = "krona";
                moneyTypePlural = "kronor";
            } else
            {
                moneyTypeSingular = "lapp";
                moneyTypePlural = "lappar";
            }

            if (quantity == 1)
            {
                Console.WriteLine("{0} {1}{2}", quantity, value, moneyTypeSingular);
            } else if (quantity > 1)
            {
                Console.WriteLine("{0} {1}{2}", quantity, value, moneyTypePlural);
            }
        }

        static void Main(string[] args)
        {
            int price = GetPrice();
            int payed = GetPayed();

            VerifyPayedGreaterThanPrice(payed, price);

            int change = payed - price;

            List<int> denominators = GetDenominators(change);

            int thousands = denominators.Where(item => item == 1000).Count();
            int fivehundreds = denominators.Where(item => item == 500).Count();
            int twohundreds = denominators.Where(item => item == 200).Count();
            int onehundreds = denominators.Where(item => item == 100).Count();
            int fifties = denominators.Where(item => item == 50).Count();
            int twenties = denominators.Where(item => item == 20).Count();
            int tens = denominators.Where(item => item == 10).Count();
            int fives = denominators.Where(item => item == 5).Count();
            int twoes = denominators.Where(item => item == 2).Count();
            int ones = denominators.Where(item => item == 1).Count();

            Console.WriteLine("Växel tillbaka:");
            PrintDenominator("tusen", thousands, false);
            PrintDenominator("femhundra", fivehundreds, false);
            PrintDenominator("tvåhundra", twohundreds, false);
            PrintDenominator("hundra", onehundreds, false);
            PrintDenominator("femtio", fifties, false);
            PrintDenominator("tjugo", twenties, false);
            PrintDenominator("tio", tens, true);
            PrintDenominator("fem", fives, true);
            PrintDenominator("två", twoes, true);
            PrintDenominator("en", ones, true);

            Console.ReadLine();
        }
    }
}
