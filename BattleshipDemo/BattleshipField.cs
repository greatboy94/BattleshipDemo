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
            for (int i = 1; i > 0; i--)
            {
                Console.WriteLine("Remaining ships: " + i);
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
            for (int i = 2; i > 0; i--)
            {
                repeat:
                Console.WriteLine("Remaining ships: " + i);
                Console.WriteLine("Please enter X index coordinate:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y index coordinate:");
                int y = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Place your ships:");
                Console.WriteLine("1. Vertical");
                Console.WriteLine("2. Horizontal");
                int line = Convert.ToInt32(Console.ReadLine());

                if (!CheckNearbyShips(x,y,doubleDeck,line,field))
                {
                    Console.WriteLine("This field is not empty");
                    goto repeat;
                }

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
            for (int i = 3; i > 0; i--)
            {
                repeat:
                Console.WriteLine("Remaining ships: " + i);
                Console.WriteLine("Please enter X index coordinate:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y index coordinate:");
                int y = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Place your ships:");
                Console.WriteLine("1. Vertical");
                Console.WriteLine("2. Horizontal");
                int line = Convert.ToInt32(Console.ReadLine());
                
                if (!CheckNearbyShips(x,y,singleDeck,line,field))
                {
                    Console.WriteLine("This field is not empty");
                    goto repeat;
                }

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
            bool isBreak = false;
            while (true)
            {
                Console.WriteLine(playerName + " fire to ships");
                Console.WriteLine("   0   1   2   3   4   5");
                for (int i = 0; i < show.GetLength(0); i++)
                {
                    Console.Write(i+"-");
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

                if (isBreak)
                {
                    break;
                }
                
                Console.WriteLine("Please enter X index coordinate:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y index coordinates:");
                int y = Convert.ToInt32(Console.ReadLine());
                if (field[x, y] == 1)
                {
                    if (CheckKilledOrInjured(x,y,field,show))
                    {
                        Console.WriteLine("Injured, fire again");
                    }
                    else
                    {
                        Console.WriteLine("Killed");
                        //show[x + 1, y + 1] = 1;
                        //show[x - 1, y - 1] = 1;
                        MarkX(x, y, field, show);
                    }
                    show[x, y] = 2;
                }
                else
                {
                    Console.WriteLine("Miss, wait your next move");
                    show[x, y] = 1;
                    Console.WriteLine("Please hit enter for next player turn");
                    Console.ReadKey();
                    isBreak = true;
                }

                if (CheckWinner()>0)
                {
                    break;
                }
            }
        }
      public static int CheckWinner()
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
                return 1;
            }
            if (count2>=10)
            {
                return 2;
            }

            return 0;
        }
        
        public static bool CheckNearbyShips(int x, int y, int shipType, int line, int[,] field)
        {
            if (line==1)
            {
                if (y+shipType>field.GetLength(0))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (line==2)
            {
                if (x+shipType>field.GetLength(1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            while (shipType!=0)
            {
                
                for (int i = 0; i < shipType; i++)
                {
                    int storeX = 0;
                    int storeY = 0;
                    if (line==1)
                    {
                        storeY = i;
                    }
                    else
                    {
                        storeX = i;
                    }
        
                    if (x+1+storeX<field.Length && x+1+storeX>=0)
                    {
                        if (field[x+1+storeX, y+storeY]!=0)
                        {
                            return false;
                        }
                    }
                    if (x-1+storeX<field.Length && x-1+storeX>=0)
                    {
                        if (field[x-1+storeX, y+storeY]!=0)
                        {
                            return false;
                        }
                    }
                    
                    if (y+1+storeY<field.Length && y+1+storeY>=0)
                    {
                        if (field[x+storeX, y+1+storeY]!=0)
                        {
                            return false;
                        }
                    }
                    if (y-1+storeY<field.Length && y-1+storeY>=0)
                    {
                        if (field[x+storeX, y-1+storeY]!=0)
                        {
                            return false;
                        }
                    }
                    if (y-1+storeY<field.Length && y-1+storeY>=0)
                    {
                        if (storeX==storeY)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            return true;
        }

        public static bool CheckKilledOrInjured(int x, int y, int[,] field, int[,] show)
        {
            if (x<6 && field[x+1, y]==1 && show[x+1, y]!=2)
            {
                return true;
            }

            if (x>1 && field[x-1, y]==1 && show[x-1, y]!=2)
            {
                return true;
            }
            if (y<6 && field[x, y+1]==1 && show[x, y+1]!=2)
            {
                return true;
            }
            if (y>1 && field[x, y-1]==1 && show[x, y-1]!=2)
            {
                return true;
            }

            return false;
        }
        public static void MarkX(int x, int y, int[,] field, int[,] show)
        {
            int storeX=-1;
            int storeY=-1;

            bool isHorizontal;
            int countDecrement = 1;
            while (true)
            {
                
                if (x - countDecrement < 0 )
                {
                    storeX = x;
                }
                if (y - countDecrement < 0)
                {
                    storeY = y;
                }
                if (x-countDecrement > 0 && field[x-countDecrement,y]!=1)
                {
                    storeX = x - countDecrement;
                }
                if (y-countDecrement >0 && field[x,y-countDecrement]!=1)
                {
                    storeY = y - countDecrement;
                }

                countDecrement++;
                if (storeX!=-1 && storeY!=-1)
                {
                    break;
                }
            }
            
            if (field[x+1, y]==2 || (x-1 > 0 && field[x - 1, y] == 2))
            {
                isHorizontal = true;
            }
            else
            {
                isHorizontal = false;
            }

            int shipLength = 0;
            for (int i = 0; i < 3; i++)
            {
                if((storeX+1+i < 6 && storeY+1+i<6) && field[isHorizontal ? (storeX+1+i) : (storeX+1) ,isHorizontal ? (storeY+1) : (storeY+1+i)] == 1)
                {
                    shipLength++;
                }
            }

            for (int i = 0; i < (isHorizontal ? (shipLength+2) : 3); i++)
            {
                for (int j = 0; j < (isHorizontal? 3: (shipLength+2)); j++)
                {
                    show[storeX+i,storeY+j] = 1;
                }
            }
        }
    }
}