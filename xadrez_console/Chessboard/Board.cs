using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.Chessboard
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private readonly Piece[,] _pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _pieces = new Piece[Rows, Columns]; 
        }

        public Piece Piece(int row, int column)
        {
            return _pieces[row, column];
        }


        public Piece Piece(Position position)
        {
            return _pieces[position.Row, position.Column];
        }


        public bool HasPiece(Position position)
        {
            ValidatePosition(position);

            return Piece(position) != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (HasPiece(position))
            {
                throw new BoardException("There is already a piece in this position!");
            }
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            Piece piece;
            if (Piece(position) == null)
            {
                piece = null;
            }
            else
            {
                piece = Piece(position);
                piece.Position = null;

                _pieces[position.Row, position.Column] = null;
            }

            return piece;
        }

            public bool IsValidPosition(Position position)
        {
            bool test = true;
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                test = false;
            }

            return test;
        }

        public void ValidatePosition(Position position)
        {
            if (!IsValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
