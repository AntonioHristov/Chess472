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
        if( !direction )
        {
            this.direction = gameObject.AddComponent(typeof(Up)) as Up;
        }

        //Image img = gameObject.AddComponent(typeof(Image)) as Image;
        //this.gameObject.GetComponent<Image>().sprite = Sprites.Get_white_pawn();
    }
}
