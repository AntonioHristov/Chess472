﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_E, ID_2);
    }
}