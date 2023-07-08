using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_king : APiece
{
    new public void Awake()
    {
        base.Awake();
        this.is_white = false;
        this.id_piece = ID_KING;
    }	
	
	public override List<ASquare> Squares_which_this_piece_see()
    {
        var letter = this.square.id_letter;
        var number = this.square.id_number;

        var result = new List<ASquare>();
        return result;
    }
	
	public override List<ASquare> Posible_moves()
    {
        var letter = this.square.id_letter;
        var number = this.square.id_number;

        var result = new List<ASquare>();
        return result;
    }
}
