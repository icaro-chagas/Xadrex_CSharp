using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        /*private bool IsValidMove(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }*/

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position auxPosition = new Position(0, 0);

            // Northweast
            auxPosition.SetValues(Position.Row - 1, Position.Column - 1);  
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.SetValues(auxPosition.Row - 1, auxPosition.Column - 1);
            }

            // Northeast
            auxPosition.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.SetValues(auxPosition.Row - 1, auxPosition.Column + 1);
            }

            // Southeast
            auxPosition.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.SetValues(auxPosition.Row + 1, auxPosition.Column + 1);
            }

            // Southwest
            auxPosition.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.SetValues(auxPosition.Row + 1, auxPosition.Column - 1);
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
