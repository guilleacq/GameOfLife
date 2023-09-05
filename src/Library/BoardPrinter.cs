using System;
using System.Text;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class BoardPrinter
    {
        public static void PrintBoard(Board board)
        {
            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y<board.Height;y++)
            {
                for (int x = 0; x<board.Width; x++)
                {
                    if(board.GetCell(x,y))
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }
                s.Append("\n");
            }
            Console.WriteLine(s.ToString());
        }

    }
}
