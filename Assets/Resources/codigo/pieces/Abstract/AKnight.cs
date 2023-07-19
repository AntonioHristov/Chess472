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
        // Try to implement this, test it and dont forget to test the promotion
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

    public override void Default_values()
    {
        this.Awake();
    }
}