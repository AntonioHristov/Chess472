using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : ADirection
{
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
        return square.squares.Down(square, number);
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
        return piece.square.squares.Down(piece.square, number);
    }
}
