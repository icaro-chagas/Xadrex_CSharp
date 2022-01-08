using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position ToPositon()
        {
            return new Position(8 - Row, Column - 'a'); 
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
