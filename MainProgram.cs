namespace Minesweeper
/*
 * Tyler Benton
 * CST-250
 * Bradley Mauger
 * Milestone 1
 * November 10, 2024 
 */
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            int boardSize = 10;
            float difficulty = 0.35f;

            Board board = new Board(boardSize, difficulty);
            board.CalculateLiveNeighbors(); // Set up neighbors after initializing the bombs

            PrintBoard(board);
        }

        // Helper method to display the board in the console
        static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    // Always display the live neighbor count
                    int displayCount = board.Grid[i, j].LiveNeighbors;
                    if (board.Grid[i, j].Live)
                    {
                        displayCount++;  // Include this cell in the count if it's live
                    }
                    Console.Write($"{displayCount} ");
                }
                Console.WriteLine();
            }
        }


    }
}
