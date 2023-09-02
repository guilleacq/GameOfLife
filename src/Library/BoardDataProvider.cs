using System;
using System.IO;

namespace PII_Game_Of_Life
{
    public class BoardDataProvider
    {

        public Board GenerateBoardFromFile(string path)
        {
            string content = File.ReadAllText(path);

            string[] contentLines = content.Split('\n');
            
            Board generatedBoard = new Board(contentLines.Length, contentLines[0].Length);
            for (int  y=0; y<contentLines.Length;y++)
            {
                for (int x=0; x<contentLines[y].Length; x++)
                {
                    if(contentLines[y][x]=='1')
                    {
                        generatedBoard.SetCell(x, y, true);
                    }
                }
            }

            return generatedBoard;
        }


    }
}
