using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessMaze;

namespace ChessMaze
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextMove { get; set; }

        public bool playerCell;

        public Part Piece { get; set; }

        // This code is to make Sam's model to work with  my view
        //public bool isValid(int size)
        //{
        //    if ((this.ColumnNumber >= 0 & this.ColumnNumber < size) & (this.RowNumber >= 0 & this.RowNumber < size))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        this.LegalNextMove = false;
        //        return false;
        //    }
        //}

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}