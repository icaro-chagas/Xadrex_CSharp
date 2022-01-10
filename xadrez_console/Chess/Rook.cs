using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
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
            while(Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition)) 
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.Row--;
            }

            // Below
            auxPosition.SetValues(Position.Row + 1, Position.Column);
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.Row++;
            }

            // Right
            auxPosition.SetValues(Position.Row, Position.Column + 1);
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.Column++;
            }

            // Left
            auxPosition.SetValues(Position.Row, Position.Column - 1);
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
            {
                mat[auxPosition.Row, auxPosition.Column] = true;
                if (Board.Piece(auxPosition) != null && Board.Piece(auxPosition).Color != Color)
                {
                    break;
                }
                auxPosition.Column--;
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }

    }
}
