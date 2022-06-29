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
            
            BattleshipField.Fire(Player1.name, BattleshipField.show1,BattleshipField.field2);
            BattleshipField.Fire(Player2.name, BattleshipField.show2,BattleshipField.field1);

        }
    }
}