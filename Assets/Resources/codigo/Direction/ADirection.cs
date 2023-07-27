using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADirection : MonoBehaviour
{
    #region Methods

    public abstract ASquare Forward(ASquare square, int number = 0);
    public abstract ASquare Forward(APiece piece, int number = 0);

    #endregion
}
