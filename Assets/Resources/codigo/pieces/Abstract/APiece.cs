using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    public ASquare when_die;
    public ASquare square;
    public abstract bool is_white { get; set; }
    public abstract int id_piece { get; set; } // = ID_PAWN; etc
    public bool is_alive;



    public Pieces pieces { get; set; }





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

    protected bool Check_id_no_exist()
    { return Check_2_ids_are_the_same(this.id_piece, ID_NO_EXIST); }
    protected bool Check_id_is_for_pawn()
    { return Check_2_ids_are_the_same(this.id_piece, ID_PAWN); }
    protected bool Check_id_is_for_knight()
    { return Check_2_ids_are_the_same(this.id_piece, ID_KNIGHT); }
    protected bool Check_id_is_for_bishop()
    { return Check_2_ids_are_the_same(this.id_piece, ID_BISHOP); }
    protected bool Check_id_is_for_king()
    { return Check_2_ids_are_the_same(this.id_piece, ID_KING); }
    protected bool Check_id_is_for_rook()
    { return Check_2_ids_are_the_same(this.id_piece, ID_ROOK); }
    protected bool Check_id_is_for_queen()
    { return Check_2_ids_are_the_same(this.id_piece, ID_QUEEN); }




    /// <summary>
    /// The Squares which the piece can capture an enemy piece if it there's
    /// I mean, the squares which this piece attack.
    /// </summary>
    /// <returns></returns>
    public abstract List<ASquare> Squares_which_this_piece_see();
    public abstract List<ASquare> Posible_moves();
    public abstract void Default_values();

    public void Die()
    { this.is_alive = false; this.GetComponentInParent<Board>().Piece_to_square(this, when_die); }
    public void Revive(ASquare square)
    { this.is_alive = true; this.GetComponentInParent<Board>().Piece_to_square(this, square); }

    public void Set_sprite(Sprite sprite)
    {
        if (!this.gameObject.GetComponent<Image>())
        {
            Image img = gameObject.AddComponent(typeof(Image)) as Image;
        }
        this.gameObject.GetComponent<Image>().sprite = sprite;
    }
    #endregion

    public void Awake()
    {
        pieces = this.GetComponentInParent<Pieces>();
        this.is_alive = false;


    }
}