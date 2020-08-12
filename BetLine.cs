using System;
using System.Linq;
using System.Collections.Generic;

namespace MyRoulette
{
    public static class BetLine
    {
        public static List<double> BetsCount = new List<double>();
        public static double BetsAmount //RETURNS TOTAL BETS AMOUNT FROM ROUND 
        {
            get
            {
                return BetsCount.Sum();
            }
        }
        public static Dictionary<int, double> SingleNumbers(int[] numbers, double[] betAmounts)
        {
            var betsDictionary = new Dictionary<int, double>();
            if (numbers.Length != 0)
            {
                
                Console.WriteLine("Enter your bets");
                if (numbers.Length == betAmounts.Length)
                {
                    for (var i = 0; i < numbers.Length; i++)
                    {
                        betsDictionary[numbers[i]] = betAmounts[i];
                        BetsCount.Add(betAmounts[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Bets were not exhausted");
                }
            }
            else
            {
               
            } 
         

            return betsDictionary;
        }
        public static double BlacksBet(string input)
        {
            double bet = 0.00;
            if (input == "yes")
            {
                Console.WriteLine("Enter your bet: ");
                bet = double.Parse(Console.ReadLine());
                BetsCount.Add(bet);
            }
            return bet;
        }
        public static double RedsBet(string input)
        {
            double bet = 0.00;
            if (input == "yes")
            {
                Console.WriteLine("Enter your bet: ");
                bet = double.Parse(Console.ReadLine());
                
            }
            BetsCount.Add(bet);
            return bet;
        }
        public static double EvensBet(string input)
        {
            double bet = 0.00;
            if (input == "yes")
            {
                Console.WriteLine("Enter your bet: ");
                bet = double.Parse(Console.ReadLine());
            }
            BetsCount.Add(bet);
            return bet;
        }
        public static double OddsBet(string input)
        {
            double bet = 0.00;
            if (input == "yes")
            {
                Console.WriteLine("Enter your bet: ");
                bet = double.Parse(Console.ReadLine());
                BetsCount.Add(bet);
            }
            return bet;
        }
    }
}
