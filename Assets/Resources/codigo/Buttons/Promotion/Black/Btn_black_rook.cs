using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_black_rook : AButton
{
    new public void Awake()
    {
		base.Awake();
        this.GetComponent<Image>().sprite = Sprites.Get_black_rook();
        this.GetComponent<Button>().interactable = true;
    }
}