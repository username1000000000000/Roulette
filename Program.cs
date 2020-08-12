using System;
using System.Linq;
using System.Collections.Generic;


namespace MyRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            //PLAYER CREATED 
            Console.WriteLine("Enter a username to get started: ");
            var username = Console.ReadLine();
            var user = new Player(username);
            Console.WriteLine($"Greetings {user.Username}... welcome to roulette");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"               Singles(1 number && number = 0) -> 35 to 1");
            Console.WriteLine($"               Singles(1 number && number is not 0) -> 17 to 1");
            Console.WriteLine($"               Singles(>1 number) -> 2 to 1");
            Console.WriteLine($"               Evens -> 1 to 1");
            Console.WriteLine($"               Odds -> 1 to 1");
            Console.WriteLine($"               Reds -> 1 to 1");
            Console.WriteLine($"               Blacks -> 1 to 1");
            Console.WriteLine("-------------------------------------------");
            var round = 1;
            Console.WriteLine($"You have {user.Balance}$ available");
            do
            {
                Console.WriteLine($"Round: {round}");

                //A) BETS ARE MADE 
                Console.WriteLine("Bet on single number(s)? If no, bet (0, 0.00)"); //SINGLE NUMBERS BET
                int[] numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                double[] betsArray = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                var betOne = BetLine.SingleNumbers(numbersArray, betsArray);
                Console.WriteLine("Bet on evens? (enter 'yes' to bet)"); //EVENS BET
                var betTwo = BetLine.EvensBet(Console.ReadLine());
                Console.WriteLine("Bet on odds? (enter 'yes' to bet)"); //ODDS BET
                var betThree = BetLine.OddsBet(Console.ReadLine());
                Console.WriteLine("Bet on reds? (enter 'yes' to bet)"); //REDS BET
                var betFour = BetLine.RedsBet(Console.ReadLine());
                Console.WriteLine("Bet on blacks? (enter 'yes' to bet)"); //BLACKS BET
                var betFive = BetLine.BlacksBet(Console.ReadLine());
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"Your total in bets for this round: {BetLine.BetsAmount}$");

                if (BetLine.BetsAmount <= user.Balance)
                {
                    //B) METHOD WILL RETURN A RANDOM ELEMENT 
                    var result = Wheel.DisplayWheel();
                    Console.WriteLine($"Winning slot: ({result.Key + ", " + result.Value})");

                    //C) BETS WILL BE EVALUATED TO RANDOM ELEMENT
                    foreach (KeyValuePair<int, double> item in betOne) //SINGLES BET EVALUATED
                    {
                        if (betOne.Keys.Count == 0)
                        {
                            Console.WriteLine("No values entered");
                        }
                        else if (betOne.Keys.Count == 1)
                        {
                            if (betOne[item.Key] == result.Key)
                            {
                                if (betOne[item.Key] == 0)
                                {
                                    user.Balance += item.Value * 35;
                                }
                                else if (betOne[item.Key] != 0 && betOne[item.Key] > 0)
                                {
                                    user.Balance += item.Value * 17;
                                }
                            }
                            else if (betOne[item.Key] != result.Key)
                            {
                                user.Balance -= item.Value;
                            }
                        }
                        else if (betOne.Keys.Count > 1)
                        {
                            if (betOne[item.Key] == result.Key)
                            {
                                user.Balance += item.Value * 2;
                            }
                            else if (betOne[item.Key] != result.Key)
                            {
                                user.Balance -= item.Value;
                            }
                        }
                    }
                    if (betTwo > 0 && result.Key % 2 == 0) //EVENS BET EVALUATED
                    {
                        user.Balance += betTwo;
                    }
                    else
                    {
                        user.Balance -= betTwo;
                    }
                    if (betThree > 0 && result.Key % 2 != 0) //ODDS BET EVALUATED
                    {
                        user.Balance += betThree;
                    }
                    else
                    {
                        user.Balance -= betThree;
                    }
                    if (betFour > 0 && result.Value == "Red") //ODDS BET EVALUATED
                    {
                        user.Balance += betFour;
                    }
                    else
                    {
                        user.Balance -= betFour;
                    }
                    if (betFive > 0 && result.Value == "Black") //ODDS BET EVALUATED
                    {
                        user.Balance += betFive;
                    }
                    else
                    {
                        user.Balance -= betFive;
                    }
                    round++;
                    BetLine.BetsCount.Clear();
                    Console.WriteLine($"You have {user.Balance}$ available");
                    Console.WriteLine("-------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Insuffient funds");
                }
           
            } while (user.Balance > 0.00); //D) WILL REPEAT IF BALANCE > 0
        }
    }
}
