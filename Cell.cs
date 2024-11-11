namespace Minesweeper
/*
* Tyler Benton
* CST-250
* Bradley Mauger
* Milestone 1
* November 10, 2024 
*/
{
    public class Cell
    {
        // Properties
        public int Row { get; set; } = -1;
        public int Column { get; set; } = -1;
        public bool Visited { get; set; } = false;
        public bool Live { get; set; } = false;  // True if the cell contains a bomb
        public int LiveNeighbors { get; set; } = 0;  // Count of live neighbors

        // Constructor
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
