using ChessBoardModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessMazeTest
{
    [TestClass]
    public class ChessMazeTests
    {
        [TestMethod]
        public void TestCorrectBoardSize()
        {
            Board myBoard = new(8);
            int expected = 8;

            int boardSize = myBoard.Size;

            Assert.AreEqual(expected, boardSize);
        }

        [TestMethod]
        public void TestCorrectCoordinates()
        {
            Board myBoard = new(8);
            Cell expected = myBoard.SetCurrentCell(0, 0);


            Cell actual = myBoard.SetCurrentCell(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveCounterTest()
        {
            int expected = 2;
            Board myBoard = new(8);
            myBoard.GameStart();
            myBoard.MoveCounter();

            // Set the player at the start of the game
            Cell currentCell = myBoard.SetCurrentCell(1, 0);

            // Sets the first piece and this piece is what the player will start as
            myBoard.SetOccupiedPiece(1, 0, (Part)'R');

            // Set pieces on board for the first level
            myBoard.SetOccupiedPiece(1, 3, (Part)'K');

            Console.WriteLine("Move count: {0}", myBoard.moveCount);

            myBoard.MarkNextLegalMoves(currentCell, currentCell.Piece);

            // Hardcoded first move
            Cell nextMove = myBoard.SetNextMove(1, 3, currentCell);
            myBoard.ResetAllLegalMoves();
            myBoard.MarkNextLegalMoves(nextMove, nextMove.Piece);

            myBoard.MoveCounter();
            Console.WriteLine("Move count: {0}", myBoard.moveCount);

            int actual = myBoard.moveCount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Tests if the player is on a rook piece or not
        public void RookTest()
        {
            Board myBoard = new(8);
            Cell currentCell = myBoard.SetCurrentCell(0, 0);
            myBoard.MarkNextLegalMoves(currentCell, chessPiece: Part.PlayerOnRook);
        }
    }
}
