using System;

namespace BattleshipDemo
{
    public class Player1:BattleshipField
    {
        public void CreatePlayer()
        {
            Console.WriteLine("Player#1 please enter your name:");
            string name = Console.ReadLine();
            PlaceShips(name,field1);
            
        }

        
    }
}

