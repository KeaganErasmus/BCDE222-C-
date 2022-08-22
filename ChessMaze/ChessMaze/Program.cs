using ChessBoardModel;

namespace ChessMaze
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            // show empty board
            printBoard(myBoard);


            Console.ReadLine();
        }

        private static void printBoard(Board myBoard)
        {
            // display chess board: 'X' = current piece, '+' = legal next move, E = empty
            for (int x = 0; x < myBoard.Size; x++)
            {
                for (int y = 0; y < myBoard.Size; y++)
                {
                    Cell c = myBoard.theGrid[x, y];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write('X');
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write('+');
                    }
                    else
                    {
                        Console.Write("e");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("====================");
        }
    }
}