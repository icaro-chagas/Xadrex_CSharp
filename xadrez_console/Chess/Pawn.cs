using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class Pawn : Piece
    {

        private ChessMatch _chessMatch;

        public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            _chessMatch = chessMatch;
        }

        public bool HasEnemy(Position position)
        {
            Piece piece = Board.Piece(position);

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

                // Special move: En Passant
                if (Position.Row == 3)
                {
                    Position leftPosition = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsValidPosition(leftPosition) && HasEnemy(leftPosition) 
                        && Board.Piece(leftPosition) == _chessMatch.PieceEnPassant)
                    {
                        mat[leftPosition.Row - 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsValidPosition(rightPosition) && HasEnemy(rightPosition)
                        && Board.Piece(rightPosition) == _chessMatch.PieceEnPassant)
                    {
                        mat[rightPosition.Row - 1, rightPosition.Column] = true;
                    }
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

                // Special move: En Passant
                if (Position.Row == 4)
                {
                    Position leftPosition = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsValidPosition(leftPosition) && HasEnemy(leftPosition)
                        && Board.Piece(leftPosition) == _chessMatch.PieceEnPassant)
                    {
                        mat[leftPosition.Row + 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsValidPosition(rightPosition) && HasEnemy(rightPosition)
                        && Board.Piece(rightPosition) == _chessMatch.PieceEnPassant)
                    {
                        mat[rightPosition.Row + 1, rightPosition.Column] = true;
                    }
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
