﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_D, ID_6);
    }
}