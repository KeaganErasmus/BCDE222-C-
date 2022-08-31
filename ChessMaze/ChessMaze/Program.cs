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
            printBoard(myBoard);

            Cell currentCell = setCurrentCell();
            currentCell.CurrentlyOccupied = true;

            myBoard.MarkNextLegalMoves(currentCell, Part.PlayerOnKing);
            // Set pieces on board
            myBoard.SetOccupiedPiece(3, 3, (Part)'N');
            myBoard.SetOccupiedPiece(3, 7, (Part)'N');
            myBoard.SetOccupiedPiece(2, 6, (Part)'B');
            myBoard.SetOccupiedPiece(0, 0, (Part)'q');

            printBoard(myBoard);

            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            // get user x and y
            Console.WriteLine("enter row number");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("enter col number");
            int currentCol = int.Parse(Console.ReadLine());

            Console.WriteLine("\nRow: {0}, Col: {1}", currentRow, currentCol);

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

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write('x');
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