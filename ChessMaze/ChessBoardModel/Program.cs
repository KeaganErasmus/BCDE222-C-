using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoardModel;

namespace ChessMaze
{
    public class Program
    {
        static Board myBoard = new(8);
        static Game theGame = new();
        static void Main(string[] args)
        {

            myBoard.GameStart();
            myBoard.MoveCounter();

            // Set the player at the start of the game
            Cell currentCell = myBoard.SetCurrentCell(1, 0);

            // This starts a timer to show the amount of time it took to do all moves
            myBoard.StartTimer();

            Console.WriteLine("Move count: {0}", myBoard.moveCount);
            theGame.Load();
            myBoard.MarkNextLegalMoves(currentCell, currentCell.Piece);
            printBoard(myBoard);

            // Hardcoded first move
            Cell nextMove = myBoard.SetNextMove(1, 3, currentCell);
            myBoard.ResetAllLegalMoves();
            myBoard.MarkNextLegalMoves(nextMove, nextMove.Piece);

            myBoard.MoveCounter();
            Console.WriteLine("Move count: {0}", myBoard.moveCount);

            printBoard(myBoard);

            // This move is not Legal we should get a message telling us it is not legal
            // And there should be no Legal moves being printed
            Cell nextMove1 = myBoard.SetNextMove(0, 5, nextMove);
            myBoard.ResetAllLegalMoves();
            myBoard.MarkNextLegalMoves(nextMove1, nextMove1.Piece);

            printBoard(myBoard);

            myBoard.StopTimer();

            Console.ReadLine();
        }
        public static void printBoard(Board myBoard)
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

                    }
                    else if (c.CurrentlyOccupied == true)
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