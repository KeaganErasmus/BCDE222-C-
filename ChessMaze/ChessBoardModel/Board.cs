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
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }
            // find all the legal moves

            switch (chessPiece)
            {
                // Knight
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

                // Bishop
                case (Part)'b':

                    //theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;

                    for (int i = 0; i < Size - currentCell.RowNumber; i++)
                    {
                        for (int j = 0; j < currentCell.ColumnNumber; j++)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                    }

                    //theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    //theGrid[currentCell.RowNumber + 3, currentCell.ColumnNumber + 3].LegalNextMove = true;
                    break;

                // Queen
                case (Part)'q':
                    break;

                // King
                case (Part)'k':
                    theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    break;

                // Rook
                case (Part)'r':
                    // Checks the moves to the right and down
                    for (int i = 0; i < Size - currentCell.RowNumber; i++)
                    {
                        theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;

                        for (int j = 0; j < currentCell.ColumnNumber; j++)
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j - 1].LegalNextMove = true;
                        }
                    }
                    // Checks moves to the left and up
                    for (int i = 0; i < currentCell.RowNumber; i++)
                    {
                        theGrid[currentCell.RowNumber - i - 1, currentCell.ColumnNumber].LegalNextMove = true;

                        for (int j = 0; j < Size - currentCell.ColumnNumber; j++)
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + j].LegalNextMove = true;
                        }
                    }
                    break;
            }

            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
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