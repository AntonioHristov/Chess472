using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_white_rook : AButton
{
    new public void Awake()
    {
        base.Awake();
        this.GetComponent<Image>().sprite = Sprites.Get_white_rook();
        this.GetComponent<Button>().interactable = true;
    }
}