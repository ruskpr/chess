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

            IgnoreKing(CurrentValidMoves);
            //IgnoreFriendlies(CurrentValidMoves, (int)selTile.CurrentPiece.CurrentPlayer);
        }

        #endregion

        #region private

        private List<Tile> GetForwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            if ((int)t.CurrPiece.Player == 1)
            {
                // allow 1 space forward if the tile is empty
                try
                {
                    if (b._tiles[t.Y - 1, t.X].CurrPiece == null)
                        validMoves.Add(b._tiles[t.Y - 1, t.X]);
                }
                catch { }

                // allow pawn to move 2 spaces on its first move
                if (t.CurrPiece.CompletedFirstMove == false && // condition: first move has not been completed
                    b._tiles[t.Y - 2, t.X].CurrPiece == null && // condition: tile 2 steps ahead is empty
                    b._tiles[t.Y - 1, t.X].CurrPiece == null // condition: tile 1 step ahead isnt taken
                    )
                    validMoves.Add(b._tiles[t.Y - 2, t.X]);


            }
            else if ((int)t.CurrPiece.Player == 2)
            {
                // allow 1 space forward if the tile is empty
                try
                {
                    if (b._tiles[t.Y + 1, t.X].CurrPiece == null)
                        validMoves.Add(b._tiles[t.Y + 1, t.X]);
                }
                catch { }

                // allow pawn to move 2 spaces on its first move
                if (t.CurrPiece.CompletedFirstMove == false && // condition: first move has not been completed
                    b._tiles[t.Y + 2, t.X].CurrPiece == null && // condition: tile 2 steps ahead is empty
                    b._tiles[t.Y + 1, t.X].CurrPiece == null // condition: tile 1 step ahead isnt taken
                    )
                    validMoves.Add(b._tiles[t.Y + 2, t.X]);
            }

            return validMoves;
        }
        private List<Tile> GetDiagnalMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            // player 1
            if ((int)t.CurrPiece.Player == 1)
            {
                if (t.Y > 0)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (b._tiles[t.Y - 1, t.X - 1].CurrPiece is Piece &&
                        (int)b._tiles[t.Y - 1, t.X - 1].CurrPiece.CurrPlayer == 2)
                            validMoves.Add(b._tiles[t.Y - 1, t.X - 1]);
                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // enemy at right diagnal -> valid kill
                        if (b._tiles[t.Y - 1, t.X + 1].CurrPiece is Piece &&
                        (int)b._tiles[t.Y - 1, t.X + 1].CurrPiece.CurrPlayer == 2)
                            validMoves.Add(b._tiles[t.Y - 1, t.X + 1]);
                    }
                    catch { } // ignore exception 
                }
            }
            //player 2
            else if ((int)t.CurrPiece.Player == 2)
            {
                if (t.Y < 7)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (b._tiles[t.Y + 1, t.X + 1].CurrPiece is Piece &&
                        (int)b._tiles[t.Y + 1, t.X + 1].CurrPiece.CurrPlayer == 1)
                            validMoves.Add(b._tiles[t.Y + 1, t.X + 1]);
                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are right diagnal of pawn, allow them to kill
                        if (b._tiles[t.Y + 1, t.X - 1].CurrPiece is Piece &&
                            (int)b._tiles[t.Y + 1, t.X - 1].CurrPiece.CurrPlayer == 1)
                            validMoves.Add(b._tiles[t.Y + 1, t.X - 1]);
                    }
                    catch { } // ignore exception 
                }
            }

            return validMoves;
        }

        #endregion
    }
}
