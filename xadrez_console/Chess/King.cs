using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class King : Piece
    {
        private ChessMatch _chessMatch;

        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            _chessMatch = chessMatch; 
        }

        public bool TestRookForCastling(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece != null && piece is Rook && piece.Color == Color && piece.NumberOfMoves == 0;
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

            // Special move: Castling

            if (NumberOfMoves == 0 && !_chessMatch.Check)
            {
                // Short Castling
                Position positionRook1 = new Position(Position.Row, Position.Column + 3);
                if (TestRookForCastling(positionRook1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    } 
                }

                // Long Castling
                Position positionRook2 = new Position(Position.Row, Position.Column - 4);
                if (TestRookForCastling(positionRook2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }

            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
