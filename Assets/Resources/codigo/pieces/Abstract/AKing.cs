using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AKing : APiece, TMoved, TDirection
{
    public int squares_king_move_aside_castle = 2;
    public int squares_rook_move_aside_king_castle = 1;

    public bool moved { get; set; }
    public ADirection direction { get; set; }
    


    new public void Awake()
    {
        base.Awake();
        this.moved = false;
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

    public bool Check_can_castle_left()
    {
        if (!this.moved)
        {
            var squares_left = this.direction.Left_side(this);

            if (this.squares_king_move_aside_castle < squares_left.Length)
            {
                for (var i = 1; i <= this.squares_king_move_aside_castle; i++)
                {
                    var square_left = this.direction.Left_side(this, i);
                    if (!square_left || !this.Check_is_no_attacked_by_enemy(square_left) || square_left.piece)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            for (var i = this.squares_king_move_aside_castle + 1; i <= squares_left.Length; i++)
            {
                var square_left = this.direction.Left_side(this, i);

                // if it's the last square
                if (i == squares_left.Length)
                {
                    if (!square_left.piece || square_left.piece.is_white != this.is_white || !square_left.piece.GetComponent<ARook>() || square_left.piece.GetComponent<ARook>().moved)
                    {
                        return false;
                    }
                }
                // Its not the last square
                else
                {
                    if (square_left.piece)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Check_can_castle_right()
    {
        if (!this.moved)
        {
            var squares_right = this.direction.Right_side(this);

            if (this.squares_king_move_aside_castle < squares_right.Length)
            {
                for (var i = 1; i <= this.squares_king_move_aside_castle; i++)
                {
                    var square_right = this.direction.Right_side(this, i);
                    if (!square_right || !this.Check_is_no_attacked_by_enemy(square_right) || square_right.piece)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            for (var i = this.squares_king_move_aside_castle + 1; i <= squares_right.Length; i++)
            {
                var square_right = this.direction.Right_side(this, i);

                // if it's the last square
                if (i == squares_right.Length)
                {
                    if (!square_right.piece || square_right.piece.is_white != this.is_white || !square_right.piece.GetComponent<ARook>() || square_right.piece.GetComponent<ARook>().moved)
                    {
                        return false;
                    }
                }
                // Its not the last square
                else
                {
                    if (square_right.piece)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }


    public List<ASquare> Add_to_list_if_can_castle(List<ASquare> list)
    {
        if(list == null)
        {
            list = new List<ASquare>();
        }

        if(this.Check_can_castle_left())
        {
            list = this.pieces.board.Add_to_list_if_not_null(list, this.direction.Left_side(this, this.squares_king_move_aside_castle));
        }

        if (this.Check_can_castle_right())
        {
            list = this.pieces.board.Add_to_list_if_not_null(list, this.direction.Right_side(this, this.squares_king_move_aside_castle));
        }

        // Don't forget to do castle in ASquare onclick
        return list;
    }

    /// <summary>
    /// Check if the move is castle, if its the case, move the rook and return true, if not return false.
    /// The main use is when the user clicks on the King's square destination (after click this king)
    /// </summary>
    /// <param name="square_destination_king"></param>
    /// <returns></returns>
    public bool Move_rook_when_castle(ASquare square_destination_king)
    {
        if
            (
            square_destination_king && this.direction           
            )
        {
            if(this.direction.Left_side(this, this.squares_king_move_aside_castle) == square_destination_king)
            {
                var squares_left = this.direction.Left_side(this);
                // Get the piece in the last square, which should be a rook (because previous checks)
                var rook = squares_left[squares_left.Length - 1].piece;
                var square_destination_rook = this.direction.Right_side(square_destination_king, this.squares_rook_move_aside_king_castle);
                this.pieces.board.Piece_to_square(rook, square_destination_rook);
                return true;
            }
            else
            if (this.direction.Right_side(this, this.squares_king_move_aside_castle) == square_destination_king)
            {
                var squares_right = this.direction.Right_side(this);
                // Get the piece in the last square, which should be a rook (because previous checks)
                var rook = squares_right[squares_right.Length - 1].piece;
                var square_destination_rook = this.direction.Left_side(square_destination_king, this.squares_rook_move_aside_king_castle);
                this.pieces.board.Piece_to_square(rook, square_destination_rook);
                return true;
            }

            return false;
        }
        else
        {
            return false;
        }
    }

    public override void Default_values()
    {
        this.Awake();
    }
}