using System;

namespace xadrez_console.Chessboard
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        {
        }
    }
}
