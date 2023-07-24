using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADirection : MonoBehaviour
{
    #region Fields
    protected const int ID_NO_EXIST = 0;
    protected const int ID_UP = 1;
    protected const int ID_DOWN = 2;
    protected const int ID_LEFT = 3;
    protected const int ID_RIGHT = 4;
    #endregion

    public abstract int id_direction { get; set; }

    #region Methods
    public static bool Check_2_ids_are_the_same(int id1 = ID_NO_EXIST, int? id2 = ID_NO_EXIST)
    { return id1 == id2; }
    public static bool Check_id_no_exist(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_NO_EXIST); }
    public static bool Check_id_is_up(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_UP); }
    public static bool Check_id_is_down(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_DOWN); }
    public static bool Check_id_is_left(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_LEFT); }
    public static bool Check_id_is_right(int id = ID_NO_EXIST)
    { return Check_2_ids_are_the_same(id, ID_RIGHT); }


    public bool Check_id_no_exist()
    { return Check_2_ids_are_the_same(this.id_direction, ID_NO_EXIST); }
    public bool Check_id_is_up()
    { return Check_2_ids_are_the_same(this.id_direction, ID_UP); }
    public bool Check_id_is_down()
    { return Check_2_ids_are_the_same(this.id_direction, ID_DOWN); }
    public bool Check_id_is_left()
    { return Check_2_ids_are_the_same(this.id_direction, ID_LEFT); }
    public bool Check_id_is_right()
    { return Check_2_ids_are_the_same(this.id_direction, ID_RIGHT); }

    /// <summary>
    /// Squares forward from square, number times
    /// </summary>
    /// <param name="pawn"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    public ASquare Forward(ASquare square, int number = 0)
    {
        ASquare result = null;
        if (this != null)
        {
            if (this.Check_id_is_up())
            {
                result = square.squares.Up(square, number);
            }
            else if (this.Check_id_is_down())
            {
                result = square.squares.Down(square, number);
            }
            else if (this.Check_id_is_left())
            {
                result = square.squares.Left(square, number);
            }
            else //if (this.Check_id_is_right())
            {
                result = square.squares.Right(square, number);
            }
        }
        return result;
    }

    public ASquare Forward(APiece piece, int number = 0)
    {
        ASquare result = null;
        if (this != null)
        {
            if (this.Check_id_is_up())
            {
                result = piece.square.squares.Up(piece.square, number);
            }
            else if (this.Check_id_is_down())
            {
                result = piece.square.squares.Down(piece.square, number);
            }
            else if (this.Check_id_is_left())
            {
                result = piece.square.squares.Left(piece.square, number);
            }
            else //if (this.Check_id_is_right())
            {
                result = piece.square.squares.Right(piece.square, number);
            }
        }
        return result;
    }

    #endregion

}
