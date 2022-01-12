using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        /*private bool IsValidMove(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }*/

        public bool HasEnemy(Position position)
        {
            Piece piece = Board.Piece(Position);

            return piece != null && piece.Color != Color;
        }

        public bool IsFreePosition(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position auxPosition = new Position(0, 0);
            Position auxPosition2;

            if (Color == Color.White)
            {
                auxPosition.SetValues(Position.Row - 1, Position.Column);
                if (Board.IsValidPosition(auxPosition) && IsFreePosition(auxPosition))
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }

                auxPosition.SetValues(Position.Row - 2, Position.Column);
                auxPosition2 = new Position(Position.Row - 1, Position.Column);
                if (Board.IsValidPosition(auxPosition2) && IsFreePosition(auxPosition2) && 
                    Board.IsValidPosition(auxPosition) && IsFreePosition(auxPosition) 
                    && NumberOfMoves == 0)
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }

                auxPosition.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsValidPosition(auxPosition) && HasEnemy(auxPosition))
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }

                auxPosition.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsValidPosition(auxPosition) && HasEnemy(auxPosition))
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }
            }
            else
            {
                auxPosition.SetValues(Position.Row + 1, Position.Column);
                if (Board.IsValidPosition(auxPosition) && IsFreePosition(auxPosition))
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }

                auxPosition.SetValues(Position.Row + 2, Position.Column);
                auxPosition2 = new Position(Position.Row + 1, Position.Column);
                if (Board.IsValidPosition(auxPosition2) && IsFreePosition(auxPosition2) &&
                    Board.IsValidPosition(auxPosition) && IsFreePosition(auxPosition)
                    && NumberOfMoves == 0)
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }

                auxPosition.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsValidPosition(auxPosition) && HasEnemy(auxPosition))
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }

                auxPosition.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsValidPosition(auxPosition) && HasEnemy(auxPosition))
                {
                    mat[auxPosition.Row, auxPosition.Column] = true;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
