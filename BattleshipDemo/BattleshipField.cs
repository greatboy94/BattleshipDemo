using System;

namespace BattleshipDemo
{
    public class BattleshipField
    {
        public static int[,] field1 = new int[6, 6];
        public static int[,] field2 = new int[6, 6];
        
        public static int[,] show1 = new int[6, 6];
        public static int[,] show2 = new int[6, 6];
        

        public void PlaceShips(string playerName, int[,] field)
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

                for (int j = 0; j < singleDeck; j++)
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
        
        public void BattleArea(int[,] field)
        {
            Console.WriteLine("   0   1   2   3   4   5");
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write(i+"-");
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
        
        public static void Fire(string playerName, int[,] show, int[,] field)
        {
            while (true)
            {
                Console.WriteLine(playerName + " fire to ships");
                for (int i = 0; i < show.GetLength(0); i++)
                {
                    for (int j = 0; j < show.GetLength(1); j++)
                    {
                        if (show[j, i] == 0)
                        {
                            Console.Write("[ ] ");
                        }
                        else if (show[j, i] == 1)
                        {
                            Console.Write("[X] ");
                        }
                        else
                        {
                            Console.Write("[*] ");
                        }
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Please enter X index coordinate:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y index coordinates:");
                int y = Convert.ToInt32(Console.ReadLine());
                if (field[x, y] == 1)
                {
                    Console.WriteLine("Hit, Fire again");
                    show[x, y] = 2;
                }
                else
                {
                    Console.WriteLine("Miss, wait your next move");
                    show[x, y] = 1;
                    break;
                }
            }
        }

        public static bool CheckWinner()
        {
            int count1 = 0;
            int count2 = 0;

            for (int i = 0; i < show1.GetLength(0); i++)
            {
                for (int j = 0; j < show1.GetLength(1); j++)
                {
                    if (show1[i,j]==2)
                    {
                        count1++;
                    }
                }
            }
            
            for (int i = 0; i < show2.GetLength(0); i++)
            {
                for (int j = 0; j < show2.GetLength(1); j++)
                {
                    if (show2[i,j]==2)
                    {
                        count2++;
                    }
                }
            }

            if (count1>=10)
            {
                Console.WriteLine($"{Player1.name} Winner");
                return true;
            }
            if (count2>=10)
            {
                Console.WriteLine($"{Player2.name} Winner");
                return true;
            }

            return false;
        }
    }
}

