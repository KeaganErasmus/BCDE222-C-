using ChessMaze;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessMazeTests
{
    [TestClass]
    public class TestBoardSize
    {
        [TestMethod]
        public void TestBoardSizeCorrect()
        {
            int expected = 8;
            Board myBoard = new(8);

            int actual = myBoard.Size;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBoardSizeFail()
        {
            int expected = 8;
            Board myBoard = new(4);

            int actual = myBoard.Size;

            Assert.AreNotEqual(expected, actual);
        }
    }

    [TestClass]
    public class TestLevelName
    {
        [TestMethod]
        public void TestLevelNameCorrect()
        {
            string expected = "Level 1";
            Board myBoard = new(8);
            myBoard.SetLevelName("Level 1");

            string actual = myBoard.levelName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLevelNameFail()
        {
            string expected = "Level 1";
            Board myBoard = new(8);
            myBoard.SetLevelName("Level 11");

            string actual = myBoard.levelName;

            Assert.AreNotEqual(expected, actual);
        }
    }

    [TestClass]
    public class TestCorrectNumberOfMoves
    {
        [TestMethod]
        public void CorrectNumOfMoves()
        {
            int expected = 1;
            Game game = new Game();
            Board myBoard = new(8);
            myBoard.SetLevelName("Level1");
            myBoard.SetCurrentCell(1, 0);
            myBoard.WinCell(7, 7);
            // Sets the first piece and this piece is what the player will start as
            myBoard.SetOccupiedPiece(1, 0, (Part)'R');

            // Set pieces on board for the first level
            myBoard.SetOccupiedPiece(0, 7, (Part)'N');
            myBoard.SetOccupiedPiece(2, 6, (Part)'B');
            myBoard.SetOccupiedPiece(3, 7, (Part)'R');
            myBoard.SetOccupiedPiece(1, 3, (Part)'K');
            myBoard.SetOccupiedPiece(0, 4, (Part)'R');
            myBoard.SetOccupiedPiece(7, 7, (Part)'K');

            Cell nextCell = myBoard.SetNextMove(1, 3);
            myBoard.ResetAllLegalMoves();
            myBoard.MarkNextLegalMoves(nextCell, nextCell.Piece);
            game.GetMoveCount();

            int actual = game.moveCount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectNumOfMovesFail()
        {
            int expected = 2;
            Game game = new Game();
            Board myBoard = new(8);
            myBoard.SetLevelName("Level1");
            myBoard.SetCurrentCell(1, 0);
            myBoard.WinCell(7, 7);
            // Sets the first piece and this piece is what the player will start as
            myBoard.SetOccupiedPiece(1, 0, (Part)'R');

            // Set pieces on board for the first level
            myBoard.SetOccupiedPiece(0, 7, (Part)'N');
            myBoard.SetOccupiedPiece(2, 6, (Part)'B');
            myBoard.SetOccupiedPiece(3, 7, (Part)'R');
            myBoard.SetOccupiedPiece(1, 3, (Part)'K');
            myBoard.SetOccupiedPiece(0, 4, (Part)'R');
            myBoard.SetOccupiedPiece(7, 7, (Part)'K');

            Cell nextCell = myBoard.SetNextMove(1, 3);
            myBoard.ResetAllLegalMoves();
            myBoard.MarkNextLegalMoves(nextCell, nextCell.Piece);
            game.GetMoveCount();

            int actual = game.moveCount;

            Assert.AreNotEqual(expected, actual);
        }
    }

    [TestClass]
    public class TestSelectPiece
    {
        private Game game = new();
        Cell SetMove(int row, int col)
        {
            game.Move(row, col);
            return game.GetPlayerCell();
        }

        [TestMethod]
        public void TestNextMove()
        {
            game.Start();
            Cell nextMove = SetMove(1, 3);

            int expectedCol = 3;
            int expectedRow = 1;
            int actualCol = nextMove.ColumnNumber;
            int actualRow = nextMove.RowNumber;
            Console.WriteLine("Col {0}, Row {1}", nextMove.ColumnNumber, nextMove.RowNumber);

            game.Start();

            Assert.AreEqual(expectedCol, actualCol);
            Assert.AreEqual(expectedRow, actualRow);
        }

        // This should fail because I am setting the next move to be an illegal move
        [TestMethod]
        public void TestNextMoveFail()
        {
            game.Start();
            Cell nextMove = SetMove(1, 2);

            int expectedCol = 1;
            int expectedRow = 3;
            int actualCol = nextMove.ColumnNumber;
            int actualRow = nextMove.RowNumber;
            Console.WriteLine("Col {0}, Row {1}", nextMove.ColumnNumber, nextMove.RowNumber);

            Assert.AreNotEqual(expectedCol, actualCol);
            Assert.AreNotEqual(expectedRow, actualRow);
        }
    }

    [TestClass]
    public class PieceMovement
    {
        Board myBoard = new(8);
        Board board(Part piece)
        {
            Board newBoard = myBoard;
            Cell newCell = newBoard.SetCurrentCell(3, 3);
            newCell.Piece = piece;
            newBoard.MarkNextLegalMoves(newCell, newCell.Piece);
            return newBoard;
        }
        [TestMethod]
        public void RookMove()
        {
            Board myBoard = board(Part.Rook);

            bool legalMove = myBoard.theGrid[0, 3].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[3, 2].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[3, 7].LegalNextMove;

            Assert.IsTrue(legalMove);
            Assert.IsTrue(legalMove2);
            Assert.IsTrue(legalMove3);
        }

        [TestMethod]
        public void RookMoveFail()
        {
            Board myBoard = board(Part.Rook);

            bool illLegalMove = myBoard.theGrid[7, 7].LegalNextMove;
            bool illLegalMove2 = myBoard.theGrid[1, 0].LegalNextMove;

            Assert.IsFalse(illLegalMove);
            Assert.IsFalse(illLegalMove2);
        }

        [TestMethod]
        public void BishopMove()
        {
            Board myBoard = board(Part.Bishop);

            bool legalMove = myBoard.theGrid[7, 7].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[0, 0].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[6, 0].LegalNextMove;

            Assert.IsTrue(legalMove);
            Assert.IsTrue(legalMove2);
            Assert.IsTrue(legalMove3);
        }

        [TestMethod]
        public void BishopMoveFail()
        {
            Board myBoard = board(Part.Bishop);

            bool illLegalMove = myBoard.theGrid[7, 6].LegalNextMove;
            bool illLegalMove2 = myBoard.theGrid[1, 0].LegalNextMove;
            bool illLegalMove3 = myBoard.theGrid[6, 2].LegalNextMove;

            Assert.IsFalse(illLegalMove);
            Assert.IsFalse(illLegalMove2);
            Assert.IsFalse(illLegalMove3);
        }

        [TestMethod]
        public void KingMove()
        {
            Board myBoard = board(Part.King);

            bool legalMove = myBoard.theGrid[3, 2].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[2, 2].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[2, 3].LegalNextMove;
            bool legalMove4 = myBoard.theGrid[2, 4].LegalNextMove;
            bool legalMove5 = myBoard.theGrid[4, 2].LegalNextMove;

            Assert.IsTrue(legalMove);
            Assert.IsTrue(legalMove2);
            Assert.IsTrue(legalMove3);
            Assert.IsTrue(legalMove4);
            Assert.IsTrue(legalMove5);
        }

        public void KingMoveFail()
        {
            Board myBoard = board(Part.King);

            bool legalMove = myBoard.theGrid[3, 3].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[2, 1].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[2, 4].LegalNextMove;
            bool legalMove4 = myBoard.theGrid[2, 3].LegalNextMove;
            bool legalMove5 = myBoard.theGrid[4, 1].LegalNextMove;

            Assert.IsFalse(legalMove);
            Assert.IsFalse(legalMove2);
            Assert.IsFalse(legalMove3);
            Assert.IsFalse(legalMove4);
            Assert.IsFalse(legalMove5);
        }

        [TestMethod]
        public void QueenMove()
        {
            Board myBoard = board(Part.Queen);

            bool legalMove = myBoard.theGrid[3, 2].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[2, 2].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[2, 3].LegalNextMove;
            bool legalMove4 = myBoard.theGrid[2, 4].LegalNextMove;
            bool legalMove5 = myBoard.theGrid[4, 2].LegalNextMove;

            Assert.IsTrue(legalMove);
            Assert.IsTrue(legalMove2);
            Assert.IsTrue(legalMove3);
            Assert.IsTrue(legalMove4);
            Assert.IsTrue(legalMove5);
        }

        [TestMethod]
        public void QueenMoveFail()
        {
            Board myBoard = board(Part.Queen);

            bool legalMove = myBoard.theGrid[2, 1].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[0, 2].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[2, 5].LegalNextMove;

            Assert.IsFalse(legalMove);
            Assert.IsFalse(legalMove2);
            Assert.IsFalse(legalMove3);
        }

        [TestMethod]
        public void KnightMove()
        {
            Board myBoard = board(Part.Knight);

            bool legalMove = myBoard.theGrid[2, 1].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[1, 2].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[1, 4].LegalNextMove;
            bool legalMove4 = myBoard.theGrid[2, 5].LegalNextMove;

            Assert.IsTrue(legalMove);
            Assert.IsTrue(legalMove2);
            Assert.IsTrue(legalMove3);
            Assert.IsTrue(legalMove4);
        }

        [TestMethod]
        public void KnightMoveFail()
        {
            Board myBoard = board(Part.Knight);

            bool legalMove = myBoard.theGrid[1, 1].LegalNextMove;
            bool legalMove2 = myBoard.theGrid[2, 2].LegalNextMove;
            bool legalMove3 = myBoard.theGrid[4, 0].LegalNextMove;
            bool legalMove4 = myBoard.theGrid[4, 4].LegalNextMove;

            Assert.IsFalse(legalMove);
            Assert.IsFalse(legalMove2);
            Assert.IsFalse(legalMove3);
            Assert.IsFalse(legalMove4);
        }
    }
}
