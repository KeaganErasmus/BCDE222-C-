using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChessBoardModel;

namespace ChessMaze
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            // show empty board
            //printBoard(myBoard);

            Cell currentCell = setCurrentCell(3, 3);


            // Set pieces on board
            //myBoard.SetOccupiedPiece(1, 1, (Part)'r');
            myBoard.SetOccupiedPiece(0, 7, (Part)'N');
            myBoard.SetOccupiedPiece(2, 6, (Part)'B');
            myBoard.SetOccupiedPiece(3, 7, (Part)'R');
            myBoard.SetOccupiedPiece(1, 3, (Part)'K');
            myBoard.SetOccupiedPiece(0, 4, (Part)'R');
            myBoard.SetOccupiedPiece(7, 7, (Part)'K');

            myBoard.MarkNextLegalMoves(currentCell, Part.PlayerOnRook);
            printBoard(myBoard);

            Console.ReadLine();
        }

        private static Cell setCurrentCell(int currentRow, int currentCol)
        {
            return myBoard.theGrid[currentRow, currentCol];
        }

        private static void printBoard(Board myBoard)
        {
            // display chess board: 'X' = current piece, '+' = legal next move, * = empty
            for (int x = 0; x < myBoard.Size; x++)
            {
                for (int y = 0; y < myBoard.Size; y++)
                {
                    Cell c = myBoard.theGrid[x, y];

                    if (c.playerCell)
                    {
                        Console.Write('X');

                    }else if (c.CurrentlyOccupied == true)
                    {
                        // K, R, B, N
                        switch (c.Piece)
                        {
                            case (Part)'K':
                                Console.Write('K');
                                break;

                            case (Part)'R':
                                Console.Write('R');
                                break;

                            case (Part)'B':
                                Console.Write('B');
                                break;

                            case (Part)'N':
                                Console.Write('N');
                                break;

                            case (Part)'Q':
                                Console.Write('Q');
                                break;
                        }
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write('+');
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("====================");
        }
    }
}