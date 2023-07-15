using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Btn_white_queen : AButton
{
    new public void Awake()
    {
        base.Awake();
        this.GetComponent<Image>().sprite = Sprites.Get_white_queen();
        this.GetComponent<Button>().interactable = true;
    }
}