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
}
