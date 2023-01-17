using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    interface IView
    {
        int DisplayMoveCount();
        string End();
        void Start();
    }
}
