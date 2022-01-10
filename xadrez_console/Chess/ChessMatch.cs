using System;
using xadrez_console.Chessboard;

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

        public ChessMatch()
        {
            Board = new Board(NumberOfRows, NumberOfColums);
            Turn = InitialTurn;
            CurrentPlayer = Color.White;
            Finished = false;

            PlacePieces();
        }
         
        public void PerformMove(Position source, Position target)
        {
            Piece piece = Board.RemovePiece(source);
            piece.IncreaseNumberOfMoves();

            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(piece, target);
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

        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 1).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPositon());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPositon());

            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPositon());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPositon());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPositon());

        }


    }
}
