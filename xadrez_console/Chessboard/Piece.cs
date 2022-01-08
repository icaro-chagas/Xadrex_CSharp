namespace xadrez_console.Chessboard
{
    class Piece
    {
        public Position Position { get; set; }
        public Board Board { get; set; }
        public int NumberOfMoves { get; protected set; }
        public Color Color { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumberOfMoves = 0; 
        }
    }
}
