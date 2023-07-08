using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A1 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_A, ID_1);
    }
}
