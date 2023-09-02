using System;

namespace PII_Game_Of_Life
{
    class Program
    {
        private static string boardPath = "../../assets/board.txt";

        static void Main(string[] args)
        {
            Game game = new Game(boardPath);
            game.StartGame();
        }
    }
}
