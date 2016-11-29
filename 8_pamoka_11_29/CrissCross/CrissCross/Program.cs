using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrissCross
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[4,4];

            CreateBoard(board);
            DrawBoard(board);

            int turn = 0;
            while (true)
            {
                turn++;
                string player;
                if (turn%2 == 0)
                {
                    player = "X";
                }
                else
                {
                    player = "0";
                }
                string[] input = Console.ReadLine().Split(' ');

                int x = Convert.ToInt16(input[1]);
                int y = Convert.ToInt16(input[0]);

                board[x, y] = Convert.ToChar(player);

                bool temp = CheckForWinner(board, Convert.ToChar(player));
                if (temp == true)
                {
                    Console.WriteLine(player + " Won!");
                    DrawBoard(board);
                    Console.ReadLine();                    
                    CreateBoard(board);
                }
                Console.Clear();
                DrawBoard(board);
                
            }
            
            Console.ReadLine();
        }

        private static bool CheckForWinner(char[,] brd, char player)
        {
            for (int x = 1; x < 4; x++)
            {
                if ((brd[x, 1] == player && brd[x, 2] == player && brd[x, 3] == player) ||
                    (brd[1, 1] == player && brd[2, 2] == player && brd[3, 3] == player) ||
                    (brd[1, x] == player && brd[2, x] == player && brd[3, x] == player) ||
                    (brd[1, 3] == player && brd[2, 2] == player && brd[3, 1] == player))
                {
                    return true;
                }
            } 
            return false;
        }
        private static void CreateBoard(char[,] brd)
        {
            for (int x = 1, y = 0; y < 4; y++, x++)
            {
                try
                {
                    brd[0, x] = Convert.ToChar(x.ToString());
                    brd[x, 0] = Convert.ToChar(x.ToString());
                }
                catch
                {
                    continue;
                }
                for (int i = 1; i < 4; i++)
                {
                    brd[x, i] = '#';
                }
            }
        }
        private static void DrawBoard(char[,] brd)
        {
            for (int x = 3; x >= 0; x--)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(brd[x, i]);
                }
                Console.Write("\n");
            }
        }
    }
}
