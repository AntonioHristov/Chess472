using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class White_pawn : APawn
{
    public override bool is_white { get; set; }

    public override ADirection direction { get; set; }

    new public void Awake() 
    {
        base.Awake();
        this.is_white = true;

        this.direction = new GameObject().AddComponent<Up>();

        // Create Up, etc instances and populate it in this.direction
        
        //base.Set_direction(Up);
        base.Set_sprite(Sprites.Get_white_pawn());
    }
}
