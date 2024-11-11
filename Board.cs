using System;
using System.Collections.Generic;
using System.Linq;
namespace Minesweeper
/*
* Tyler Benton
* CST-250
* Bradley Mauger
* Milestone 1
* November 10, 2024 
*/
{
    public class Board
    {
        public int Size { get; private set; }
        public Cell[,] Grid { get; private set; }
        public float Difficulty { get; set; }
        public int MineCount { get; private set; } // Store the number of mines

        public Board(int size, float difficulty)
        {
            if (size * size < (int)(size * size * difficulty))
            {
                throw new ArgumentException("MineCount can't exceed the number of cells on the board.");
            }

            Size = size;
            Difficulty = difficulty;
            MineCount = (int)(size * size * difficulty);
            Grid = new Cell[size, size];
            InitializeCells();
            SetupLiveNeighbors();
        }

        private void InitializeCells()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Cell(i, j);
                }
            }
        }

        public void SetupLiveNeighbors()
        {
            List<int> positions = Enumerable.Range(0, Size * Size).ToList();
            Random rand = new Random();
            // Shuffle the positions
            for (int i = positions.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = positions[i];
                positions[i] = positions[j];
                positions[j] = temp;
            }

            // Place mines
            for (int i = 0; i < MineCount; i++)
            {
                int pos = positions[i];
                int row = pos / Size;
                int col = pos % Size;
                Grid[row, col].Live = true;
            }
        }

        public void CalculateLiveNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j].Live)
                    {
                        Grid[i, j].LiveNeighbors = 9;
                        continue;
                    }

                    int liveCount = 0;
                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            int ni = i + di, nj = j + dj;
                            if (ni >= 0 && ni < Size && nj >= 0 && nj < Size && Grid[ni, nj].Live)
                            {
                                liveCount++;
                            }
                        }
                    }
                    Grid[i, j].LiveNeighbors = liveCount;
                }
            }
        }
    }
}
