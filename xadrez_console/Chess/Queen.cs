﻿using xadrez_console.Chessboard;

namespace xadrez_console.Chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position auxPosition = new Position(0, 0);

            // Above
            auxPosition.SetValues(Position.Row - 1, Position.Column);
            while (Board.IsValidPosition(auxPosition) && IsValidMove(auxPosition))
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
            return "Q";
        }
    }
}
