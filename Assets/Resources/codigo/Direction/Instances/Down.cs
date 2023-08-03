using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : ADirection
{
    public static Down Instance
    {
        get
        {
            if (FindObjectOfType<Down>())
            {
                return FindObjectOfType<Down>();
            }
            else
            {
                var new_instance = new GameObject().AddComponent<Down>();
                new_instance.name = new_instance.GetType().Name;
                return new_instance;
            }
        }
    }

    /// <summary>
    /// Get Square forward from square, number times
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    /// 
    public override ASquare Forward(ASquare square, int number = 0)
    {
        if (!square) { return null; }
        return square.Down(number);
    }

    /// <summary>
    /// Get Square forward from square's piece, number times
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    public override ASquare Forward(APiece piece, int number = 0)
    {
        if (!piece) { return null; }
        return this.Forward(piece.square, number);
    }

    public override ASquare Back(ASquare square, int number)
    {
        if (!square) { return null; }
        return square.Up(number);
    }

    public override ASquare Back(APiece piece, int number)
    {
        if (!piece) { return null; }
        return this.Back(piece.square, number);
    }

    public override ASquare Left_side(ASquare square, int number)
    {
        if (!square) { return null; }
        return square.Right(number);
    }

    public override ASquare Left_side(APiece piece, int number)
    {
        if (!piece) { return null; }
        return this.Left_side(piece.square, number);
    }

    public override ASquare Right_side(ASquare square, int number)
    {
        if (!square) { return null; }
        return square.Left(number);
    }

    public override ASquare Right_side(APiece piece, int number)
    {
        if (!piece) { return null; }
        return this.Right_side(piece.square, number);
    }

    public override ASquare Forward_Left(ASquare square, int number_forward, int number_left)
    {
        if (!square) { return null; }
        return square.Down_right(number_forward, number_left);
    }

    public override ASquare Forward_Left(APiece piece, int number_forward, int number_left)
    {
        if (!piece) { return null; }
        return this.Forward_Left(piece.square, number_forward, number_left);
    }

    public override ASquare Forward_Right(ASquare square, int number_forward, int number_right)
    {
        if (!square) { return null; }
        return square.Down_left(number_forward, number_right);
    }

    public override ASquare Forward_Right(APiece piece, int number_forward, int number_right)
    {
        if (!piece) { return null; }
        return this.Forward_Right(piece.square, number_forward, number_right);
    }

    public override ASquare Back_Left(ASquare square, int number_back, int number_left)
    {
        if (!square) { return null; }
        return square.Up_right(number_back, number_left);
    }

    public override ASquare Back_Left(APiece piece, int number_back, int number_left)
    {
        if (!piece) { return null; }
        return this.Back_Left(piece.square, number_back, number_left);
    }

    public override ASquare Back_Right(ASquare square, int number_back, int number_right)
    {
        if (!square) { return null; }
        return square.Up_left(number_back, number_right);
    }

    public override ASquare Back_Right(APiece piece, int number_back, int number_right)
    {
        if (!piece) { return null; }
        return this.Back_Right(piece.square, number_back, number_right);
    }
}
