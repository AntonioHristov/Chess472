using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_king : AKing
{
    public override bool is_white { get; set; }

    new public void Awake()
    {
        base.Awake();
        this.is_white = true;
        TDirection_methods.Get_Up(this);
        base.Set_sprite(Sprites.Get_white_king());
    }
}