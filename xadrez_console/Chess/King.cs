using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        private bool IsValidMove(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position auxPosition = new Position(0, 0);

            // Above
            auxPosition.SetValues(Position.Row - 1, Position.Column);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // Northeast
            auxPosition.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // Right
            auxPosition.SetValues(Position.Row, Position.Column + 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // Southeast
            auxPosition.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // Below
            auxPosition.SetValues(Position.Row + 1, Position.Column);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // Southwest
            auxPosition.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // Left
            auxPosition.SetValues(Position.Row, Position.Column - 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            // Northwest
            auxPosition.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
