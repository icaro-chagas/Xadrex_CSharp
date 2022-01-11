namespace xadrez_console.Chessboard
{
    abstract class Piece
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

        public bool HasPossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            bool test = false;

            for (int i = 0; i < Board.Rows; i++) 
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        test = true;
                    }
                }
            }
            return test;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public void IncreaseNumberOfMoves()
        {
            NumberOfMoves++;
        }

        public void DecreaseNumberOfMoves()
        {
            NumberOfMoves--;
        }

        public abstract bool[,] PossibleMoves();

    }
}