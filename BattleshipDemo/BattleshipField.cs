using System;

namespace BattleshipDemo
{
    public class BattleshipField
    {
        public static int[,] field1 = new int[6, 6];
        public static int[,] field2 = new int[6, 6];
        
        public static int[,] show1 = new int[6, 6];
        public static int[,] show2 = new int[6, 6];
        

        //Place ships to the field
        public void PlaceShips(string playerName, int[,] field)
        {
            for (int deckCount =1; deckCount <=3; deckCount++){
                string myDeck = shipTypes(deckCount);
                Console.WriteLine($"{playerName} -> Please place your {myDeck} deck ship [You have only {deckCount}]");
                BattleArea(field);
            
                for (int i = deckCount; i > 0; i--)
                {
                    n1:
                    Console.WriteLine("Remaining ships: " + i);
                    Console.WriteLine("Please enter X index coordinate:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter Y index coordinate:");
                    int y = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Place your ships:");
                    Console.WriteLine("1. Vertical");
                    Console.WriteLine("2. Horizontal");
                    int line = Convert.ToInt32(Console.ReadLine());

                    if (!checkEnabled(line, x, y, deckCount, field)){
                        BattleArea(field);
                        goto n1;
                    }

                    for (int j = 0; j < 4 - deckCount; j++)
                    {
                        int result = line == 1 ? field[x, y + j] = 1 : field[x + j, y] = 1;
                    }
                    BattleArea(field);
                }
            }
        }
        
        //This for getting ship types
        public string shipTypes(int i)
        {
            switch (i)
            {
                case 1: return "triple";
                case 2: return "double";
                case 3: return "single";
                
                default: return "none";
            }
        }
        
        //Checking for out of bound exception, if will try triple deck place to [5,5] coordinate for example. 
        public bool checkEnabled(int line, int x, int y, int deckCount, int[,] field)
        {
            
            if (((line == 1 ? y : x) + (4 - deckCount)) > 6  || x < 0 || y < 0)
            {
                Console.WriteLine("Out of bound: Please reenter this deck");
                return false;
            }

            //Checking for vertical, horizontal and diagonal
            for (int i = -1; i <= deckCount; i++)
            {
                if (line == 1)
                {
                    //(checkZone(y,i) here is checking if y+number y>6 and y<0;
                    if (checkZone(y,i) && (checkZone(x,-1) && (field[x-1,y+i] == 1) || field[x,y+i] == 1|| (checkZone(x,1) && field[x+1,y+i] == 1)))
                    {
                        Console.WriteLine("Can't place nearby, please find another place!");
                        return false;
                    }
                }
                else {
                    if (checkZone(x,i) && (checkZone(y,-1) && (field[x+i,y-1] == 1 )|| field[x+i,y] == 1 || (checkZone(y,1) && field[x+i,y+1] == 1)))
                    {
                        Console.WriteLine("Can't place nearby, please find another place!");
                        return false;
                    }
                }
            }
            return true;
        }
        
        //This is for drawing BattleArea array[6,6]
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
     
        //This is for starting game for attacking to ships
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
                    Console.Clear();
                    break;
                }

                if (CheckWinner()>0)
                {
                    break;
                }
            }
        }
        
        //This is for checking winner of the user after killed all ships.
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


      //This is for checking user killed or injured any ships.
      public static bool CheckKilledOrInjured(int x, int y, int[,] field, int[,] show)
        {
            if (x+1<=5 && field[x+1, y]==1 && show[x+1, y]!=2)
            {
                return true;
            }

            if (x-1>=0 && field[x-1, y]==1 && show[x-1, y]!=2)
            {
                return true;
            }
            
            if (y+1<=5 && field[x, y+1]==1 && show[x, y+1]!=2)
            {
                return true;
            }
            
            if (y-1>=0 && field[x, y-1]==1 && show[x, y-1]!=2)
            {
                return true;
            }
            return false;
        }
      
        //This is for marking X around killed ships.
        public static void MarkX(int x, int y, int[,] field, int[,] show)
        {
            bool isHorizontal = false;
            bool isFirst = false;
            bool isLast = false;
            
            //First checking for inside zone and for horizontal
            if (checkZone(x,-1) && field[x-1,y] == 1 || checkZone(x,1) && field[x+1,y] == 1)
            {
                isHorizontal = true;
            }

            if (isHorizontal && (checkZone(x,-1) && field[x-1,y] != 1 || !checkZone(x,-1)))
            {
                isFirst = true;
            } 
            if (!isHorizontal && (checkZone(y,-1) && field[x,y-1] != 1 || !checkZone(y,-1)))
            {
                isFirst = true;
            }
            
            if (isHorizontal && (checkZone(x,1) && field[x+1,y] != 1 || !checkZone(x,1)))
            {
                isLast = true;
            } 
            if (!isHorizontal && (checkZone(y,1) && field[x,y+1] != 1 || !checkZone(y,1)))
            {
                isLast = true;
            }

            //if deck's starting point first and last, this is single deck and need to fill matrix[3,3]
            if (isFirst && isLast){
                for (int i = -1; i< 2; i++)
                {
                    for (int j=-1;j<2;j++)
                    {
                        if (checkZone(x,i) && checkZone(y,j))
                        {
                            show[x+i,y+j] =1;
                        }
                    }
                }
            }
            else if (isFirst)
            {
                for (int i=-1; i < (isHorizontal ? 4 : 2) ; i++)
                {
                    for (int j = -1; j < (isHorizontal ? 2 : 4); j++)
                    {
                        if (checkZone(x,i) && checkZone(y,j))
                        {
                            if (field[x+i,y+j] != 1)
                            {
                                if ((isHorizontal ? i==2 : j==2) && field[x+(isHorizontal ? i-1 : 0),y+(isHorizontal ? 0 : j-1)]==1 || (isHorizontal ? i!=2 : j!=2))
                                {
                                    if ((isHorizontal ? i==3 : j==3) && field[x+(isHorizontal ? i-1 : 0),y+(isHorizontal ? 0 : j-1)]==1 || (isHorizontal ?i!=3 : j!=3))
                                    {
                                        show[x+i,y+j] =1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (isLast){
                for (int i=-1; i < (isHorizontal ? 4 : 2) ; i++)
                {
                    for (int j = -1; j < (isHorizontal ? 2 : 4); j++)
                    {
                        if (checkZone(x,-i) && checkZone(y,-j))
                        {
                            if (field[x-i,y-j] != 1)
                            {
                                if ((isHorizontal ? i==2 : j==2) && field[x - (isHorizontal ?i-1:0),y - (isHorizontal ?0:j-1)]==1 || (isHorizontal ?i!=2 : j!=2))
                                {
                                    if ((isHorizontal ?i==3 : j==3) && field[x - (isHorizontal ?i-1:0),y + (isHorizontal ?0:j-1)]==1 || (isHorizontal ?i!=3 : j!=3))
                                    {
                                        show[x-i,y-j] =1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        //Checking for inside of zone
        public static bool checkZone(int x, int i)
        {
            if (x+i >= 0 && x+i <= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}