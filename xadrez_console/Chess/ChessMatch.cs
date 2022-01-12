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
        public bool Check { get; private set; }


        public ChessMatch()
        {
            Board = new Board(NumberOfRows, NumberOfColums);
            Turn = InitialTurn;
            CurrentPlayer = Color.White;
            Finished = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            Check = false;

            PlacePieces();
        }
         
        public Piece PerformMove(Position source, Position target)
        {
            Piece piece = Board.RemovePiece(source);
            piece.IncreaseNumberOfMoves();

            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(piece, target);

            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMove(Position source, Position target, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(target);
            piece.DecreaseNumberOfMoves();

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                _capturedPieces.Remove(capturedPiece);
            }
            Board.PlacePiece(piece, source);
        }

        public void UpdateMatch(Position source, Position target)
        {
            Piece capturedPiece = PerformMove(source, target);

            if (TestCheckByColor(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new BoardException("You cannot put yourself in check.");
            }

            if (TestCheckByColor(GetOpposingColor(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheckmate(GetOpposingColor(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            { 
                Turn++;
                ChangePlayer();
            }

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

            foreach (Piece p in _pieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(GetCapturedPiecesByColor(color));

            return aux;
        }

        private Color GetOpposingColor(Color color)
        {
            Color opposingColor;
            if (color == Color.White)
            {
                opposingColor = Color.Black;
            }
            else
            {
                opposingColor = Color.White;
            }

            return opposingColor; 
        }

        private Piece GetKingByColor(Color color)
        {
            Piece king = null;
            foreach (Piece p in GetPiecesInGameByColor(color))
            {
                if (p is King)
                {
                    king = p;
                    break;
                }
            }
            return king;
        }

        private bool TestCheckByColor(Color color)
        {
            Piece king = GetKingByColor(color);

            if (king == null)
            {
                throw new BoardException($"There is no {color} king on the board.");
            }

            bool test = false;
            foreach (Piece p in GetPiecesInGameByColor(GetOpposingColor(color)))
            {
                bool[,] mat = p.PossibleMoves();
                if (mat[king.Position.Row, king.Position.Column])
                {
                    test = true;
                    break;
                }

            }

            return test;
        }

        public bool TestCheckmate(Color color)
        {
            if (!TestCheckByColor(color))
            {
                return false;
            }

            foreach (Piece p in GetPiecesInGameByColor(color))
            {
                bool[,] mat = p.PossibleMoves();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position source = p.Position;
                            Position target = new Position(i, j);
                            Piece capturedPiece = PerformMove(source, target);
                            bool testCheck = TestCheckByColor(color);
                            UndoMove(source, target, capturedPiece);

                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPositon());
            _pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White));

            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black));
        }


    }
}
