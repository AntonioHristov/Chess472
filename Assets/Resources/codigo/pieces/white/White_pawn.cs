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
        if (this.gameObject.GetComponent<ADirection>())
        {
            this.direction = this.gameObject.GetComponent<ADirection>();
        }
        else if ( !direction && !this.gameObject.GetComponent<ADirection>() )
        {
            this.direction = this.gameObject.AddComponent(typeof(Up)) as Up;
        }

        if(!this.gameObject.GetComponent<Image>())
        {
            Image img = gameObject.AddComponent(typeof(Image)) as Image;
            this.gameObject.GetComponent<Image>().sprite = Sprites.Get_white_pawn();
        }

    }
}
