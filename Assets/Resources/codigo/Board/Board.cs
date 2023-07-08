﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Squares squares {get; set;}
    public Pieces pieces {get; set;}
    public Game game { get; set; }

    public void Rotate(bool is_white_turn = true)
    {
        if (is_white_turn)
        {
            if (this.transform.position.y < 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 64, this.transform.position.z);
            }
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            if (this.transform.position.y > 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 64, this.transform.position.z);
            }
            this.transform.eulerAngles = new Vector3(0, 0, 180);
        }
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

    /// <summary>
    /// IN GAME
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="square"></param>
    /// <returns></returns>
    public bool Check_can_move(APiece piece, ASquare square)
    {
        if( (piece && square) && (square.piece == null || square.piece.is_white == piece.is_white) )
        {
            return true;
        }
        else
        {
            return false;
        }   
    }

    public List<ASquare> Add_to_list_if_can_move(List<ASquare> list, APiece piece, ASquare square)
    {
        if ( Check_can_move(piece, square) )
        {
            list.Add(square);
        }
        return list;
    }

    public List<ASquare> Add_to_list_if_can_capture(List<ASquare> list, APiece piece, ASquare square)
    {
        if (piece != null && square != null && square.piece != null && square.piece.is_white != piece.is_white)
        {
            list.Add(square);
        }
        return list;
    }

    public List<ASquare> Add_to_list_if_en_passant(List<ASquare> list, APiece piece)
    {
        if ( piece != null && piece.square != null )
        {
            var posible_squares_piece = new List<ASquare>();
            posible_squares_piece.Add(this.squares.Left(piece.square, 1));
            posible_squares_piece.Add(this.squares.Right(piece.square, 1));

            foreach (ASquare square_target_piece in posible_squares_piece)
            {
                if (square_target_piece != null && square_target_piece.piece != null && square_target_piece.piece.is_en_passant_target )
                {
                    list.Add( this.squares.Up(square_target_piece, 1) );
                }
            }
        }
        return list;
    }

    public void Default_pieces_to_when_die()
    {
        var pieces = this.pieces.all;
        var when_die = squares.when_die;

        for(var count = 0; count < pieces.Length; count++)
        {
            pieces[count].when_die = when_die[count];
        } 
    }

    public void Default_pieces_to_squares()
    {
        var pieces = this.pieces.all;
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