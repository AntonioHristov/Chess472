using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AKing : APiece, TMoved
{
    public bool moved { get; set; }

    new public void Awake()
    {
        base.Awake();
    }

    public override List<ASquare> Squares_which_this_piece_see()
    {
        var result = new List<ASquare>();

        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Up(1));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Up_left(1,1));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Up_right(1,1));

        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Left(1));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Right(1));

        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Down(1));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Down_left(1, 1));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.square.Down_right(1, 1));

        return result;
    }

    public override List<ASquare> Posible_moves()
    {
        var result = new List<ASquare>();

        result = this.Add_to_list_if_can_move(result, this.Squares_which_this_piece_see().ToArray());
        result = this.Add_to_list_if_can_castle(result);

        return result;
    }

    public bool Check_is_no_attacked_by_enemy(ASquare square)
    {
        if(square == null)
        {
            return false;
        }
        else
        {
            foreach (APiece piece in square.attacked_by)
            {
                if(piece.is_white != this.is_white)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public List<ASquare> Add_to_list_if_can_move(List<ASquare> list, ASquare square)
    {
        if (list != null && square != null)
        {
            if( !square.piece && this.Check_is_no_attacked_by_enemy(square) )
            {
                list.Add(square);
            }
        }
        return list;
    }

    public List<ASquare> Add_to_list_if_can_move(List<ASquare> list, ASquare[] squares)
    {
        if (list != null && squares != null)
        {
            foreach (ASquare square in squares)
            {
                list = this.Add_to_list_if_can_move(list, square);
            }
        }
        return list;
    }

    public List<ASquare> Add_to_list_if_can_castle(List<ASquare> list)
    {
        if(list == null)
        {
            list = new List<ASquare>();
        }

        // Do Condition
        if (!this.moved )
        {
            // Add square castle and don't forget to do castle in ASquare onclick
        }
        return list;
    }

    public override void Default_values()
    {
        this.Awake();
    }
}