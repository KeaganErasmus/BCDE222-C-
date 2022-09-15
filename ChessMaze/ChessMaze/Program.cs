using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    public class Program
    {
        static Board myBoard = new(8);
        static Game theGame = new();
        static void Main(string[] args)
        {
            theGame.Start();
        }
        public static void printBoard(Board myBoard)
        {
            // display chess board: 'X' = current piece, '+' = legal next move, * = empty
            for (int x = 0; x < myBoard.Size; x++)
            {
                for (int y = 0; y < myBoard.Size; y++)
                {
                    Cell c = myBoard.theGrid[x, y];

                    if (c == myBoard.playerCell)
                    {
                        Console.Write('X');

                    }
                    else if (c.CurrentlyOccupied == true)
                    {
                        // K, R, B, N
                        switch (c.Piece)
                        {
                            case (Part)'K':
                                Console.Write('K');
                                break;

                            case (Part)'R':
                                Console.Write('R');
                                break;

                            case (Part)'B':
                                Console.Write('B');
                                break;

                            case (Part)'N':
                                Console.Write('N');
                                break;

                            case (Part)'Q':
                                Console.Write('Q');
                                break;
                        }
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
