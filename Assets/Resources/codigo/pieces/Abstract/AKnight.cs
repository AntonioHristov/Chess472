using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AKnight : ACan_be_promotion
{
    new public void Awake()
    {
        base.Awake();
    }

    public override List<ASquare> Squares_which_this_piece_see()
    {
        var result = new List<ASquare>();

        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Up_left(1, 2));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Up_left(2, 1));

        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Up_right(1, 2));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Up_right(2, 1));

        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Down_left(1, 2));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Down_left(2, 1));

        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Down_right(1, 2));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Down_right(2, 1));

        return result;
    }

    public override List<ASquare> Posible_moves()
    {
        return this.pieces.board.Add_to_list_if_can_move(new List<ASquare>(), this, this.Squares_which_this_piece_see().ToArray() );
    }

    public override void Default_values()
    {
        this.Awake();
    }
}