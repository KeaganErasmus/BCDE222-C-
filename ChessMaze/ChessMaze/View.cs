using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    class View: IView
    {
        public int DisplayMoveCount()
        {
            return 1;
        }
        public string End()
        {
            return "";
        }

        public void Start()
        {

        }
    }
}
