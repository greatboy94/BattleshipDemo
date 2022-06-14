using System;

namespace BattleshipDemo
{
    public class BattleshipField
    {
        int[,] field = new int[6,6];
        public void Field()
        {
            int height = field.GetLength(0);
            int width = field.GetLength(1);
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(field[i,j]+"\t");
                }

                Console.WriteLine();
            }
            
            SetTripleDeck();
            SetDoubleDeck();
            SetSingleDeck();
            
            
            // Console.WriteLine("1-> Set Triple Deck");
            // Console.WriteLine("2-> Set Double Deck");
            // Console.WriteLine("3-> Set Single Deck");
            
            //Console.WriteLine("Please choose one of these options: ");
            //int opt = Convert.ToInt32(Console.ReadLine());

            // switch (opt)
            // {
            //     case 1: SetTripleDeck();
            //         return;
            //     case 2: SetDoubleDeck();
            //         break;
            //     case 3: SetSingleDeck();
            //         break;
            //     default: Console.WriteLine("Out of bound");
            //         break;
            // }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(field[i,j]+"\t");
                }

                Console.WriteLine();
            }
        }

        public void SetTripleDeck()
        {
            Console.WriteLine("-----Set Triple Deck-----");
            
            int tripleDeck = 3;
            Console.WriteLine("Set one Triple Deck");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter index X:");
                int b=Int32.Parse(Console.ReadLine());
            
                Console.Write("Enter index Y:");
                int c=Int32.Parse(Console.ReadLine());
                field.SetValue(tripleDeck,b,c);
            }
        }
        
        public void SetDoubleDeck()
        {
            Console.WriteLine("-----Set Double Deck-----");
            
            int doubleDeck = 2;
            Console.WriteLine("set first Double Deck");
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Enter index X:");
                int b=Int32.Parse(Console.ReadLine());
            
                Console.Write("Enter index Y:");
                int c=Int32.Parse(Console.ReadLine());
                field.SetValue(doubleDeck,b,c);
            }

            Console.WriteLine("Set second Double Deck");
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Enter index X:");
                int b=Int32.Parse(Console.ReadLine());
            
                Console.Write("Enter index Y:");
                int c=Int32.Parse(Console.ReadLine());
                field.SetValue(doubleDeck,b,c);
            }
        }
        
        public void SetSingleDeck()
        {
            Console.WriteLine("-----Set Single Deck-----");
            
            int singleDeck = 1;
            Console.WriteLine("Set first Single Deck");
            for (int i = 0; i < 1; i++)
            {

                Console.Write("Enter index X:");
                int b=Int32.Parse(Console.ReadLine());
            
                Console.Write("Enter index Y:");
                int c=Int32.Parse(Console.ReadLine());
                field.SetValue(singleDeck,b,c);
            }

            Console.WriteLine("Set second Single Deck");
            for (int i = 0; i < 1; i++)
            {
                Console.Write("Enter index X:");
                int b=Int32.Parse(Console.ReadLine());
            
                Console.Write("Enter index Y:");
                int c=Int32.Parse(Console.ReadLine());
                field.SetValue(singleDeck,b,c);
            }

            Console.WriteLine("Set third Single Deck");
            for (int i = 0; i < 1; i++)
            {
                Console.Write("Enter index X:");
                int b=Int32.Parse(Console.ReadLine());
            
                Console.Write("Enter index Y:");
                int c=Int32.Parse(Console.ReadLine());
                field.SetValue(singleDeck,b,c);
            }
        }
    }
}

