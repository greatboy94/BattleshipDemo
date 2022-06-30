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

            while (true)
            {
                BattleshipField.Fire(Player1.name, BattleshipField.show1,BattleshipField.field2);
                if (BattleshipField.CheckWinner())
                {
                    break;
                }
                BattleshipField.Fire(Player2.name, BattleshipField.show2,BattleshipField.field1);
                if (BattleshipField.CheckWinner())
                {
                    break;
                }
            }
        }
    }
}