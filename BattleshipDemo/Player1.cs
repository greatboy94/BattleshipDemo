using System;

namespace BattleshipDemo
{
    public class Player1:BattleshipField
    {
        public static string name;
        public void CreatePlayer()
        {
            Console.WriteLine("Player#1 please enter your name:");
            name = Console.ReadLine();
            PlaceShips(name,field1);

        }

        
    }
}

