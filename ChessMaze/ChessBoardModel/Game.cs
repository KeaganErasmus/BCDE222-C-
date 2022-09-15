using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Game : IGame
    {
        static Board myBoard = new(8);
        public int GetMoveCount()
        {
            throw new NotImplementedException();
        }

        public bool IsFinished()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
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
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            // Reset Board
            myBoard.GameStart();

            //start timer
            myBoard.StartTimer();

            // Set pieces on board
            Load();

            Cell currentCell = myBoard.playerCell;

            // calc all legal moves from current piece
            myBoard.MarkNextLegalMoves(currentCell, currentCell.Piece);

            // Display board with entered current cell + legal moves
            Program.printBoard(myBoard);

            Move();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
