using ChessBoardModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessMazeTest
{
    [TestClass]
    public class TestBoardSize
    {
        [TestMethod]
        public void TestCorrectBoardSize()
        {
            Board myBoard = new Board(8);
            int expected = 8;

            int boardSize = myBoard.Size;

            Assert.AreEqual(expected, boardSize);
        }

        [TestMethod]
        public void TestCorrectCoordinates()
        {
            Board myBoard = new Board(8);
            Cell expected = myBoard.SetCurrentCell(0, 0);


            Cell actual = myBoard.SetCurrentCell(0, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}
