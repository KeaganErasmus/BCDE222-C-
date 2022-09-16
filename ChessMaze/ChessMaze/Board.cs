using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessMaze;

namespace ChessMaze
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }
        public Cell playerCell { get; set; }
        public Cell finishCell { get; set; }
        public Cell lastCell { get; set; }

        public string levelName;

        public Stopwatch timer = new();
        public Board(int s)
        {
            // Initial board size
            Size = s;

            theGrid = new Cell[Size, Size];

            // filling 2D array with cells
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public string SetLevelName(string name)
        {
            levelName = name;
            return levelName;
        }
        public void StartTimer()
        {
            timer.Start();
        }

        public string StopTimer()
        {

            TimeSpan timeTaken = timer.Elapsed;
            string time = timeTaken.ToString(@"m\:ss\.fff");

            // Print the time taken
            Console.WriteLine("Time Taken: {0}", time);
            return time;
        }

        public void GameStart()
        {
            // reset the board
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].CurrentlyOccupied = false;
                    theGrid[i, j].LegalNextMove     = false;
                }
            }
        }

        public void ResetAllLegalMoves()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    theGrid[x, y].LegalNextMove = false;
                }
            }
        }

        protected void RookMove(Cell currentCell)
        {
            // DOWN
            for (int i = 1; i <= Size - currentCell.RowNumber; i++)
            {
                // check if Down movement is valid
                if (currentCell.RowNumber + i <= Size - 1)
                {
                    // check if next cell is occupied
                    if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].CurrentlyOccupied)
                    {
                        theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        break;
                    }
                    else
                    {
                        theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                }
            }

            // LEFT
            for (int j = 1; j < (currentCell.ColumnNumber + 1); j++)
            {
                // check if next cell is occupied - if so then set as legal and exit the for loop
                if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j].CurrentlyOccupied)
                {
                    theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j].LegalNextMove = true;
                    break;
                }
                else
                {
                    theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j].LegalNextMove = true;
                }
            }

            //  UP
            for (int i = 1; i <= currentCell.RowNumber; i++)
            {
                // check if Up movement is valid
                if (currentCell.RowNumber - i >= 0)
                {
                    // check if next cell is occupied
                    if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].CurrentlyOccupied)
                    {
                        theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                        break;
                    }
                    else
                    {
                        theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                }
            }
            //RIGHT
            for (int j = 1; j < Size - currentCell.ColumnNumber; j++)
            {
                // check if next cell is occupied - if so then set as legal and exit the for loop
                if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber + j].CurrentlyOccupied)
                {
                    theGrid[currentCell.RowNumber, currentCell.ColumnNumber + j].LegalNextMove = true;
                    break;
                }
                else
                {
                    theGrid[currentCell.RowNumber, currentCell.ColumnNumber + j].LegalNextMove = true;
                }
            }
        }

        protected void KingMove(Cell currentCell)
        {
            int[,] targetPositions = new int[,]
            {
                {  1, -1 },
                {  1,  1 },
                {  1,  0 },
                { -1, -1 },
                { -1,  1 },
                { -1,  0 },
                {  0,  1 },
                {  0, -1 }
            };


            for (var i = 0; i < targetPositions.GetLength(0); ++i)
            {
                if ((currentCell.RowNumber + targetPositions[i, 0] >= 0) & (currentCell.RowNumber + targetPositions[i, 0] < Size)
                    & (currentCell.ColumnNumber + targetPositions[i, 1] >= 0) & (currentCell.ColumnNumber + targetPositions[i, 1] < Size))
                {
                    theGrid[currentCell.RowNumber + targetPositions[i, 0], currentCell.ColumnNumber + targetPositions[i, 1]].LegalNextMove = true;
                }
            }
        }

        protected void BishopMove(Cell currentCell)
        {
            for (var i = 1; i < Size; ++i)
            {
                if ((currentCell.RowNumber + i >= 0) & (currentCell.RowNumber + i < Size)
                    & (currentCell.ColumnNumber + i >= 0) & (currentCell.ColumnNumber + i < Size))
                {
                    // check if next cell is occupied - if so then set as legal and exit the for loop
                    if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].CurrentlyOccupied)
                    {
                        theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        break;
                    }
                    else
                    {
                        theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                }
            }
            for (var i = 1; i < Size; ++i)
            {
                if ((currentCell.RowNumber - i >= 0) & (currentCell.RowNumber - i < Size)
                    & (currentCell.ColumnNumber - i >= 0) & (currentCell.ColumnNumber - i < Size))
                {
                    // check if next cell is occupied - if so then set as legal and exit the for loop
                    if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].CurrentlyOccupied)
                    {
                        theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        break;
                    }
                    else
                    {
                        theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                }
            }
            for (var i = 1; i < Size; ++i)
            {
                if ((currentCell.RowNumber + i >= 0) & (currentCell.RowNumber + i < Size)
                    & (currentCell.ColumnNumber - i >= 0) & (currentCell.ColumnNumber - i < Size))
                {
                    // check if next cell is occupied - if so then set as legal and exit the for loop
                    if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].CurrentlyOccupied)
                    {
                        theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        break;
                    }
                    else
                    {
                        theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                }
            }
            for (var i = 1; i < Size; ++i)
            {
                if ((currentCell.RowNumber - i >= 0) & (currentCell.RowNumber - i < Size)
                    & (currentCell.ColumnNumber + i >= 0) & (currentCell.ColumnNumber + i < Size))
                {
                    // check if next cell is occupied - if so then set as legal and exit the for loop
                    if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].CurrentlyOccupied)
                    {
                        theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        break;
                    }
                    else
                    {
                        theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                }
            }
        }

        protected void KnightMove(Cell currentCell)
        {
            int[,] targetPositions = new int[,]
                   {
                        {  2, -1 },
                        {  2,  1 },
                        {  1,  2 },
                        {  1, -2 },
                        { -1,  2 },
                        { -1, -2 },
                        { -2,  1 },
                        { -2, -1 }
                   };


            for (var i = 0; i < targetPositions.GetLength(0); ++i)
            {
                if ((currentCell.RowNumber + targetPositions[i, 0] >= 0) & (currentCell.RowNumber + targetPositions[i, 0] < Size)
                    & (currentCell.ColumnNumber + targetPositions[i, 1] >= 0) & (currentCell.ColumnNumber + targetPositions[i, 1] < Size))
                {
                    theGrid[currentCell.RowNumber + targetPositions[i, 0], currentCell.ColumnNumber + targetPositions[i, 1]].LegalNextMove = true;
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, Part chessPiece)
        {
            // display legal moves for each piece
            switch (chessPiece)
            {
                case (Part)'N':
                    KnightMove(currentCell);
                    break;

                case (Part)'B':
                    BishopMove(currentCell);
                    break;

                case (Part)'Q':
                    // Diagonal
                    BishopMove(currentCell);

                    // UP AND DOWN
                    RookMove(currentCell);
                    break;

                case (Part)'K':
                    KingMove(currentCell);
                    break;

                case (Part)'R':
                    RookMove(currentCell);
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].playerCell = true;
        }

        public Cell SetCurrentCell(int currentRow, int currentCol)
        {
            playerCell = this.theGrid[currentRow, currentCol];
            Cell currentCell = this.theGrid[currentRow, currentCol];
            if (currentCell.CurrentlyOccupied)
            {
                currentCell.playerCell = true;
                return currentCell;
            }
            else
            {
                Console.WriteLine("ColumnNumber and RowNumber number must be between 0 - 8");
                return currentCell;
            }

        }

        public Cell SetOccupiedPiece(int occupiedRow, int occupiedCol, Part piece)
        {
            Cell occupiedCell = this.theGrid[occupiedRow, occupiedCol];
            // get x and y co-ords and check they're are within the board
            if (!occupiedCell.CurrentlyOccupied)
            {
                occupiedCell.Piece = piece;
                occupiedCell.CurrentlyOccupied = true;
                return occupiedCell;
            }
            else
            {
                Console.WriteLine("ColumnNumber and RowNumber number must be between 0 - 8");
                return occupiedCell;
            }
        }

        public Cell SetNextMove(int nextRow, int nextCol)
        {
            lastCell = playerCell;
            playerCell = theGrid[nextRow, nextCol];

            // Checks if next cell is a legal move and there is a piece there
            if (playerCell.LegalNextMove & playerCell.CurrentlyOccupied)
            {
                SetCurrentCell(nextRow, nextCol);
                return playerCell;
            }
            else
            {
                Console.WriteLine("Illegal Move");
                playerCell = lastCell;
                return playerCell;
            }
        }

        public Cell WinCell(int lastRow, int lastCol)
        {
            finishCell = theGrid[lastRow, lastCol];
            return finishCell;
        }
    }
}