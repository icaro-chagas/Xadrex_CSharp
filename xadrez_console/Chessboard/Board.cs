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

        public void PlacePiece(Piece piece, Position position)
        {
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}
