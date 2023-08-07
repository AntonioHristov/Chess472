using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARook : ACan_be_promotion, TMoved
{
    public bool moved { get; set; }
    new public void Awake()
    {
        base.Awake();
    }

    public override List<ASquare> Squares_which_this_piece_see()
    {
        var result = new List<ASquare>();

        if (!base.is_alive)
        {
            return result;
        }

        result = this.pieces.board.Add_to_list_if_can_see_without_jump(result, this, this.square.Up());
        result = this.pieces.board.Add_to_list_if_can_see_without_jump(result, this, this.square.Down());
        result = this.pieces.board.Add_to_list_if_can_see_without_jump(result, this, this.square.Left());
        result = this.pieces.board.Add_to_list_if_can_see_without_jump(result, this, this.square.Right());

        return result;
    }

    public override void Default_values()
    {
        this.Awake();
    }
}