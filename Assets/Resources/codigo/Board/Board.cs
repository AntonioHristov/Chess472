using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    /// <summary>
    /// THE GAME WHICH HAS THIS BOARD.
    /// </summary>
    public Game game { get; set; }
    /// <summary>
    /// THE SQUARES OF THIS BOARD.
    /// </summary>
    public Squares squares {get; set;}
    /// <summary>
    /// THE PIECES OF THIS BOARD.
    /// </summary>
    public Pieces pieces {get; set;}
    // FIXME: MAYBE WE CAN IMPROVE THINGS IN kings_get_a_check, LIKE THIS Start METHOD AND: CHECK kings_get_a_check IS NOT NULL AND ITS NOT EMPTY...
    /// <summary>
    /// A LIST WITH KING PIECES IN THIS BOARD WHICH GET A CHECK/ATTACK IN THE LAST TURN.
    /// </summary>
    public List<AKing> kings_get_a_check { get; set; }




    /// <summary>
    /// <para>ROTATE THIS BOARD OR NOT DEPENDING ON THE TURN OF THE GAME</para>
    /// <para>THIS METHOD ROTATE THE BOARD AND ALL OWN PIECES</para>
    /// </summary>
    public void Rotate()
    {
        Common.Rotate_z(this.gameObject);
        this.pieces.Rotate_in_game();
    }

    /// <summary>
    /// <para>ROTATION BY DEFAULT</para>
    /// <para>THIS METHOD ROTATE THE BOARD AND ALL OWN PIECES</para>
    /// </summary>
    public void Rotate_default()
    {
        this.transform.eulerAngles = Vector3.zero;
        this.pieces.Rotate_in_game_default();      
    }

    /// <summary>
    /// <para>MOVE A PIECE TO A SQUARE</para>
    /// <para>PREVIOUS SQUARE OF THE PIECE WILL BE EMPTY AND IF THERES A PIECE IN THE NEW SQUARE, THAT PIECE WILL BE DIE</para>
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="square"></param>
    public void Piece_to_square(APiece piece = null, ASquare square = null)
    {
        if (piece && square)
        {
            // IF THERE'S AN ENEMY PIECE IN THE NEW SQUARE, THE ENEMY PIECE DIE
            if (square.piece && square.piece.is_white != piece.is_white)
            {
                square.piece.Die();
            }

            // PREVIOUS SQUARE IS NOW EMPTY
            if (piece.square)
            {
                piece.square.piece = null;
            }

            piece.square = square;
            square.piece = piece;
            piece.transform.position = square.transform.position;
        }
    }

    // FIXME: REMOVE by_user WHEN CREATE THE OBJECT CLON_GAME, OR THINK ABOUT THAT
    /// <summary>
    /// <para>THE DIFFERENCE WITH Piece_to_square IS THERES A MOVE CASTLE AND EN PASSANT WHICH ARE DIFFERENT</para>
    /// <para>by_user IS BECAUSE A CLON GAME CAN MAKE A MOVE AND IN THAT CASE IF ITS A PROMOTION WE DON'T WANT TO OPEN THE PROMOTION BOX</para>
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="square_destination"></param>
    /// <param name="by_user"></param>
    /// <returns>The gameobject with Game component</returns>
    public GameObject Make_a_move(APiece piece, ASquare square_destination, bool by_user)
    {
        
        if (piece != null && square_destination != null)
        {
            /* 
             * This if and unclick is because when the user clicks an square and its a check, 
             * first I create some clons making the posible moves to know if I get a check after these moves
             * and in these moves in clons which moves are not by user, the square of the piece is
             * clicked because before creating a clon the user clicked the square's piece,
             * so I unclick these squares in the clon games but not in the main game.
            */
            if(!by_user)
            {
                piece.square.Unclick();
            }
            
            if (piece.GetComponent<APawn>())
            {
                // Trying to capture the target piece en passant , if its not been able to do it, then...
                if (!piece.GetComponent<APawn>().Try_capture_en_passant(square_destination))
                {
                    // All pawns in game are not en passant target. This is because we want a pawn which is an en passant target only the first chance and not more
                    this.pieces.Set_no_targets_en_passant_in_game();

                    // if its pawn's first move and go 2 squares, is a target for en passant, if not not.
                    piece.GetComponent<APawn>().Is_en_passant_target(square_destination);

                    if (by_user && piece.GetComponent<APawn>().Next_advance_will_be_promotion())
                    {
                        piece.GetComponent<APawn>().Open_box_promotion();
                    }
                }
            }
            else if (piece.GetComponent<AKing>())
            {
                piece.GetComponent<AKing>().Move_rook_when_castle(square_destination);
            }
            

            this.squares.board.Piece_to_square(piece, square_destination);

            
            if (typeof(TMoved).IsAssignableFrom(piece.GetType()))
            {
                piece.GetComponent<TMoved>().moved = true;
            }
            

            this.game.Next_turn();
        }
        

        return this.game.gameObject;
    }

    /// <summary>
    /// SAME TO Make_a_move BUT IN A CLON GAME (clone_gameobject)
    /// IF THERE'S NO clone_gameobject, THIS METHOD CREATES A NEW CLONE GAME, MAKE THE MOVE AND
    /// RETURN THE CLONE GAME
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="square"></param>
    /// <param name="clone_gameobject"></param>
    /// <returns></returns>
    private GameObject Make_a_move_in_a_cloned_game(APiece piece, ASquare square, GameObject clone_gameobject = null)
    {
        if (!clone_gameobject)
        {
            clone_gameobject = this.game.Clone_game();
            if(clone_gameobject == null)
            {
                return null;
            }
        }

        var piece_aux = piece.Get_in_cloned_game(clone_gameobject);
        var square_aux = square.Get_in_cloned_game(clone_gameobject);

        if (piece_aux != null && square_aux != null)
        {        
            clone_gameobject = clone_gameobject.GetComponent<Game>().board.Make_a_move(piece_aux, square_aux, false);
        }

        return clone_gameobject;
    }

    /// <summary>
    /// THIS IS ONLY BECAUSE IN A CLON GAME THE SAME MOVE CAN BE MULTIPLE MOVES IN THE PAWN'S PROMOTION
    /// AND WE WANT TO GET ALL OF THEM IN A CLON GAME ONLY IF ITS A PROMOTION, 
    /// <para>IF NOT IT CALLS Make_a_move_in_a_cloned_game METHOD</para>
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="square_destination"></param>
    /// <returns></returns>
    public GameObject[] Make_posible_moves_in_a_clon_game(APiece piece, ASquare square_destination)
    {
        var result = new List<GameObject>();
        if (piece == null || square_destination == null)
        {
            //ERROR
            return null;
        }
        else
        {
            if (piece.GetComponent<APawn>() && piece.GetComponent<APawn>().Next_advance_will_be_promotion())
            {
                var game_knight_promote = this.Make_a_move_in_a_cloned_game(piece, square_destination);
                var game_bishop_promote = this.Make_a_move_in_a_cloned_game(piece, square_destination);
                var game_rook_promote = this.Make_a_move_in_a_cloned_game(piece, square_destination);
                var game_queen_promote = this.Make_a_move_in_a_cloned_game(piece, square_destination);

                if(!game_knight_promote || !game_bishop_promote || !game_rook_promote || !game_queen_promote)
                {
                    //ERROR
                    return null;
                }
                else
                {
                    var pawn_promoting_knight = piece.Get_in_cloned_game(game_knight_promote);
                    var pawn_promoting_bishop = piece.Get_in_cloned_game(game_bishop_promote);
                    var pawn_promoting_rook = piece.Get_in_cloned_game(game_rook_promote);
                    var pawn_promoting_queen = piece.Get_in_cloned_game(game_queen_promote);

                    if (piece.is_white)
                    {
                        pawn_promoting_knight.GetComponent<APawn>().Promote(Sprites.Get_white_knight());
                        pawn_promoting_bishop.GetComponent<APawn>().Promote(Sprites.Get_white_bishop());
                        pawn_promoting_rook.GetComponent<APawn>().Promote(Sprites.Get_white_rook());
                        pawn_promoting_queen.GetComponent<APawn>().Promote(Sprites.Get_white_queen());
                    }
                    else
                    {
                        pawn_promoting_knight.GetComponent<APawn>().Promote(Sprites.Get_black_knight());
                        pawn_promoting_bishop.GetComponent<APawn>().Promote(Sprites.Get_black_bishop());
                        pawn_promoting_rook.GetComponent<APawn>().Promote(Sprites.Get_black_rook());
                        pawn_promoting_queen.GetComponent<APawn>().Promote(Sprites.Get_black_queen());
                    }

                    result.Add(game_knight_promote);
                    result.Add(game_bishop_promote);
                    result.Add(game_rook_promote);
                    result.Add(game_queen_promote);
                }            
            }
            else
            {
                var game_clone_result = this.Make_a_move_in_a_cloned_game(piece, square_destination);
                if(!game_clone_result)
                {
                    //ERROR
                    return null;
                }
                else
                {
                    result.Add(game_clone_result);
                }

            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// THIS METHOD UPDATE SQUARES ATTACKED BY PIECES PASSED BY PARAMETER
    /// <para>AND ADD TO kings_get_a_check IF ITS THE CASE</para>
    /// </summary>
    /// <param name="pieces"></param>
    public void Update_squares_attacked(APiece[] pieces)
    {
        foreach (APiece piece in pieces)
        {
            if (piece.is_alive)
            {
                foreach (ASquare square in piece.Squares_which_this_piece_see())
                {
                    square.attacked_by.Add(piece);
                    
                    /*
                    if(square.id_letter == ASquare.ID_G && square.id_number == ASquare.ID_1)
                    {
                        Debug.Log(piece + " attack " + square);
                        Debug.Log(square.piece);
                        Debug.Log(pieces[31].square);
                    }
                    */
                    if (square.piece && square.piece.GetComponent<AKing>() && square.piece.is_white != piece.is_white)
                    {
                        this.kings_get_a_check.Add(square.piece.GetComponent<AKing>());
                        //Debug.Log("King " + this.game.kings_get_a_check + " attacked by " + piece);
                    }
                }
            }
        }
    }

    /// <summary>
    /// UPDATE ALL SQUARES ATTACKED BY ALL PIECES IN THIS BOARD
    /// </summary>
    public void Update_squares_attacked_in_game()
    {
        this.squares.Set_no_attacked_in_game();
        this.kings_get_a_check = new List<AKing>();
        this.Update_squares_attacked(this.pieces.Get_All_in_game());
    }

    /// <summary>
    /// RETURN TRUE IF THERE'S A PIECE BY PARAMETER IN THE SAME TURN AND THAT PIECE HAS A/SOME POSIBLE MOVES
    /// </summary>
    /// <param name="pieces"></param>
    /// <returns></returns>
    public bool Check_cant_move(APiece[] pieces)
    {
        foreach (APiece piece in pieces)
        {
            if (piece.is_white == this.game.is_white_turn && piece.Posible_moves().Count > 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// RETURN TRUE IF THERE'S A PIECE IN THIS BOARD IN THE SAME TURN AND THAT PIECE HAS A/SOME POSIBLE MOVES
    /// </summary>
    /// <returns></returns>
    public bool Check_cant_move_in_game()
    {
        return this.Check_cant_move(this.pieces.Get_All_in_game());
    }

    /// <summary>
    /// IF A PIECE CAN MOVE INTO A SQUARE, RETURN TRUE
    /// <para>(A PIECE CAN'T MOVE INTO A SQUARE WITH A PIECE WITH THE SAME COLOUR)</para>
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="square"></param>
    /// <returns></returns>
    public bool Check_can_move(APiece piece, ASquare square)
    {
        return piece != null && square != null && (square.piece == null || square.piece.is_white != piece.is_white);
    }

    /// <summary>
    /// ADD A SQUARE INTO A LIST IF CAN MOVE A PIECE INTO A SQUARE
    /// </summary>
    /// <param name="list"></param>
    /// <param name="piece"></param>
    /// <param name="square"></param>
    /// <returns></returns>
    public List<ASquare> Add_to_list_if_can_move(List<ASquare> list, APiece piece, ASquare square)
    {
        if (list != null && piece.is_alive && this.game.is_white_turn == piece.is_white && this.Check_can_move(piece,square) )
        {
            if (this.game.Theres_depth_check() && this.game.Theres_a_check())
            {
                // Cache list is empty
                piece.Add_cache();
                var posible_moves = this.Make_posible_moves_in_a_clon_game(piece, square);

                if (posible_moves != null)
                {
                    foreach (GameObject move in posible_moves)
                    {
                        if (!move.GetComponent<Game>().Theres_a_check_to_color(piece.is_white))
                        {
                            list = this.Add_to_list_if_not_null(list, square);
                            piece.Add_cache(square);
                        }
                    }
                }
            }
            else
            {
                list = this.Add_to_list_if_not_null(list, square);
                piece.Add_cache(square);
            }
        }
        return list;
    }

    /// <summary>
    /// ADD SQUARES FROM A LIST OF SQUARES INTO A LIST IF CAN MOVE A PIECE INTO THE SQUARES
    /// </summary>
    /// <param name="list"></param>
    /// <param name="piece"></param>
    /// <param name="squares"></param>
    /// <returns></returns>
    public List<ASquare> Add_to_list_if_can_move(List<ASquare> list, APiece piece, ASquare[] squares)
    {
        if(list != null && piece != null && squares != null)
        {
            foreach (ASquare square in squares)
            {
                list = this.Add_to_list_if_can_move(list, piece, square);
            }
        }
        return list;
    }



    #region Large moves

    /// <summary>
    /// ONLY WITH LARGE MOVES PIECES LIKE BISHOPS, ROOKS, QUEENS
    /// <para>PREVIOUSLY ALL SQUARES MUST BE IN THE SAME DIRECTION (DIAGONAL, VERTICAL OR HORIZONTAL)</para>
    /// <para>THIS METHOD ADD INTO A LIST THESE SQUARES UNTIL THERE'S A SQUARE WITH A PIECE (NOT EMPTY)</para>
    /// </summary>
    /// <param name="list"></param>
    /// <param name="piece"></param>
    /// <param name="squares"></param>
    /// <returns></returns>
    public List<ASquare> Add_to_list_if_can_see_without_jump(List<ASquare> list, APiece piece, ASquare[] squares)
    {
        if (list != null && piece != null && squares != null)
        {
            foreach (ASquare square in squares)
            {
                list = this.Add_to_list_if_not_null(list, square);
                if (square.piece)
                {
                    return list;
                }
            }
        }
        return list;
    }

    #endregion

    /// <summary>
    /// IF SOMETHING IT'S NULL, RETURN NULL.
    /// <para>IF NOT, ADD THE SQUARE INTO THE LIST AND RETURN THE LIST.</para>
    /// </summary>
    /// <param name="list"></param>
    /// <param name="square"></param>
    /// <returns></returns>
    public List<ASquare> Add_to_list_if_not_null(List<ASquare> list, ASquare square)
    {
        if (list != null && square != null)
        {
            list.Add(square);
        }
        return list;
    }

    /// <summary>
    /// THIS METHOD ASIGN WHEN DIE SQUARES TO ALL PIECES
    /// </summary>
    public void Default_pieces_set_when_die()
    {
        var all_pieces = this.pieces.Get_All_in_game();
        var when_die = squares.when_die;

        if(all_pieces.Length == when_die.Length)
        {
            for (var count = 0; count < all_pieces.Length; count++)
            {
                all_pieces[count].when_die = when_die[count];
            }
        }

    }

    /// <summary>
    /// THIS METHOD ASIGN ALL PIECES INTO DEFAULT SQUARES FROM A NORMAL FIRST POSITION IN A NORMAL CHESS GAME
    /// </summary>
    public void Default_pieces_to_squares()
    {
        var pieces = this.pieces.Get_All_in_game();

        /*
        pieces[1].Revive(this.squares.Get_square_in_game(ASquare.ID_F, ASquare.ID_7));//WP
        pieces[1].GetComponent<APawn>().moved = true;//WP


        pieces[30].Revive(this.squares.Get_square_in_game(ASquare.ID_E, ASquare.ID_4));//BQ

        pieces[15].Revive(this.squares.Get_square_in_game(ASquare.ID_H, ASquare.ID_8));//WKI
        pieces[31].Revive(this.squares.Get_square_in_game(ASquare.ID_H, ASquare.ID_6));//BKI
        */

        /*
        pieces[14].Revive(this.squares.Get_square_in_game(ASquare.ID_E, ASquare.ID_2));
        pieces[15].Revive(this.squares.Get_square_in_game(ASquare.ID_H, ASquare.ID_3));
        pieces[31].Revive(this.squares.Get_square_in_game(ASquare.ID_G, ASquare.ID_1));
        pieces[30].Revive(this.squares.Get_square_in_game(ASquare.ID_D, ASquare.ID_2));
        */


        
        pieces[0].Revive(this.squares.Get_square_in_game (ASquare.ID_A, ASquare.ID_2));
        pieces[1].Revive(this.squares.Get_square_in_game (ASquare.ID_B, ASquare.ID_2));
        pieces[2].Revive(this.squares.Get_square_in_game (ASquare.ID_C, ASquare.ID_2));
        pieces[3].Revive(this.squares.Get_square_in_game (ASquare.ID_D, ASquare.ID_2));
        pieces[4].Revive(this.squares.Get_square_in_game (ASquare.ID_E, ASquare.ID_2));
        pieces[5].Revive(this.squares.Get_square_in_game (ASquare.ID_F, ASquare.ID_2));
        pieces[6].Revive(this.squares.Get_square_in_game (ASquare.ID_G, ASquare.ID_2));
        pieces[7].Revive(this.squares.Get_square_in_game (ASquare.ID_H, ASquare.ID_2));
        pieces[8].Revive(this.squares.Get_square_in_game (ASquare.ID_A, ASquare.ID_1));
        pieces[9].Revive(this.squares.Get_square_in_game (ASquare.ID_H, ASquare.ID_1));
        pieces[10].Revive(this.squares.Get_square_in_game(ASquare.ID_B, ASquare.ID_1));
        pieces[11].Revive(this.squares.Get_square_in_game(ASquare.ID_G, ASquare.ID_1));
        pieces[12].Revive(this.squares.Get_square_in_game(ASquare.ID_C, ASquare.ID_1));
        pieces[13].Revive(this.squares.Get_square_in_game(ASquare.ID_F, ASquare.ID_1));
        pieces[14].Revive(this.squares.Get_square_in_game(ASquare.ID_D, ASquare.ID_1));
        pieces[15].Revive(this.squares.Get_square_in_game(ASquare.ID_E, ASquare.ID_1));

        pieces[16].Revive(this.squares.Get_square_in_game(ASquare.ID_A, ASquare.ID_7));
        pieces[17].Revive(this.squares.Get_square_in_game(ASquare.ID_B, ASquare.ID_7));
        pieces[18].Revive(this.squares.Get_square_in_game(ASquare.ID_C, ASquare.ID_7));
        pieces[19].Revive(this.squares.Get_square_in_game(ASquare.ID_D, ASquare.ID_7));
        pieces[20].Revive(this.squares.Get_square_in_game(ASquare.ID_E, ASquare.ID_7));
        pieces[21].Revive(this.squares.Get_square_in_game(ASquare.ID_F, ASquare.ID_7));
        pieces[22].Revive(this.squares.Get_square_in_game(ASquare.ID_G, ASquare.ID_7));
        pieces[23].Revive(this.squares.Get_square_in_game(ASquare.ID_H, ASquare.ID_7));
        pieces[24].Revive(this.squares.Get_square_in_game(ASquare.ID_A, ASquare.ID_8));
        pieces[25].Revive(this.squares.Get_square_in_game(ASquare.ID_H, ASquare.ID_8));
        pieces[26].Revive(this.squares.Get_square_in_game(ASquare.ID_B, ASquare.ID_8));
        pieces[27].Revive(this.squares.Get_square_in_game(ASquare.ID_G, ASquare.ID_8));
        pieces[28].Revive(this.squares.Get_square_in_game(ASquare.ID_C, ASquare.ID_8));
        pieces[29].Revive(this.squares.Get_square_in_game(ASquare.ID_F, ASquare.ID_8));
        pieces[30].Revive(this.squares.Get_square_in_game(ASquare.ID_D, ASquare.ID_8));
        pieces[31].Revive(this.squares.Get_square_in_game(ASquare.ID_E, ASquare.ID_8));       
        
    }

    /// <summary>
    /// Awake IS CALLED ONLY ONCE DURING THE LIFETIME OF THE SCRIPT INSTANCE
    /// </summary>
    void Awake()
    {
        squares = this.GetComponentInChildren<Squares>();
        pieces = this.GetComponentInChildren<Pieces>();
        game = this.GetComponentInParent<Game>();
    }


    /// <summary>
    /// Start IS CALLED BEFORE THE FIRST FRAME UPDATE
    /// <para>IF ITS NOT A CLONE GAME, INITIALIZATE A NEW EMPTY LIST kings_get_a_check</para>
    /// </summary>
    void Start()
    {
        // Maybe we can remove this, but make some tests first
        if(!this.game.is_clone)
        {
            this.kings_get_a_check = new List<AKing>();
        }
    }
}
