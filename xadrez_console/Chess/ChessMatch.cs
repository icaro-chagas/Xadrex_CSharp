using System;
using xadrez_console.Chessboard;
using System.Collections.Generic;

namespace xadrez_console.Chess
{
    class ChessMatch
    {
        private const int NumberOfRows = 8;
        private const int NumberOfColums = 8;
        private const int InitialTurn = 1;

        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public ChessMatch()
        {
            Board = new Board(NumberOfRows, NumberOfColums);
            Turn = InitialTurn;
            CurrentPlayer = Color.White;
            Finished = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();

            PlacePieces();
        }
         
        public void PerformMove(Position source, Position target)
        {
            Piece piece = Board.RemovePiece(source);
            piece.IncreaseNumberOfMoves();

            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(piece, target);

            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
        }

        public void UpdateMatch(Position source, Position target)
        {
            PerformMove(source, target);
            Turn++;

            ChangePlayer();

        }

        public void ValidadeSourcePosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in the chosen source position!");
            }

            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The chosen source piece is not yours!");
            }

            if (!Board.Piece(position).HasPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen source piece!");
            }
        }

        public void ValidadeTargetPosition(Position source, Position target)
        {
            if (!Board.Piece(source).CanMoveTo(target))
            {
                throw new BoardException("Invalid target position!");
            }
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> GetCapturedPiecesByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece p in _capturedPieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Piece> GetPiecesInGameByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece p in _capturedPieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(GetCapturedPiecesByColor(color));

            return aux;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPositon());
            _pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            PlaceNewPiece('c', 2, new Rook(Board, Color.White));
            PlaceNewPiece('d', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 1, new Rook(Board, Color.White));
            PlaceNewPiece('d', 1, new King(Board, Color.White));

            PlaceNewPiece('c', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('c', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 8, new King(Board, Color.Black));

        }


    }
}
