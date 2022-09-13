using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }

        public Cell[,] theGrid { get; set; }

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

        public void MarkNextLegalMoves(Cell currentCell, Part chessPiece)
        {
            // clear the board
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                }
            }

            // display legal moves for each piece
            switch (chessPiece)
            {
                case (Part)'n':
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

                    break;

                case (Part)'b':
                    for (var i = 0; i < Size; ++i)
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
                    for (var i = 0; i < Size; ++i)
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
                    for (var i = 0; i < Size; ++i)
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
                    for (var i = 0; i < Size; ++i)
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
                    break;

                case (Part)'q':

                    // Diagonal movement
                    for (var i = 0; i < Size; ++i)
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
                    for (var i = 0; i < Size; ++i)
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
                    for (var i = 0; i < Size; ++i)
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
                    for (var i = 0; i < Size; ++i)
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

                    // Vertical and horizontal movement
                    // left and down
                    for (int i = 0; i < Size - currentCell.RowNumber; i++)
                    {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                            break;
                        }
                        else
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        }

                        for (int j = 0; j < currentCell.ColumnNumber; j++)
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j - 1].CurrentlyOccupied)
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j - 1].LegalNextMove = true;
                                break;
                            }
                            else
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j - 1].LegalNextMove = true;
                            }
                        }
                    }
                    //  right and up
                    for (int i = 0; i < currentCell.RowNumber; i++)
                    {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (theGrid[currentCell.RowNumber - i - 1, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            theGrid[currentCell.RowNumber - i - 1, currentCell.ColumnNumber].LegalNextMove = true;
                            break;
                        }
                        else
                        {
                            theGrid[currentCell.RowNumber - i - 1, currentCell.ColumnNumber].LegalNextMove = true;
                        }

                        for (int j = 0; j < Size - currentCell.ColumnNumber; j++)
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
                    break;

                case (Part)'k':
                    targetPositions = new int[,]
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
                    break;

                case (Part)'r':
                    // left and down
                    for (int i = 0; i < Size - currentCell.RowNumber; i++)
                    {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                            break;
                        }
                        else
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        }

                        for (int j = 0; j < currentCell.ColumnNumber; j++)
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j - 1].CurrentlyOccupied)
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j - 1].LegalNextMove = true;
                                break;
                            }
                            else
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j - 1].LegalNextMove = true;
                            }
                        }
                    }
                    //  right and up
                    for (int i = 0; i < currentCell.RowNumber; i++)
                    {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (theGrid[currentCell.RowNumber - i - 1, currentCell.ColumnNumber].CurrentlyOccupied)
                        {
                            theGrid[currentCell.RowNumber - i - 1, currentCell.ColumnNumber].LegalNextMove = true;
                            break;
                        }
                        else
                        {
                            theGrid[currentCell.RowNumber - i - 1, currentCell.ColumnNumber].LegalNextMove = true;
                        }

                        for (int j = 0; j < Size - currentCell.ColumnNumber; j++)
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
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].playerCell = true;
        }

        public Cell setStartCell(int currentRow, int currentCol)
        {
            Cell currentCell = this.theGrid[currentRow, currentCol];

            if (currentCell.CurrentlyOccupied ==  false)
            {
                currentCell.playerCell = true;
                return currentCell;
            }
            else
            {
                Console.WriteLine("ColumnNumber and row must be between 0-8");
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
                Console.WriteLine(occupiedCell.Piece);
                return occupiedCell;
            }
        }
    }
}