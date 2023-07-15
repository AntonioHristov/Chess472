using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_white_bishop : AButton
{
    new public void Awake()
    {
        base.Awake();
        this.GetComponent<Image>().sprite = Sprites.Get_white_bishop();
        this.GetComponent<Button>().interactable = true;
    }
}