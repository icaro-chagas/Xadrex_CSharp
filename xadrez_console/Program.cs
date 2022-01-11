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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Source: ");
                        Position source = Screen.ReadChessPosition().ToPositon();
                        match.ValidadeSourcePosition(source);

                        bool[,] possiblePositions = match.Board.Piece(source).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Target: ");
                        Position target = Screen.ReadChessPosition().ToPositon();
                        match.ValidadeTargetPosition(source, target);


                        match.UpdateMatch(source, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message + "\n");
                        Console.Write("\nPress Enter to continue! ");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
