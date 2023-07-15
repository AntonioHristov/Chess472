using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APawn : APiece
{
    public abstract ADirection direction { get; set; }
    public override int id_piece { get; set; } // = ID_PAWN; etc
    public bool is_en_passant_target { get; set; }
    public bool moved { get; set; }


    new public void Awake()
    {
        base.Awake();
        //this.is_white = true;
        this.id_piece = ID_PAWN;
        this.is_en_passant_target = false;
        this.moved = false;
        
        //Image img = gameObject.AddComponent(typeof(Image)) as Image;
        //this.gameObject.GetComponent<Image>().sprite = Sprites.Get_white_pawn();
    }

    public void Start()
    {

    }



    public override List<ASquare> Squares_which_this_piece_see()
    {
        var letter = this.square.id_letter;
        var number = this.square.id_number;

        var result = new List<ASquare>();

        if ( this.direction == null)
        {
            return result;
        }

        if (this.direction.Check_id_is_up())
        {
            result.Add(this.pieces.board.squares.Up_left(this.square, 1, 1));
            result.Add(this.pieces.board.squares.Up_right(this.square, 1, 1));
        }
        else
        if (this.direction.Check_id_is_down())
        {
            result.Add(this.pieces.board.squares.Down_left(this.square, 1, 1));
            result.Add(this.pieces.board.squares.Down_right(this.square, 1, 1));
        }
        else
        if (this.direction.Check_id_is_left())
        {
            result.Add(this.pieces.board.squares.Up_left(this.square, 1, 1));
            result.Add(this.pieces.board.squares.Down_left(this.square, 1, 1));
        }
        else
        //if (this.direction.Check_id_is_right())
        {
            result.Add(this.pieces.board.squares.Up_right(this.square, 1, 1));
            result.Add(this.pieces.board.squares.Down_right(this.square, 1, 1));
        }



        return result;
    }

    public override List<ASquare> Posible_moves()
    {
        var result = new List<ASquare>();

        result = this.pieces.board.Add_to_list_if_can_move(result, this, this.direction.Forward(this.square, 1));

        if (!this.moved)
        {
            result = this.pieces.board.Add_to_list_if_can_move(result, this, this.direction.Forward(this.square, 2));
        }

        foreach (ASquare square in this.Squares_which_this_piece_see())
        {
            result = this.pieces.board.Add_to_list_if_can_capture(result, this, square);
        }

        result = this.Add_to_list_if_en_passant(result);

        return result;
    }

    /// <summary>
    /// Add to list the square where you can move only if en passant. 
    /// The main use is adding the square en passant in a list for posible moves.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public List<ASquare> Add_to_list_if_en_passant(List<ASquare> list)
    {
        if (this != null && this.square != null && this.direction != null)
        {
            var posible_squares_piece = new List<ASquare>();

            if (this.direction.Check_id_is_up() || this.direction.Check_id_is_down())
            {
                posible_squares_piece.Add(this.square.squares.Left(this.square, 1));
                posible_squares_piece.Add(this.square.squares.Right(this.square, 1));
            }
            else //if (pawn.direction.Check_id_is_left() || pawn.direction.Check_id_is_right())
            {
                posible_squares_piece.Add(this.square.squares.Up(this.square, 1));
                posible_squares_piece.Add(this.square.squares.Down(this.square, 1));
            }
            foreach (ASquare square_target_piece in posible_squares_piece)
            {
                if (square_target_piece != null && square_target_piece.piece != null && square_target_piece.piece.GetComponent<APawn>() != null && square_target_piece.piece.GetComponent<APawn>().is_en_passant_target)
                {
                    list.Add(this.direction.Forward(square_target_piece, 1));
                } 
            }
        }
        return list;
    }

    /// <summary>
    /// Try to capture the target pawn en passant, and return if can do it or not
    /// The main use is when the user clicks on the square destination en passant when is enabled (after click this pawn)
    /// </summary>
    /// <param name="square_destination">Square which this pawn will be after capture en passant</param>
    /// <returns></returns>
    public bool Try_capture_en_passant(ASquare square_destination)
    {
        // if move chosen is en passant, capture the pawn target
        if
            (
            square_destination && this.direction &&
            this.direction.Forward(square_destination, -1) &&
            this.direction.Forward(square_destination, -1).piece &&
            this.direction.Forward(square_destination, -1).piece.GetComponent<APawn>() &&
            this.direction.Forward(square_destination, -1).piece.GetComponent<APawn>().is_en_passant_target
            )
        {
            this.direction.Forward(square_destination, -1).piece.Die();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Is_en_passant_target(ASquare square_destination)
    {
        // if pawn's first move and go 2 squares, is a target for en passant
        if ( square_destination && !this.moved && this.direction.Forward(this.square, 2) == square_destination)
        {
            this.is_en_passant_target = true;
        }
        else
        {
            this.is_en_passant_target = false;
        }
        return this.is_en_passant_target;
    }

   

    public void Open_box_promotion()
    {
        this.pieces.board.game.boxes.Get_box_promote().Show(this);
    }

    public void Open_box_confirm_promotion(APawn pawn, Sprite sprite_promotion)
    {
        this.pieces.board.game.boxes.Get_box_confirm_promotion().Show();
    }


    public void Default_values()
    {
        this.Awake();
    }
}
