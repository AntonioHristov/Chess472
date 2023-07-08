using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class APiece : MonoBehaviour
{
    #region Fields
    protected const int ID_NO_EXIST = 0;
    protected const int ID_PAWN = 1;
    protected const int ID_KNIGHT = 2;
    protected const int ID_BISHOP = 3;
    protected const int ID_KING = 4;
    protected const int ID_ROOK = 5;
    protected const int ID_QUEEN = 6;
    #endregion

    #region Properties
    public ASquare when_die { get; set; }
    public ASquare square { get; set; }
    public bool is_white { get; set; }
    public int id_piece { get; set; } // = ID_PAWN; etc
    public bool is_alive { get; set; }


    public bool moved { get; set; }
    public bool is_en_passant_target { get; set; }
    public Board board { get; set; }
    #endregion

    #region Methods
    protected static bool Check_2_ids_are_the_same(int id1 = ID_NO_EXIST, int? id2 = ID_NO_EXIST)
    { return id1 == id2; }
    protected static bool Check_id_no_exist(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_NO_EXIST); }
    protected static bool Check_id_is_for_pawn(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_PAWN); }
    protected static bool Check_id_is_for_knight(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_KNIGHT); }
    protected static bool Check_id_is_for_bishop(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_BISHOP); }
    protected static bool Check_id_is_for_king(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_KING); }
    protected static bool Check_id_is_for_rook(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_ROOK); }
    protected static bool Check_id_is_for_queen(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_QUEEN); }

    public abstract List<ASquare> Squares_which_this_piece_see();
    public abstract List<ASquare> Posible_moves();
    public void Die()
    { this.is_alive = false; this.GetComponentInParent<Board>().Piece_to_square(this, when_die); }
    public void Revive(ASquare square)
    { this.is_alive = true; this.GetComponentInParent<Board>().Piece_to_square(this, square); }
    #endregion

    public void Awake()
    {
        board = this.GetComponentInParent<Board>();
        this.is_alive = false;
        this.moved = false;
        this.is_en_passant_target = false;
    }
}