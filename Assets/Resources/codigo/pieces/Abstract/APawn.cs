using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        if (this.Check_is_promoted())
        {
            return result;
        }

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

        if (this.Check_is_promoted())
        {
            return result;
        }

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
        if (this && !this.Check_is_promoted() && this.square && this.direction)
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
            !this.Check_is_promoted() && square_destination && this.direction &&
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
        if (!this.Check_is_promoted() && square_destination && !this.moved && this.direction.Forward(this.square, 2) == square_destination)
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

    public void Open_box_confirm_promotion(Sprite sprite_promotion)
    {
        this.pieces.board.game.boxes.Get_box_confirm_promotion().Show(this, sprite_promotion);
    }

    #region Add component promotion

    // FIXME. Try to find the way to not repeat that same code

    public void Add_component_promotion(Sprite sprite_promotion)
    {
        if (sprite_promotion == Sprites.Get_white_queen())
        {
            this.gameObject.AddComponent<White_queen>();
            this.GetComponent<White_queen>().is_promoted = true;
            this.GetComponent<White_queen>().square = this.square;
            this.GetComponent<White_queen>().square.piece = this.GetComponent<White_queen>();
        }
        else if (sprite_promotion == Sprites.Get_white_rook())
        {
            this.gameObject.AddComponent<White_rook>();
            this.GetComponent<White_rook>().is_promoted = true;
            this.GetComponent<White_rook>().square = this.square;
            this.GetComponent<White_rook>().square.piece = this.GetComponent<White_rook>();
        }
        else if (sprite_promotion == Sprites.Get_white_bishop())
        {
            this.gameObject.AddComponent<White_bishop>();
            this.GetComponent<White_bishop>().is_promoted = true;
            this.GetComponent<White_bishop>().square = this.square;
            this.GetComponent<White_bishop>().square.piece = this.GetComponent<White_bishop>();
        }
        else if (sprite_promotion == Sprites.Get_white_knight())
        {
            this.gameObject.AddComponent<White_knight>();
            this.GetComponent<White_knight>().is_promoted = true;
            this.GetComponent<White_knight>().square = this.square;
            this.GetComponent<White_knight>().square.piece = this.GetComponent<White_knight>();
        }
        else if (sprite_promotion == Sprites.Get_black_queen())
        {
            this.gameObject.AddComponent<Black_queen>();
            this.GetComponent<Black_queen>().is_promoted = true;
            this.GetComponent<Black_queen>().square = this.square;
            this.GetComponent<Black_queen>().square.piece = this.GetComponent<Black_queen>();
        }
        else if (sprite_promotion == Sprites.Get_black_rook())
        {
            this.gameObject.AddComponent<Black_rook>();
            this.GetComponent<Black_rook>().is_promoted = true;
            this.GetComponent<Black_rook>().square = this.square;
            this.GetComponent<Black_rook>().square.piece = this.GetComponent<Black_rook>();
        }
        else if (sprite_promotion == Sprites.Get_black_bishop())
        {
            this.gameObject.AddComponent<Black_bishop>();
            this.GetComponent<Black_bishop>().is_promoted = true;
            this.GetComponent<Black_bishop>().square = this.square;
            this.GetComponent<Black_bishop>().square.piece = this.GetComponent<Black_bishop>();
        }
        else //if (sprite_promotion == Sprites.Get_black_knight())
        {
            this.gameObject.AddComponent<Black_knight>();
            this.GetComponent<Black_knight>().is_promoted = true;
            this.GetComponent<Black_knight>().square = this.square;
            this.GetComponent<Black_knight>().square.piece = this.GetComponent<Black_knight>();
        }

        this.GetComponent<Image>().sprite = sprite_promotion;
    }

    #endregion

    public void Promote(Sprite sprite_promotion)
    {
        if (this.is_white)
        {
            Destroy(this.gameObject.GetComponent<White_pawn>());
        }
        else
        {
            Destroy(this.gameObject.GetComponent<Black_pawn>());
        }

        this.Add_component_promotion(sprite_promotion);
    }

    public bool Check_is_promoted()
    {
        return this.GetComponent<AQueen>() || this.GetComponent<ARook>() || this.GetComponent<ABishop>() || this.GetComponent<AKnight>();
    }


    public override void Default_values()
    {
        this.Awake();
    }
}
