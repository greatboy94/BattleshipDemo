using System;

namespace BattleshipDemo
{
    public class Player2:BattleshipField
    {
        public void CreatePlayer()
        {
            Console.WriteLine("Player#2 please enter your name:");
            string name = Console.ReadLine();
            PlaceShips(name,field2);

        }

        
    }
}