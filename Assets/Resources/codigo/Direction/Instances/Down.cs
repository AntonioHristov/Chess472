using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : ADirection
{
    public override int id_direction { get; set; }

    void Awake()
    {
        this.id_direction = ID_DOWN;
    }
}
