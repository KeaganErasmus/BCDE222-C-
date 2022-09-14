using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            myBoard.GameStart();

            Cell currentCell = myBoard.SetCurrentCell(1, 0);

            // Start the timer for the game
            var timer = new Stopwatch();
            timer.Start();


            // Set pieces on board
            myBoard.SetOccupiedPiece(1, 0, (Part)'R');
            myBoard.SetOccupiedPiece(0, 7, (Part)'N');
            myBoard.SetOccupiedPiece(2, 6, (Part)'B');
            myBoard.SetOccupiedPiece(3, 7, (Part)'R');
            myBoard.SetOccupiedPiece(1, 3, (Part)'K');
            myBoard.SetOccupiedPiece(0, 4, (Part)'R');
            myBoard.SetOccupiedPiece(7, 7, (Part)'K');

            // Set the player at the start of the game
            Console.WriteLine("Move count: {0}", myBoard.moveCount);

            myBoard.MarkNextLegalMoves(currentCell, currentCell.Piece);
            printBoard(myBoard);

            // Hardcoded first move
            Cell nextMove = myBoard.SetNextMove(1, 3, currentCell);
            myBoard.MarkNextLegalMoves(nextMove, nextMove.Piece);

            myBoard.moveCounter();
            Console.WriteLine("Move count: {0}", myBoard.moveCount);

            //myBoard.MarkNextLegalMoves(nextMove, currentCell.Piece);

            printBoard(myBoard);

            //Cell nextMove1 = myBoard.SetNextMove(0, 4, currentCell);
            //myBoard.MarkNextLegalMoves(nextMove1, nextMove1.Piece);

            //printBoard(myBoard);

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string time = timeTaken.ToString(@"m\:ss\.fff");

            // Print the time taken
            Console.WriteLine("Time Taken: {0}", time);


            Console.ReadLine();
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