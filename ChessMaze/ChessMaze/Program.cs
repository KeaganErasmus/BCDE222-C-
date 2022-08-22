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

            Cell currentCell = setCurrentCell();
            currentCell.CurrentlyOccupied = true;

            myBoard.MarkNextLegalMoves(currentCell, Part.PlayerOnKing);

            printBoard(myBoard);

            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            // get user x and y
            Console.WriteLine("entert row number");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("entert col number");
            int currentCol = int.Parse(Console.ReadLine());

            return myBoard.theGrid[currentRow, currentCol];
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
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("====================");
        }
    }
}