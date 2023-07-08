using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pieces : MonoBehaviour
{
    public APiece[] all { get; set; }

    public APiece[] Get_alive()
    {
        var result = new List<APiece>();
        foreach (APiece piece in all)
        {
            if (piece.is_alive)
            {
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    /*
    public void Default_pieces()
    {
        pieces = null;
        New_piece(new White_pawn(), 8);
        New_piece(new White_knight(), 2);
        New_piece(new White_bishop(), 2);
        New_piece(new White_rook(), 2);
        New_piece(new White_queen(), 1);
        New_piece(new White_king(), 1);

        New_piece(new Black_pawn(), 8);
        New_piece(new Black_knight(), 2);
        New_piece(new Black_bishop(), 2);
        New_piece(new Black_rook(), 2);
        New_piece(new Black_queen(), 1);
        New_piece(new Black_king(), 1);
    }
    */

    void Awake()
    {
        all = this.GetComponentsInChildren<APiece>();
    }
}
