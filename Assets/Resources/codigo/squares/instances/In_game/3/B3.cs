using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_B, ID_3);
    }
}
