using System;
using xadrez_console.Chess;
using xadrez_console.Chessboard;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition cPos = new ChessPosition('c', 7);


            Console.WriteLine(cPos);

            Console.WriteLine(cPos.ToPositon());
        }
    }
}
