using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_C, ID_1);
    }
}