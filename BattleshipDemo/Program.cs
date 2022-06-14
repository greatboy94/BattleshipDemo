using System;

namespace BattleshipDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Player1 player1 = new Player1();
            player1.CreatePlayer();

            Player2 player2 = new Player2();
            player2.CreatePlayer();
        }
    }
}