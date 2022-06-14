using System;

namespace BattleshipDemo
{
    public class Player1: BattleshipField
    {
        public void CreatePlayer()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Field();

        }

        
    }
}

