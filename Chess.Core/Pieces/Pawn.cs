using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pieces
{
    public class Pawn : Piece
    {
        public bool CompletedFirstMove { get; set; } = false;

        #region constructor

        public Pawn(char player) : base(player) { }

        #endregion

        #region public

        public override void GetValidMoves(Board board, Tile selTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(GetForwardMovement(board, selTile));
            CurrentValidMoves.AddRange(GetDiagnalMovement(board, selTile));

            //IgnoreFriendlies(CurrentValidMoves, (int)selTile.CurrentPiece.CurrentPlayer);
        }

        #endregion

        #region private
        // create method to get valid forward movement


        private List<Tile> GetForwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            if ((int)t.Piece.Player == 1)
            {
                // allow 1 space forward if the tile is empty
                try
                {
                    if (b.Tiles[t.Column - 1, t.Row].Piece == null)
                        validMoves.Add(b.Tiles[t.Column - 1, t.Row]);
                }
                catch { }

                // allow pawn to move 2 spaces on its first move
                if (t.Piece.CompletedFirstMove == false && // condition: first move has not been completed
                    b.Tiles[t.Column - 2, t.Row].Piece == null && // condition: tile 2 steps ahead is empty
                    b.Tiles[t.Column - 1, t.Row].Piece == null // condition: tile 1 step ahead isnt taken
                    )
                    validMoves.Add(b.Tiles[t.Column - 2, t.Row]);


            }
            else if ((int)t.Piece.Player == 2)
            {
                // allow 1 space forward if the tile is empty
                try
                {
                    if (b.Tiles[t.Column + 1, t.Row].Piece == null)
                        validMoves.Add(b.Tiles[t.Column + 1, t.Row]);
                }
                catch { }

                // allow pawn to move 2 spaces on its first move
                if (t.Piece.CompletedFirstMove == false && // condition: first move has not been completed
                    b.Tiles[t.Column + 2, t.Row].Piece == null && // condition: tile 2 steps ahead is empty
                    b.Tiles[t.Column + 1, t.Row].Piece == null // condition: tile 1 step ahead isnt taken
                    )
                    validMoves.Add(b.Tiles[t.Column + 2, t.Row]);
            }

            return validMoves;
        }
        private List<Tile> GetDiagnalMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            // player 1
            if ((int)t.Piece.Player == 1)
            {
                if (t.Column > 0)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (b.Tiles[t.Column - 1, t.Row - 1].Piece is Piece &&
                        (int)b.Tiles[t.Column - 1, t.Row - 1].Piece.CurrPlayer == 2)
                            validMoves.Add(b.Tiles[t.Column - 1, t.Row - 1]);
                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // enemy at right diagnal -> valid kill
                        if (b.Tiles[t.Column - 1, t.Row + 1].Piece is Piece &&
                        (int)b.Tiles[t.Column - 1, t.Row + 1].Piece.CurrPlayer == 2)
                            validMoves.Add(b.Tiles[t.Column - 1, t.Row + 1]);
                    }
                    catch { } // ignore exception 
                }
            }
            //player 2
            else if ((int)t.Piece.Player == 2)
            {
                if (t.Column < 7)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (b.Tiles[t.Column + 1, t.Row + 1].Piece is Piece &&
                        (int)b.Tiles[t.Column + 1, t.Row + 1].Piece.CurrPlayer == 1)
                            validMoves.Add(b.Tiles[t.Column + 1, t.Row + 1]);
                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are right diagnal of pawn, allow them to kill
                        if (b.Tiles[t.Column + 1, t.Row - 1].Piece is Piece &&
                            (int)b.Tiles[t.Column + 1, t.Row - 1].Piece.CurrPlayer == 1)
                            validMoves.Add(b.Tiles[t.Column + 1, t.Row - 1]);
                    }
                    catch { } // ignore exception 
                }
            }

            return validMoves;
        }

        #endregion
    }
}
