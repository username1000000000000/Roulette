using System;
namespace MyRoulette
{
    public class Player
    {
        public Player(string _Username)
        {
            Username = _Username;
            Balance = 25.00;
        }

        public string Username { get; set; }
        public double Balance { get; set; }
    }
}
