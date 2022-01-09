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
        private int _turn;
        private Color _currentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(NumberOfRows, NumberOfColums);
            _turn = InitialTurn;
            _currentPlayer = Color.White;
            Finished = false;

            PlacePieces();
        }
         
        public void PerformMovement(Position source, Position target)
        {
            Piece piece = Board.RemovePiece(source);
            piece.IncreaseNumberOfMoves();

            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(piece, target);
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
