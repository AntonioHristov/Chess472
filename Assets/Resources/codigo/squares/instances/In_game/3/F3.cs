using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_F, ID_3);
    }
}