using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_king : AKing
{
    public override bool is_white { get; set; }

    new public void Awake()
    {
        base.Awake();
        this.is_white = false;
    }
}