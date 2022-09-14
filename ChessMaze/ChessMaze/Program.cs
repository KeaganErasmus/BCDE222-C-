﻿using System;
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

            // Set the player at the start of the game
            Cell currentCell = myBoard.SetCurrentCell(1, 0);
            
            // This starts a timer to show the amount of time it took to do all moves
            myBoard.StartTimer();

            FirstLevel();
            Console.WriteLine("Move count: {0}", myBoard.moveCount);

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

            //myBoard.ResetGame();
            //FirstLevel();
            //printBoard(myBoard);


            Console.ReadLine();
        }

        private static void FirstLevel()
        {
            // Set pieces on board for the first level
            myBoard.SetOccupiedPiece(1, 0, (Part)'R');
            myBoard.SetOccupiedPiece(0, 7, (Part)'N');
            myBoard.SetOccupiedPiece(2, 6, (Part)'B');
            myBoard.SetOccupiedPiece(3, 7, (Part)'R');
            myBoard.SetOccupiedPiece(1, 3, (Part)'K');
            myBoard.SetOccupiedPiece(0, 4, (Part)'R');
            myBoard.SetOccupiedPiece(7, 7, (Part)'K');
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