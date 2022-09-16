using ChessMaze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.AreEqual(expected, actual);
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

            Assert.AreEqual(expected, actual);
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

            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class TestSelectPiece
    {
        [TestMethod]
        public void CorrectPiece()
        {
            Board myBoard = new(8);

            Cell currentCell =  myBoard.SetCurrentCell(1, 0);
            myBoard.SetOccupiedPiece(1, 0, (Part)'R');
            Cell expected = myBoard.playerCell;

            Cell actual = myBoard.playerCell;


            Assert.AreEqual(expected,actual);
        }
    }
}
