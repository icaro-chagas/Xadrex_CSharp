using System;
using xadrez_console.Chess;
using xadrez_console.Chessboard;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PlacePiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PlacePiece(new King(board, Color.Black), new Position(0, 2));

                board.PlacePiece(new Rook(board, Color.White), new Position(3, 5));
                board.PlacePiece(new Rook(board, Color.White), new Position(7, 7));
                board.PlacePiece(new King(board, Color.White), new Position(7, 2));

                Screen.PrintSreen(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
