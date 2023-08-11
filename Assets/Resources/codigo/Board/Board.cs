using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Squares squares {get; set;}
    public Pieces pieces {get; set;}
    public Game game { get; set; }

    /// <summary>
    /// Rotate or not depending on the turn of the game
    /// This method rotate the board and all pieces in game
    /// </summary>
    public void Rotate()
    {
        Common.Rotate_z(this.gameObject);
        this.pieces.Rotate_in_game();
    }

    /// <summary>
    /// Rotation by default
    /// This method rotate the board and all pieces in game
    /// </summary>
    public void Rotate_default()
    {
        this.transform.eulerAngles = Vector3.zero;
        this.pieces.Rotate_in_game_default();      
    }



    public void Piece_to_square(APiece piece = null, ASquare square = null)
    {
        if (piece && square)
        {
            // If there's an enemy piece in the new square, the enemy piece die
            if (square.piece && square.piece.is_white != piece.is_white)
            {
                square.piece.Die();
            }

            // Previous square is now empty
            if (piece.square)
            {
                piece.square.piece = null;
            }

            piece.square = square;
            square.piece = piece;
            piece.transform.position = square.transform.position;
        }
    }

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
                        this.game.kings_get_a_check.Add(square.piece.GetComponent<AKing>());
                        //Debug.Log("King " + this.game.kings_get_a_check + " attacked by " + piece);
                    }
                }
            }
        }
    }

    public void Update_squares_attacked_in_game()
    {
        this.squares.Set_no_attacked_in_game();
        this.game.kings_get_a_check = new List<AKing>();
        this.Update_squares_attacked(this.pieces.Get_All_in_game());
    }

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

    public bool Check_cant_move_in_game()
    {
        return this.Check_cant_move(this.pieces.Get_All_in_game());
    }

    public bool Check_is_stalemate(APiece[] pieces)
    {
        return this.Check_cant_move(pieces) && !this.game.Theres_a_check();
    }

    public bool Check_is_stalemate_in_game()
    {
        return this.Check_is_stalemate(this.pieces.Get_All_in_game());
    }

    public bool Check_is_checkmate(APiece[] pieces)
    {
        return this.Check_cant_move(pieces) && this.game.Theres_a_check();
    }

    public bool Check_is_checkmate_in_game()
    {
        return this.Check_is_checkmate(this.pieces.Get_All_in_game());
    }



    /// <summary>
    /// Can move or capture
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="square"></param>
    /// <returns></returns>
    public bool Check_can_move(APiece piece, ASquare square)
    {
        return piece != null && square != null && (square.piece == null || square.piece.is_white != piece.is_white);
    }

    /// <summary>
    /// Warning, by general pieces like knight, bishop, king, ... 
    /// NOT FOR PAWNS, because in that case is not exactly the same thing
    /// (can move and not can capture, etc).
    /// </summary>
    /// <param name="list"></param>
    /// <param name="piece"></param>
    /// <param name="square"></param>
    /// <returns></returns>
    public List<ASquare> Add_to_list_if_can_move(List<ASquare> list, APiece piece, ASquare square)
    {
        if (list != null && this.Check_can_move(piece,square) )
        {

            if (this.game.Theres_a_check())
            {
                this.pieces.Update_pieces_in_game();
                var clone_go = this.game.Clone_game();
                var clone_game = clone_go.GetComponent<Game>();

                var last_piece_aux = clone_game.board.pieces.Get_piece_in_game(this.pieces.Get_id_in_game(this.game.last_piece_moved).Value);
                var last_square_aux = clone_game.board.squares.Get_square_in_game(this.game.last_square_moved);
                clone_game.board.Piece_to_square(last_piece_aux, last_square_aux);

                //clone_game.Default_values_aux();
                
                
                var piece_aux = clone_game.board.pieces.Get_piece_in_game(this.pieces.Get_id_in_game(piece).Value);
                var square_aux = clone_game.board.squares.Get_square_in_game(square);

                //var previous_square_aux = piece_aux.square;
                //bool previous_moved=false;
                //var previous_piece_square_aux = square_aux.piece;


                clone_game.board.Piece_to_square(piece_aux, square_aux);

                if (typeof(TMoved).IsAssignableFrom(piece_aux.GetType()))
                {
                    piece_aux.GetComponent<TMoved>().moved = true;
                }

                //clone_game.board.squares.board.game.Next_turn();
                clone_game.is_white_turn = !clone_game.is_white_turn;
                clone_game.board.Update_squares_attacked_in_game();

                Debug.Log(piece_aux);
                Debug.Log(square_aux);
                Debug.Log(!clone_game.Theres_a_check());
                //Debug.Log(!clone_game.Theres_a_check() || clone_game.kings_get_a_check.is_white != piece_aux.is_white);
                // CONVERT king_gets_a_check TO A LIST OF KINGS
                if (!clone_game.Theres_a_check() || (!clone_game.Theres_a_check_to_color(piece_aux.is_white)) )
                {
                    list = this.Add_to_list_if_not_null(list, square);
                }
                if( square_aux.id_letter != ASquare.ID_G || square_aux.id_number != ASquare.ID_2 || !piece_aux.GetComponent<Black_queen>())
                {
                    Destroy(clone_game.gameObject);
                }
                
            }
            else
            {
                list = this.Add_to_list_if_not_null(list, square);
            }
            //list = this.Add_to_list_if_not_null(list, square);
        }
        return list;
    }

    /// <summary>
    /// Warning, by general pieces like knight, bishop, king, ... 
    /// NOT FOR PAWNS, because in that case is not exactly the same thing
    /// (can move and not can capture, etc).
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
    /// With large moves like bishops, rooks, queens
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

    public List<ASquare> Add_to_list_if_not_null(List<ASquare> list, ASquare square)
    {
        if (list != null && square != null)
        {
            list.Add(square);
        }
        return list;
    }


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

    public void Default_pieces_to_squares()
    {
        var pieces = this.pieces.Get_All_in_game();


        pieces[14].Revive(this.squares.Get_square_in_game(ASquare.ID_E, ASquare.ID_2));
        pieces[15].Revive(this.squares.Get_square_in_game(ASquare.ID_H, ASquare.ID_3));
        pieces[31].Revive(this.squares.Get_square_in_game(ASquare.ID_G, ASquare.ID_1));
        pieces[30].Revive(this.squares.Get_square_in_game(ASquare.ID_D, ASquare.ID_2));
        /*
        pieces[14].Revive(this.squares.Get_square_in_game(ASquare.ID_E, ASquare.ID_2));
        pieces[15].Revive(this.squares.Get_square_in_game(ASquare.ID_H, ASquare.ID_3));
        pieces[31].Revive(this.squares.Get_square_in_game(ASquare.ID_G, ASquare.ID_1));
        */
        /*
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
        */
    }

    public void Default_values_pieces()
    {
        this.pieces.Set_default_values_in_game();
    }

    public Board Set_values(Board board_with_values)
    {       
        //this.squares = board_with_values.squares.Set_values(board_with_values.squares);
        //this.pieces = board_with_values.pieces.Set_values(board_with_values.pieces);
        foreach (APiece piece in this.pieces.Get_All_in_game())
        {
            //this.Piece_to_square(piece, piece.square);
        }
        //this.Rotate();
        return board_with_values;
        //return this;
    }

    void Awake()
    {
        squares = this.GetComponentInChildren<Squares>();
        pieces = this.GetComponentInChildren<Pieces>();
        game = this.GetComponentInParent<Game>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
