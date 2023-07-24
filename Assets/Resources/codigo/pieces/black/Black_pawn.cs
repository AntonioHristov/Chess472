using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_pawn : APawn
{
    public override bool is_white { get; set; }
    public override ADirection direction { get; set; }

    new public void Awake()
    {
        base.Awake();
        this.is_white = false;
        if (this.gameObject.GetComponent<ADirection>())
        {
            this.direction = this.gameObject.GetComponent<ADirection>();
        }
        else if (!direction && !this.gameObject.GetComponent<ADirection>())
        {
            this.direction = this.gameObject.AddComponent(typeof(Down)) as Down;
        }
    }
}
