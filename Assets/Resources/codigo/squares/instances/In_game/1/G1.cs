﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1 : ASquare
{
    new public void Awake()
    {
        base.Awake();
        Default_in_game(ID_G, ID_1);
    }
}