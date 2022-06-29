using System;

namespace BattleshipDemo
{
    public class Player2:BattleshipField
    {
        public static string name;
        public void CreatePlayer()
        {
            Console.WriteLine("Player#2 please enter your name:");
            name = Console.ReadLine();
            PlaceShips(name,field2);

        }

        
    }
}