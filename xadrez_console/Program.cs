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
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    Console.WriteLine();

                    Console.Write("Source: ");
                    Position source = Screen.ReadChessPosition().ToPositon();

                    bool[,] possiblePositions = match.Board.Piece(source).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Target: ");
                    Position target = Screen.ReadChessPosition().ToPositon();

                    
                    match.PerformMovement(source, target);

                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
