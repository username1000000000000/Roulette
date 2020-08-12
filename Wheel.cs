using System;
using System.Linq;
using System.Collections.Generic;

namespace MyRoulette
{
    public static class Wheel
    {
        public static KeyValuePair<int, object> DisplayWheel()
        {
            int[] WheelNumbers = Enumerable.Range(0, 36).ToArray();
            Dictionary<int, object> RouletteWheel = new Dictionary<int, object>();

            foreach(var number in WheelNumbers)
            {
                if (number % 2 == 0 && number != 0) //Number is even
                {
                    RouletteWheel[number] = "Black";
                }
                else if (number % 2 != 0 && number != 0) //Number is odd
                {
                    RouletteWheel[number] = "Red";
                }
                else if (number == 0) //Number is 0
                {
                    RouletteWheel[number] = "Green";
                }
            }
            var random = new Random();
            var randomize = RouletteWheel.ElementAt(random.Next(0, RouletteWheel.Count)); 

            return randomize; //Returns a random (key: value) pair from the rouletteWheel dictionary
        }
    }
}         



   
             
 
