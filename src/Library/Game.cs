using System;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Game
    {
        // Import board from BoardDataProvider
        BoardDataProvider boardGenerator;
        Board gameBoard;
        BoardPrinter printer;

        public Game(string fileUrl)
        {
            boardGenerator = new BoardDataProvider();
            gameBoard = boardGenerator.GenerateBoardFromFile(fileUrl);

            printer = new BoardPrinter(gameBoard);
        }

        public void StartGame()
        {

            while (true)
            {
                CreateGeneration();
                printer.PrintGame();
                //=================================================
                //Invocar método para calcular siguiente generación
                //=================================================
                Thread.Sleep(300);
            }
        }

        public void CreateGeneration()
        {
            for (int x = 0; x < gameBoard.Width; x++)
            {
                for (int y = 0; y < gameBoard.Height; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<gameBoard.Width && j>=0 && j < gameBoard.Height
                            && gameBoard.GetCell(i,j))
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                }
            }
        }


    }

}
