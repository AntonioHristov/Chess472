using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class White_pawn : APiece
{

    new public void Awake() 
    {
        base.Awake();
        this.is_white = true;
        this.id_piece = ID_PAWN;
        //Image img = gameObject.AddComponent(typeof(Image)) as Image;
        //this.gameObject.GetComponent<Image>().sprite = Sprites.Get_white_pawn();
    }

    public override List<ASquare> Squares_which_this_piece_see()
    {
        var letter = this.square.id_letter;
        var number = this.square.id_number;

        var result = new List<ASquare>();

        result.Add(board.squares.Up_left(this.square, 1, 1));
        result.Add(board.squares.Up_right(this.square, 1, 1));

        return result;
    }

    public override List<ASquare> Posible_moves()
    {
        var result = new List<ASquare>();

  
        result = board.Add_to_list_if_can_move(result, this, board.squares.Up(this.square, 1));

        if( !this.moved )
        {
            result = board.Add_to_list_if_can_move(result, this, board.squares.Up(this.square, 2));
        }

        foreach (ASquare square in this.Squares_which_this_piece_see())
        {
            result = board.Add_to_list_if_can_capture(result, this, square);
        }

        result = board.Add_to_list_if_en_passant(result, this);

        return result;
    }
}
