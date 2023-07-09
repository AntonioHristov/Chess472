using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_queen : AQueen
{
    public override bool is_white { get; set; }

    new public void Awake()
    {
        base.Awake();
        this.is_white = true;
    }
}