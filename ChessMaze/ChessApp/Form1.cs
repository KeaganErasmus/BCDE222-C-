using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessForm
{
    public partial class Form1 : Form
    {
        public int[,] clickedCell { get; set; }
        public GameController Controller;

        public Form1()
        {
            InitializeComponent();
        }

        public void Start(int startCol, int startRow, int endCol, int endRow)
        {
            clickedCell = new int[1,2] { { startRow, startCol } };

            EndMessage.Text = "";

            UpdateMoveCount(0);

            foreach (Control control in ChessBoard.Controls)
            {
                PictureBox piece = control as PictureBox;

                // Higlights the starting peice
                if (this.ChessBoard.GetRow(piece) == startRow && this.ChessBoard.GetColumn(piece) == startCol)
                {
                    piece.BackColor = Color.Red;
                }
                // Highlights the peice to complete the maze
                else if (this.ChessBoard.GetRow(piece) == endRow && this.ChessBoard.GetColumn(piece) == endCol)
                {
                    piece.BackColor = Color.Orange;
                }
                else
                {
                    piece.BackColor = Color.Gray;
                }
            }
        }

        public void NextMove(int[,] prevCell)
        {
            foreach (Control control in ChessBoard.Controls)
            {
                PictureBox piece = control as PictureBox;
                if (ChessBoard.GetRow(piece) == clickedCell[0,0] && ChessBoard.GetColumn(piece) == clickedCell[0, 1])
                {
                    piece.BackColor = Color.AliceBlue;
                }
                else if (ChessBoard.GetRow(piece) == prevCell[0, 0] && ChessBoard.GetColumn(piece) == prevCell[0, 1])
                {
                    piece.BackColor = Color.FromArgb( 200, 230, 255 );
                }
            }
        }

        public void UpdateMoveCount(int MoveCount)
        {
            MovesLabel.Text = MoveCount.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int pieceCol = getColumn(sender);
            int pieceRow = getRow(sender);
            clickedCell = new int[1, 2] { { pieceRow, pieceCol } }; ;
            Controller.NextMove();
        }

        private int getColumn(object sender)
        {
            PictureBox clickedPiece = sender as PictureBox;
            int pieceCol = this.ChessBoard.GetColumn(clickedPiece);
            Trace.WriteLine($"Piece Column: {pieceCol}");

            return pieceCol;
        }

        private int getRow(object sender)
        {
            PictureBox clickedPiece = sender as PictureBox;
            int pieceRow = this.ChessBoard.GetRow(clickedPiece);
            Trace.WriteLine($"Piece Row: {pieceRow}");

            return pieceRow;
        }

        public void SetController(GameController controller)
        {
            Controller = controller;
        }

        private void start_game_Click(object sender, EventArgs e)
        {
            Controller.Go();
            Button button = sender as Button;
            button.Text = "Reset";
        }

        public void EndGame()
        {
            EndMessage.Text = "You have completed the maze";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Controller.SetLevelName("Chess Maze-1");
        }

    }
}
