using Chess.Core.Pieces;
using System;

namespace Chess.Core.Chess960
{
	internal static class Chess960Generator
	{
		private const int BOARD_SIZE = 8;

		/// <summary>
		/// Generates a Chess 960 config for the white back row with positions
		/// </summary>
		/// <returns>White piece array configured with position on each piece.</returns>
		public static Piece[] GenerateConfig()
		{
			Random rand = new Random();
			List<int> availableColumns = Enumerable.Range(0, 8).ToList();
			 
			// Bishops
			int columnNum = rand.Next(4) * 2; // Light Squares (0,2,4,6)
			Piece bishop1 = new Bishop('w', 7, columnNum);
			availableColumns.Remove(columnNum);

			columnNum = rand.Next(4) * 2 + 1; // Dark Squares (1,3,5,7)
			Piece bishop2 = new Bishop('w', 7, columnNum);
			availableColumns.Remove(columnNum);

			// Knights
			columnNum = availableColumns[rand.Next(availableColumns.Count)];
			Piece knight1 = new Knight('w', 7, columnNum);
			availableColumns.Remove(columnNum);

			columnNum = availableColumns[rand.Next(availableColumns.Count)];
			Piece knight2 = new Knight('w', 7, columnNum);
			availableColumns.Remove(columnNum);

			// queen
			columnNum = availableColumns[rand.Next(availableColumns.Count)];
			Piece queen = new Queen('w', 7, columnNum);
			availableColumns.Remove(columnNum);

			// for these last three, dont remove from available columns. there is only three left and we want to add them left to right so the king is always between rooks
			// rook1
			columnNum = availableColumns[0];
			Piece rook1 = new Rook('w', 7, columnNum);

			// king
			columnNum = availableColumns[1];
			Piece king = new King('w', 7, columnNum);

			// Rook 2
			columnNum = availableColumns[2];
			Piece rook2 = new Rook('w', 7, columnNum);


			Piece[] config = new Piece[8];

			config[0] = rook1;
			config[1] = rook2;
			config[2] = knight1;
			config[3] = knight2;
			config[4] = bishop1;
			config[5] = bishop2;
			config[6] = queen;
			config[7] = king;

			return config;
		}

		/// <summary>
		/// Get a black backrow config using a previously generated white config
		/// </summary>
		/// <param name="whiteConfig">White config generated with GenerateConfig()</param>
		/// <returns>Returns new Piece array containing black pieces on row index 7 instead of 0</returns>
		public static Piece[] GetBlackConfig(Piece[] whiteConfig)
		{
			Piece[] blackConfig = new Piece[whiteConfig.Length];
			for (int i = 0; i < blackConfig.Length; i++)
			{
				blackConfig[i] = whiteConfig[i].Clone();
				blackConfig[i].Color = 'b';
				blackConfig[i].CurrentLocation.Row = 0;
			}
			return blackConfig;
		}
	}
}
