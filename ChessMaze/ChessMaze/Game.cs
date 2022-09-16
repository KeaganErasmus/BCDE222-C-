using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessMaze;

namespace ChessMaze
{
    public class Game : IGame
    {
        static Board myBoard = new(8);
        public int moveCount;

        public int GetMoveCount()
        {
            moveCount += 1;
            return moveCount;
        }

        public bool IsFinished()
        {
            if(myBoard.playerCell == myBoard.finishCell)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Load()
        {
            myBoard.SetLevelName("Level1");
            Console.WriteLine(myBoard.levelName);
            myBoard.SetCurrentCell(1, 0);
            myBoard.WinCell(7,7);
            // Sets the first piece and this piece is what the player will start as
            myBoard.SetOccupiedPiece(1, 0, (Part)'R');

            // Set pieces on board for the first level
            myBoard.SetOccupiedPiece(0, 7, (Part)'N');
            myBoard.SetOccupiedPiece(2, 6, (Part)'B');
            myBoard.SetOccupiedPiece(3, 7, (Part)'R');
            myBoard.SetOccupiedPiece(1, 3, (Part)'K');
            myBoard.SetOccupiedPiece(0, 4, (Part)'R');
            myBoard.SetOccupiedPiece(7, 7, (Part)'K');
        }

        public void Move()
        {
            Console.WriteLine("Enter next Row");
            int nextRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter next Column");
            int nextCol = int.Parse(Console.ReadLine());

            Cell nextCell = myBoard.SetNextMove(nextRow, nextCol);
            myBoard.ResetAllLegalMoves();
            myBoard.MarkNextLegalMoves(nextCell, nextCell.Piece);
            Console.WriteLine(moveCount);
            Program.printBoard(myBoard);
            GetMoveCount();
            Console.WriteLine("Number of moves {0}", moveCount);
            Console.WriteLine("");

            // If not finished prompt for next move
            if (!IsFinished())
            {
                Console.WriteLine("Press R to Restart Or any other key to continue or Press enter to continue");
                Console.WriteLine("Press U to undo");
                string r = Console.ReadLine();
                if (r == "R" || r == "r")
                {
                    Restart();
                }
                else if (r == "u" || r =="U")
                {
                    Undo();
                }
                else
                {
                    Move();
                }
            }
            // game is finished
            else
            {
                Console.WriteLine("You Win!");
                myBoard.StopTimer();
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        public void Restart()
        {
            Start();
        }

        public void Start()
        {
            // Reset Board
            myBoard.GameStart();

            myBoard.StartTimer();

            // load pieces onto the board
            Load();

            Cell currentCell = myBoard.playerCell;

            // calc all legal moves
            myBoard.MarkNextLegalMoves(currentCell, currentCell.Piece);

            // Display board
            Program.printBoard(myBoard);

            Move();
        }

        public void Undo()
        {
            Cell lastCell = myBoard.lastCell;
            myBoard.ResetAllLegalMoves();
            myBoard.SetCurrentCell(lastCell.RowNumber, lastCell.ColumnNumber);
            myBoard.MarkNextLegalMoves(lastCell, lastCell.Piece);
            moveCount -= 1;
            Console.WriteLine("Number of moves {0}", moveCount);

            Program.printBoard(myBoard);

            Move();
        }
    }
}
