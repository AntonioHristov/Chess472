using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class APawn : APiece, TMoved, TDirection
{
    public abstract ADirection direction { get; set; }
    public bool is_en_passant_target { get; set; }
    public bool moved { get; set; }
    public const int SQUARES_FORWARD_PROMOTION = 7;


    new public void Awake()
    {
        base.Awake();
        this.is_en_passant_target = false;
        this.moved = false;
        if(this.pieces && this.pieces.board && this.pieces.board.game && this.pieces.board.game.boxes)
        {
            if(this.pieces.board.game.boxes.Get_box_promote())
            {
                this.pieces.board.game.boxes.Get_box_promote().Hide();

            }
            if (this.pieces.board.game.boxes.Get_box_confirm_promotion())
            {
                this.pieces.board.game.boxes.Get_box_confirm_promotion().Hide();

            }
        }
    }

    public void Start()
    {

    }

    public override List<ASquare> Squares_which_this_piece_see()
    {
        var result = new List<ASquare>();

        if (!base.is_alive || this.direction == null)
        {
            return result;
        }

        result = this.pieces.board.Add_to_list_if_not_null(result, this.direction.Forward_Left_diagonal(this,1));
        result = this.pieces.board.Add_to_list_if_not_null(result, this.direction.Forward_Right_diagonal(this,1));

        return result;
    }

    public override List<ASquare> Posible_moves()
    {
        if (!this.is_alive)
        {
            return new List<ASquare>();
        }
        else
        {
            if (!base.Is_cache_empty())
            {
                return base.cache_posible_moves;
            }
            else
            {
                var result = new List<ASquare>();

                result = this.Add_to_list_if_can_move_without_capture(result, this.direction.Forward(this.square, 1));

                if (!this.moved && this.Check_can_move_without_capture(this.direction.Forward(this.square, 1)))
                {
                    result = this.Add_to_list_if_can_move_without_capture(result, this.direction.Forward(this.square, 2));
                }


                foreach (ASquare square in this.Squares_which_this_piece_see())
                {
                    result = this.Add_to_list_if_can_capture(result, square);
                }

                result = this.Add_to_list_if_en_passant(result);



                result = this.pieces.board.Add_to_list_if_can_move(new List<ASquare>(), this, result.ToArray());

                base.Add_cache(result);

                return result;
            }
        }

    }

    public List<ASquare> Add_to_list_if_can_capture(List<ASquare> list, ASquare square)
    {
        if (square != null && (square.piece != null && square.piece.is_white != this.is_white))
        {
            list.Add(square);
        }
        return list;
    }

    public bool Check_can_move_without_capture(ASquare square)
    {
        return square && square.piece == null;
    }

    public List<ASquare> Add_to_list_if_can_move_without_capture(List<ASquare> list, ASquare square)
    {
        if (this.Check_can_move_without_capture(square))
        {
            list.Add(square);
        }
        return list;
    }

    /// <summary>
    /// Add to list the square where you can move only if en passant. 
    /// The main use is adding the square en passant in a list for posible moves.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public List<ASquare> Add_to_list_if_en_passant(List<ASquare> list)
    {
        if (this.square && this.direction)
        {
            var posible_squares_piece = new List<ASquare>();

            if (this.direction.GetComponent<Up>() || this.direction.GetComponent<Down>())
            {
                posible_squares_piece.Add(this.square.Left(1));
                posible_squares_piece.Add(this.square.Right(1));
            }
            else //if (pawn.direction.GetComponent<Left>() || pawn.direction.GetComponent<Right>())
            {
                posible_squares_piece.Add(this.square.Up(1));
                posible_squares_piece.Add(this.square.Down(1));
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
        if (square_destination && !this.moved && this.direction.Forward(this.square, 2) == square_destination)
        {
            this.is_en_passant_target = true;
        }
        else
        {
            this.is_en_passant_target = false;
        }
        return this.is_en_passant_target;
    }

    public bool Next_advance_will_be_promotion()
    {
        return this.direction.Forward(this, 1 - SQUARES_FORWARD_PROMOTION) != null;
    }

    public bool This_square_is_a_promotion()
    {
        return this.direction.Forward(this, 0 - SQUARES_FORWARD_PROMOTION) != null;
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

    public APiece Add_component_promotion(Sprite sprite_promotion)
    {
        this.GetComponent<Image>().sprite = sprite_promotion;
        if (sprite_promotion == Sprites.Get_white_queen())
        {
            this.gameObject.AddComponent<White_queen>();
            this.GetComponent<White_queen>().is_promoted = true;
            this.GetComponent<White_queen>().is_alive = true;
            base.GetComponent<White_queen>().id = base.GetComponent<White_pawn>().id;
            this.GetComponent<White_queen>().square = this.GetComponent<White_pawn>().square;
            this.GetComponent<White_queen>().square.piece = this.GetComponent<White_queen>();
            this.GetComponent<White_queen>().when_die = this.GetComponent<White_pawn>().when_die;
            return this.GetComponent<White_queen>();
        }
        else if (sprite_promotion == Sprites.Get_white_rook())
        {
            this.gameObject.AddComponent<White_rook>();
            this.GetComponent<White_rook>().is_promoted = true;
            this.GetComponent<White_rook>().is_alive = true;
            base.GetComponent<White_rook>().id = base.GetComponent<White_pawn>().id;
            this.GetComponent<White_rook>().square = this.GetComponent<White_pawn>().square;
            this.GetComponent<White_rook>().square.piece = this.GetComponent<White_rook>();
            this.GetComponent<White_rook>().when_die = this.GetComponent<White_pawn>().when_die;
            return this.GetComponent<White_rook>();
        }
        else if (sprite_promotion == Sprites.Get_white_bishop())
        {
            this.gameObject.AddComponent<White_bishop>();
            this.GetComponent<White_bishop>().is_promoted = true;
            this.GetComponent<White_bishop>().is_alive = true;
            base.GetComponent<White_bishop>().id = base.GetComponent<White_pawn>().id;
            this.GetComponent<White_bishop>().square = this.GetComponent<White_pawn>().square;
            this.GetComponent<White_bishop>().square.piece = this.GetComponent<White_bishop>();
            this.GetComponent<White_bishop>().when_die = this.GetComponent<White_pawn>().when_die;
            return this.GetComponent<White_bishop>();
        }
        else if (sprite_promotion == Sprites.Get_white_knight())
        {
            this.gameObject.AddComponent<White_knight>();
            this.GetComponent<White_knight>().is_promoted = true;
            this.GetComponent<White_knight>().is_alive = true;
            base.GetComponent<White_knight>().id = base.GetComponent<White_pawn>().id;
            this.GetComponent<White_knight>().square = this.GetComponent<White_pawn>().square;
            this.GetComponent<White_knight>().square.piece = this.GetComponent<White_knight>();
            this.GetComponent<White_knight>().when_die = this.GetComponent<White_pawn>().when_die;
            return this.GetComponent<White_knight>();
        }
        else if (sprite_promotion == Sprites.Get_black_queen())
        {
            this.gameObject.AddComponent<Black_queen>();
            this.GetComponent<Black_queen>().is_promoted = true;
            this.GetComponent<Black_queen>().is_alive = true;
            base.GetComponent<Black_queen>().id = base.GetComponent<Black_pawn>().id;
            this.GetComponent<Black_queen>().square = this.GetComponent<Black_pawn>().square;
            this.GetComponent<Black_queen>().square.piece = this.GetComponent<Black_queen>();
            this.GetComponent<Black_queen>().when_die = this.GetComponent<Black_pawn>().when_die;
            return this.GetComponent<Black_queen>();
        }
        else if (sprite_promotion == Sprites.Get_black_rook())
        {
            this.gameObject.AddComponent<Black_rook>();
            this.GetComponent<Black_rook>().is_promoted = true;
            this.GetComponent<Black_rook>().is_alive = true;
            base.GetComponent<Black_rook>().id = base.GetComponent<Black_pawn>().id;
            this.GetComponent<Black_rook>().square = this.GetComponent<Black_pawn>().square;
            this.GetComponent<Black_rook>().square.piece = this.GetComponent<Black_rook>();
            this.GetComponent<Black_rook>().when_die = this.GetComponent<Black_pawn>().when_die;
            return this.GetComponent<Black_rook>();
        }
        else if (sprite_promotion == Sprites.Get_black_bishop())
        {
            this.gameObject.AddComponent<Black_bishop>();
            this.GetComponent<Black_bishop>().is_promoted = true;
            this.GetComponent<Black_bishop>().is_alive = true;
            base.GetComponent<Black_bishop>().id = base.GetComponent<Black_pawn>().id;
            this.GetComponent<Black_bishop>().square = this.GetComponent<Black_pawn>().square;
            this.GetComponent<Black_bishop>().square.piece = this.GetComponent<Black_bishop>();
            this.GetComponent<Black_bishop>().when_die = this.GetComponent<Black_pawn>().when_die;
            return this.GetComponent<Black_bishop>();
        }
        else //if (sprite_promotion == Sprites.Get_black_knight())
        {
            this.gameObject.AddComponent<Black_knight>();
            this.GetComponent<Black_knight>().is_promoted = true;
            this.GetComponent<Black_knight>().is_alive = true;
            base.GetComponent<Black_knight>().id = base.GetComponent<Black_pawn>().id;
            this.GetComponent<Black_knight>().square = this.GetComponent<Black_pawn>().square;
            this.GetComponent<Black_knight>().square.piece = this.GetComponent<Black_knight>();
            this.GetComponent<Black_knight>().when_die = this.GetComponent<Black_pawn>().when_die;
            return this.GetComponent<Black_knight>();
        }

        
    }

    #endregion

    public APiece Promote(Sprite sprite_promotion)
    {
        this.Add_component_promotion(sprite_promotion);

        if (this.is_white)
        {
            DestroyImmediate(this.gameObject.GetComponent<White_pawn>());
        }
        else
        {
            DestroyImmediate(this.gameObject.GetComponent<Black_pawn>());
        }
        this.pieces.Update_pieces_in_game();
        return this;
    }
    

    public override void Default_values()
    {
        this.Awake();
    }
}
