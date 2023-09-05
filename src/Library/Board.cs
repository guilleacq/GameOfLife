using System;

namespace PII_Game_Of_Life
{
    public class Board
    {
        private bool[,] gameBoard;
        public int Width {get; private set;}
        public int Height {get; private set;}

        public Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            gameBoard = new bool[width, height];
        }
        public static Board CloneBoard(Board board) => new Board(board.Width, board.Height);
        public void SetCell(int x, int y, bool value) => gameBoard[x, y] = value;
        public bool GetCell(int x, int y) => gameBoard[x, y];
    }
}
