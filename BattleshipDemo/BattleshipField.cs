using System;

namespace BattleshipDemo
{
    public class BattleshipField
    {
        public static int[,] field1 = new int[6, 6];
        public static int[,] field2 = new int[6, 6];
        
        static int[,] show1 = new int[6, 6];
        static int[,] show2 = new int[6, 6];
        

        public static void PlaceShips(string playerName, int[,] field)
        {
            
            Console.WriteLine($"{playerName} -> Please place your triple deck ship [You have only 1]");
            BattleArea(field);
            
            int tripleDeck = 3;
            for (int i = 0; i < 1; i++)
            {
                
                Console.WriteLine("Please enter X index coordinate:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y index coordinate:");
                int y = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Place your ships:");
                Console.WriteLine("1. Vertical");
                Console.WriteLine("2. Horizontal");
                int line = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < tripleDeck; j++)
                {
                    if (line==1)
                    {
                        field[x, y + j] = 1;
                    }
                    else
                    {
                        field[x + j, y] = 1;
                    }
                }
                BattleArea(field);

            }

            int doubleDeck = 2;
            Console.WriteLine($"{playerName} -> Please place your double deck ships [You have only 2]");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Please enter X index coordinate:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y index coordinate:");
                int y = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Place your ships:");
                Console.WriteLine("1. Vertical");
                Console.WriteLine("2. Horizontal");
                int line = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < doubleDeck; j++)
                {
                    if (line==1)
                    {
                        field[x, y + j] = 1;
                    }
                    else
                    {
                        field[x + j, y] = 1;
                    }
                }
                BattleArea(field);
            }

            int singleDeck = 1;
            Console.WriteLine($"{playerName} -> Please place your single deck ships [You have only 3]");
            for (int i = 0; i < 3; i++)
            {
            
                Console.WriteLine("Please enter X index coordinate:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y index coordinate:");
                int y = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Place your ships:");
                Console.WriteLine("1. Vertical");
                Console.WriteLine("2. Horizontal");
                int line = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < doubleDeck; j++)
                {
                    if (line==1)
                    {
                        field[x, y + j] = 1;
                    }
                    else
                    {
                        field[x + j, y] = 1;
                    }
                }
                BattleArea(field);
            }
        }
        
        public static void BattleArea(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[j,i]==0)
                    {
                        Console.Write("[ ] ");
                    }
                    else
                    {
                        Console.Write("[*] ");
                    }
                }
                Console.WriteLine();
            }
      
        }
    }
}

