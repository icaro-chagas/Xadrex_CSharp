using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.Chessboard
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return Row + ", " + Column;
        }
    }
}
