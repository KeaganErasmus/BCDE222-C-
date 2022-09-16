using ChessMaze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMazeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBoardSize()
        {
            int expected = 8;
            Board myBoard = new(8);

            int actual = myBoard.Size;

            Assert.AreEqual(expected, actual);
        }
    }
}
