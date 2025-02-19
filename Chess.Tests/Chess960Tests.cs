using Chess.Core;
using Chess.Core.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Tests
{
	public class Chess960Tests
    {
        [Fact]
        public void ArePiecesMirrored()
        {
            bool mirrored = true;

            Game.is960Selected = true;
            Board b = new Board(8, false);

            for (int i = 0; i < 8; i++) 
            {
                if(char.ToLower(b.GetPiece(0, i).Symbol) != char.ToLower(b.GetPiece(7, i).Symbol))
                {
                    mirrored = false;
                    break;
                }
            }

            Assert.True(mirrored);
        }

		[Fact]
		public void IsKingBetweenRooks_Once()
		{
            Assert.True(IsKingBetweenRooks());
		}

		[Fact]
		public void IsKingBetweenRooks_TenTimes()
		{
			Assert.All(Enumerable.Range(0, 10), _ => Assert.True(IsKingBetweenRooks()));
		}

		[Fact]
		public void IsKingBetweenRooks_HundredTimes()
		{
			Assert.All(Enumerable.Range(0, 100), _ => Assert.True(IsKingBetweenRooks()));
		}

		[Fact]
		public void AreBishopsOppositeTileColor_Once()
		{
			Assert.True(AreBishopsOppositeTileColor());
		}

		[Fact]
		public void AreBishopsOppositeTileColor_TenTimes()
		{
			Assert.All(Enumerable.Range(0, 10), _ => Assert.True(AreBishopsOppositeTileColor()));
		}

		[Fact]
		public void AreBishopsOppositeTileColor_HundredTimes()
		{
			Assert.All(Enumerable.Range(0, 100), _ => Assert.True(AreBishopsOppositeTileColor()));
		}

		#region HELPER METHODS

		private bool IsKingBetweenRooks()
		{
			bool betweenRooks = true;
			bool foundFirstRook = false;

			Game.is960Selected = true;
			Board b = new Board(8, false);

			for (int i = 0; i < 8; i++) // loop through columns on first row
			{
				char pieceSymbol = char.ToLower(b.GetPiece(0, i).Symbol);
				if (pieceSymbol == 'r')
				{
					if (foundFirstRook) // found both before king
					{
						betweenRooks = false;
						break;
					}
					foundFirstRook = true;
				}
				else if (pieceSymbol == 'k')
				{
					if (foundFirstRook)
					{
						break; // good to go
					}
					else // found king before any rooks
					{
						betweenRooks = false;
						break;
					}
				}
			}

			return betweenRooks;
		}

		private bool AreBishopsOppositeTileColor()
		{
			bool lightTile = false;
			bool darkTile = false;

			Game.is960Selected = true;
			Board b = new Board(8, false);

			for (int i = 0; i < 8; i++) // loop through columns on first row
			{
				IPiece piece = b.GetPiece(0, i);
				
				if(char.ToLower(piece.Symbol) == 'b') // is bishop
				{
					if(piece.CurrentLocation.Column % 2 == 0) // Even = Light Square
					{
						if (lightTile) return false; // found 2 light tile
						else lightTile = true;
					}
					else // Odd = Dark Square
					{
						if (darkTile) return false; // found 2 dark tile
						else darkTile = true;
					}
				}
			}

			return lightTile && darkTile;
		}

		#endregion
	}
}
