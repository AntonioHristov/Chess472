using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_H, ID_2);
    }
}