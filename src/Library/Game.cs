using System;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Game
    {
        // Import board from BoardDataProvider
        Board gameBoard;
        Board cloneBoard;

        public Game(string fileUrl)
        {
            gameBoard = BoardDataProvider.GenerateBoardFromFile(fileUrl);
            cloneBoard = Board.CloneBoard(gameBoard);
        }

        public void StartGame()
        {
            while (true)
            {
                Console.Clear();
                BoardPrinter.PrintBoard(cloneBoard);
                CreateGeneration();
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
                            if(i>=0 && i<gameBoard.Width && j>=0 && j < gameBoard.Height && gameBoard.GetCell(i,j))
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(gameBoard.GetCell(x,y))
                    {
                        aliveNeighbors--;
                    }
                    if (gameBoard.GetCell(x,y) && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneBoard.SetCell(x,y,false);
                    }
                    else if (gameBoard.GetCell(x,y) && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                       cloneBoard.SetCell(x,y,false);
                    }
                    else if (!gameBoard.GetCell(x,y) && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneBoard.SetCell(x,y,true);
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneBoard.SetCell(x,y,gameBoard.GetCell(x,y));
                    }
                }
            }

            gameBoard = cloneBoard;
        }


    }

}
