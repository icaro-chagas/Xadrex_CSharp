﻿using System;
using System.Collections.Generic;
using xadrez_console.Chess;
using xadrez_console.Chessboard;

namespace xadrez_console
{
    class Screen
    {
        public static void PrintMatch(ChessMatch chessMatch)
        {
            PrintBoard(chessMatch.Board);
            Console.WriteLine();

            PrintCapturedPieces(chessMatch);
            Console.WriteLine();

            Console.WriteLine("Turn: " + chessMatch.Turn);

            if (!chessMatch.Finished)
            {
                Console.WriteLine("Current Player: " + chessMatch.CurrentPlayer);

                if (chessMatch.Check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else 
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + chessMatch.CurrentPlayer);
            }
        }

        public static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured Pieces:");

            Console.Write("White: ");
            PrintPiecesSet(chessMatch.GetCapturedPiecesByColor(Color.White));
            Console.WriteLine();

            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintPiecesSet(chessMatch.GetCapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }

        public static void PrintPiecesSet(HashSet<Piece> piecesSet)
        {
            Console.Write("[");

            int count = 0;
            foreach (Piece p in piecesSet)
            {
                count++;
                if (count < piecesSet.Count)
                {
                    Console.Write(p + " ");
                }
                else
                {
                    Console.Write(p);
                }
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                { 
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor newColor = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalColor;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

            Console.BackgroundColor = originalColor;

        }

            public static ChessPosition ReadChessPosition()
        { 
            HashSet<char> validCharacters = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            HashSet<char> validNumbers = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8' };


            string s = Console.ReadLine().Trim();
            if (s.Length < 2)
            {
                throw new BoardException("Invalid format for piece source!");
            }
            else if (!validCharacters.Contains(s[0]) || !validNumbers.Contains(s[1]))
            {
                throw new BoardException("Invalid format for piece source!");
            }

            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }

        private HashSet<char> GetValidCharactersForReading()
        {
            HashSet<char> validCharacters = new HashSet<char>();
            validCharacters.Add('a');
            validCharacters.Add('b');
            validCharacters.Add('c');
            validCharacters.Add('d');
            validCharacters.Add('e');
            validCharacters.Add('f');
            validCharacters.Add('g');
            validCharacters.Add('h');

            return validCharacters;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

    }
}
