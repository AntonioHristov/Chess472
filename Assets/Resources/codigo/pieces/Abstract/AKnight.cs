using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AKnight : ACan_be_promotion
{
    public override int id_piece { get; set; }

    new public void Awake()
    {
        base.Awake();
        this.id_piece = ID_KNIGHT;
    }

    public override List<ASquare> Squares_which_this_piece_see()
    {
        var letter = this.square.id_letter;
        var number = this.square.id_number;

        var result = new List<ASquare>();


        result.Add(this.square.Up_left(2,1));
        result.Add(this.square.Up_left(1,2));

        result.Add(this.square.Up_right(1,2));
        result.Add(this.square.Up_right(2,1));

        result.Add(this.square.Down_left(2, 1));
        result.Add(this.square.Down_left(1, 2));

        result.Add(this.square.Down_right(1, 2));
        result.Add(this.square.Down_right(2, 1));



        return result;
    }

    public override List<ASquare> Posible_moves()
    {
        var letter = this.square.id_letter;
        var number = this.square.id_number;

        var result = new List<ASquare>();

        foreach (ASquare square in this.Squares_which_this_piece_see())
        {
            result = this.pieces.board.Add_to_list_if_can_move(result, this, square);
        }

        return result;
    }

    public override void Default_values()
    {
        this.Awake();
    }
}