using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACan_be_promotion : APiece
{
    public bool is_promoted { get; set; }

    new public void Awake()
    {
        base.Awake();
        this.is_promoted = false;
    }
}