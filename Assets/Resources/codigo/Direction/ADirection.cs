using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADirection : MonoBehaviour
{
    #region Methods

    public abstract ASquare Forward(ASquare square, int number);
    public abstract ASquare Forward(APiece piece, int number);
    public abstract ASquare Back(ASquare square, int number);
    public abstract ASquare Back(APiece piece, int number);
    public abstract ASquare Left_side(ASquare square, int number);
    public abstract ASquare Left_side(APiece piece, int number);
    public abstract ASquare Right_side(ASquare square, int number);
    public abstract ASquare Right_side(APiece piece, int number);
    public abstract ASquare Forward_Left(ASquare square, int number_forward, int number_left);
    public abstract ASquare Forward_Left(APiece piece, int number_forward, int number_left);
    public abstract ASquare Forward_Right(ASquare square, int number_forward, int number_right);
    public abstract ASquare Forward_Right(APiece piece, int number_forward, int number_right);
    public abstract ASquare Back_Left(ASquare square, int number_back, int number_left);
    public abstract ASquare Back_Left(APiece piece, int number_back, int number_left);
    public abstract ASquare Back_Right(ASquare square, int number_back, int number_right);
    public abstract ASquare Back_Right(APiece piece, int number_back, int number_right);



    public virtual ASquare Forward_Left_diagonal(ASquare square, int number)
    {
        return this.Forward_Left(square, number, number);
    }

    public virtual ASquare Forward_Left_diagonal(APiece piece, int number)
    {
        return this.Forward_Left(piece.square, number, number);
    }

    public virtual ASquare Forward_Right_diagonal(ASquare square, int number)
    {
        return this.Forward_Right(square, number, number);
    }

    public virtual ASquare Forward_Right_diagonal(APiece piece, int number)
    {
        return this.Forward_Right(piece.square, number, number);
    }

    public virtual ASquare Back_Left_diagonal(ASquare square, int number)
    {
        return this.Back_Left(square, number, number);
    }

    public virtual ASquare Back_Left_diagonal(APiece piece, int number)
    {
        return this.Back_Left(piece.square, number, number);
    }

    public virtual ASquare Back_Right_diagonal(ASquare square, int number)
    {
        return this.Back_Right(square, number, number);
    }

    public virtual ASquare Back_Right_diagonal(APiece piece, int number)
    {
        return this.Back_Right(piece.square, number, number);
    }


    public virtual ASquare[] Forward(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Forward(square, count) != null; count++)
        {
            result.Add(this.Forward(square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Forward(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Forward(piece.square, count) != null; count++)
        {
            result.Add(this.Forward(piece.square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Back(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Back(square, count) != null; count++)
        {
            result.Add(this.Back(square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Back(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Back(piece.square, count) != null; count++)
        {
            result.Add(this.Back(piece.square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Left_side(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Left_side(square, count) != null; count++)
        {
            result.Add(this.Left_side(square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Left_side(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Left_side(piece.square, count) != null; count++)
        {
            result.Add(this.Left_side(piece.square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Right_side(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Right_side(square, count) != null; count++)
        {
            result.Add(this.Right_side(square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Right_side(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Right_side(piece.square, count) != null; count++)
        {
            result.Add(this.Right_side(piece.square, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Forward_Left_diagonal(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Forward_Left(square, count, count) != null; count++)
        {
            result.Add(this.Forward_Left(square, count, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Forward_Left_diagonal(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Forward_Left(piece.square, count, count) != null; count++)
        {
            result.Add(this.Forward_Left(piece.square, count, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Forward_Right_diagonal(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Forward_Right(square, count, count) != null; count++)
        {
            result.Add(this.Forward_Right(square, count, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Forward_Right_diagonal(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Forward_Right(piece.square, count, count) != null; count++)
        {
            result.Add(this.Forward_Right(piece.square, count, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Back_Left_diagonal(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Back_Left(square, count, count) != null; count++)
        {
            result.Add(this.Back_Left(square, count, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Back_Left_diagonal(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Back_Left(piece.square, count, count) != null; count++)
        {
            result.Add(this.Back_Left(piece.square, count, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Back_Right_diagonal(ASquare square)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Back_Right(square, count, count) != null; count++)
        {
            result.Add(this.Back_Right(square, count, count));
        }
        return result.ToArray();
    }

    public virtual ASquare[] Back_Right_diagonal(APiece piece)
    {
        var result = new List<ASquare>();
        for (int count = 1; this.Back_Right(piece.square, count, count) != null; count++)
        {
            result.Add(this.Back_Right(piece.square, count, count));
        }
        return result.ToArray();
    }

    #endregion
}
