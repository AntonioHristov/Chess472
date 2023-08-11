﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pieces : MonoBehaviour
{
    private APiece[] in_game = new APiece[0];

    public Board board { get; set; }


    #region Methods

    #region APiece

    #region Rotate
    public void Rotate(APiece[] pieces_list)
    {
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                Common.Rotate_z(piece.gameObject);
            }
        }
    }

    public void Rotate_in_game()
    {
        this.Rotate(this.in_game);
    }

    public void Rotate_default(APiece[] pieces_list)
    {
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.transform.eulerAngles = Vector3.zero;
            }
        }
    }

    public void Rotate_in_game_default()
    {
        Rotate_default(this.in_game);
    }

    #endregion

    public APiece[] Get_All_in_game()
    {
        return this.in_game;
    }

    public void Set_All_in_game(APiece[] pieces_list)
    {
        this.in_game = pieces_list;
    }

    public APiece[] Get_alives(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if( pieces_list != null )
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.is_alive)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_alives_in_game()
    {
        return this.Get_alives(this.in_game);
    }

    public APiece[] Set_alives(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_alive = true;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_alives_in_game()
    {
        return this.Set_alives(this.in_game);
    }

    public APiece[] Get_dies(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (!piece.is_alive)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_dies_in_game()
    {
        return this.Get_dies(this.in_game);
    }

    public APiece[] Set_dies(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_alive = false;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_dies_in_game()
    {
        return this.Set_dies(this.in_game);
    }

    public APiece[] Get_whites(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.is_white)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_whites_in_game()
    {
        return this.Get_whites(this.in_game);
    }

    public APiece[] Set_whites(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_white = true;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_whites_in_game()
    {
        return this.Set_whites(this.in_game);
    }

    public APiece[] Get_blacks(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (!piece.is_white)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_blacks_in_game()
    {
        return this.Get_blacks(this.in_game);
    }

    public APiece[] Set_blacks(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_white = false;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_blacks_in_game()
    {
        return this.Set_blacks(this.in_game);
    }

    public APiece[] Get_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if ( typeof(TMoved).IsAssignableFrom(piece.GetType()) && piece.GetComponent<TMoved>().moved )
                {
                    result.Add(piece);
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_moved_in_game()
    {
        return this.Get_moved(this.Get_pawns_in_game());
    }

    public APiece[] Get_no_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if (typeof(TMoved).IsAssignableFrom(piece.GetType()) && !piece.GetComponent<TMoved>().moved)
                {
                    result.Add(piece);
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_no_moved_in_game()
    {
        return this.Get_no_moved(this.Get_pawns_in_game());
    }

    public APiece[] Set_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if (typeof(TMoved).IsAssignableFrom(piece.GetType()))
                {
                    piece.GetComponent<TMoved>().moved = true;
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_moved_in_game()
    {
        return this.Set_moved(this.Get_pawns_in_game());
    }

    public APiece[] Set_no_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if (typeof(TMoved).IsAssignableFrom(piece.GetType()))
                {
                    piece.GetComponent<TMoved>().moved = false;
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_no_moved_in_game()
    {
        return this.Set_no_moved(this.Get_pawns_in_game());
    }

    public void Set_default_values(APiece[] pieces_list)
    {
        foreach (APiece piece in pieces_list)
        {
            piece.Default_values();
        }
    }

    public void Set_default_values_in_game()
    {
        this.Set_default_values(this.in_game);
    }

    public void Update_pieces_in_game()
    {
        this.in_game = this.GetComponentsInChildren<APiece>();     
    }

    #endregion

    #region APawn
    public APawn[] Get_pawns(APiece[] pieces_list)
    {
        var result = new List<APawn>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<APawn>())
                {
                    result.Add(piece.GetComponent<APawn>());
                }
            }
        }
        return result.ToArray();
    }

    public APawn[] Get_pawns_in_game()
    {   
        return this.Get_pawns(this.in_game);
    }

    public APawn[] Get_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                if(pawn.is_en_passant_target )
                {
                    result.Add(pawn);
                }
            }
        }
        return result.ToArray();
    }

    public APawn[] Get_targets_en_passant_in_game()
    {
        return this.Get_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Get_no_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                if (!pawn.is_en_passant_target)
                {
                    result.Add(pawn);
                }
            }
        }
        return result.ToArray();
    }

    public APawn[] Get_no_targets_en_passant_in_game()
    {
        return this.Get_no_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Set_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                pawn.is_en_passant_target = true;
                result.Add(pawn);
            }
        }
        return result.ToArray();
    }

    public APawn[] Set_targets_en_passant_in_game()
    {
        return this.Set_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Set_no_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                pawn.is_en_passant_target = false;
                result.Add(pawn);
            }
        }
        return result.ToArray();
    }

    public APawn[] Set_no_targets_en_passant_in_game()
    {
        return this.Set_no_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Set_default_values(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                pawn.Default_values();
                result.Add(pawn);
            }
        }
        return result.ToArray();
    }

    #endregion

    #region AKnight

    public AKnight[] Get_knights(APiece[] pieces_list)
    {
        var result = new List<AKnight>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<AKnight>())
                {
                    result.Add(piece.GetComponent<AKnight>());
                }
            }
        }
        return result.ToArray();
    }

    public AKnight[] Get_Knights_in_game()
    {
        return this.Get_knights(this.in_game);
    }

    #endregion

    #region ABishop
    public ABishop[] Get_bishops(APiece[] pieces_list)
    {
        var result = new List<ABishop>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<ABishop>())
                {
                    result.Add(piece.GetComponent<ABishop>());
                }
            }
        }
        return result.ToArray();
    }

    public ABishop[] Get_bishops_in_game()
    {
        return this.Get_bishops(this.in_game);
    }

    #endregion

    #region AKing
    public AKing[] Get_kings(APiece[] pieces_list)
    {
        var result = new List<AKing>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<AKing>())
                {
                    result.Add(piece.GetComponent<AKing>());
                }
            }
        }
        return result.ToArray();
    }

    public AKing[] Get_Kings_in_game()
    {
        return this.Get_kings(this.in_game);
    }

    #endregion

    #region ARook
    public ARook[] Get_rooks(APiece[] pieces_list)
    {
        var result = new List<ARook>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<ARook>())
                {
                    result.Add(piece.GetComponent<ARook>());
                }
            }
        }
        return result.ToArray();
    }

    public ARook[] Get_rooks_in_game()
    {
        return this.Get_rooks(this.in_game);
    }

    #endregion

    #region AQueen

    public AQueen[] Get_queens(APiece[] pieces_list)
    {
        var result = new List<AQueen>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<AQueen>())
                {
                    result.Add(piece.GetComponent<AQueen>());
                }
            }
        }
        return result.ToArray();
    }

    public AQueen[] Get_queens_in_game()
    {
        return this.Get_queens(this.in_game);
    }

    #endregion

    #endregion


    public int? Get_id_in_game(APiece piece)
    {
        for(int i=0; i< this.Get_All_in_game().Length;i++)
        {
            if(this.Get_All_in_game()[i] == piece)
            {
                return i;
            }
        }
        return null;
    }

    public APiece Get_piece_in_game(int id)
    {
        if(id < 0 || !(id < this.Get_All_in_game().Length) )
        {
            return null;
        }
        else
        {
            return this.Get_All_in_game()[id];
        }
    }

    public Pieces Set_values(Pieces pieces_with_values)
    {
        this.Set_All_in_game(pieces_with_values.in_game);
        foreach (APiece piece in this.Get_All_in_game())
        {
            this.board.Piece_to_square(piece, piece.square);
        }
        //this.in_game = pieces_with_values.in_game;
        return this;
    }
    public void Awake()
    {
        this.in_game = this.GetComponentsInChildren<APiece>();
        this.board = this.GetComponentInParent<Board>();
    }
}
