using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position auxPosition = new Position(0, 0);
            
            /*
             Up: U
             Right: R
             Left: L
             Down: D
            */

            // U-L-L
            auxPosition.SetValues(Position.Row - 1, Position.Column - 2);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // U-U-L
            auxPosition.SetValues(Position.Row - 2, Position.Column - 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // U-U-R
            auxPosition.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // U-R-R
            auxPosition.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // D-R-R
            auxPosition.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // D-D-R
            auxPosition.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // D-D-L
            auxPosition.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // D-L-L
            auxPosition.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }



            return mat;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}
