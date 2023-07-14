using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Btn_wq : AButton
{
    void Awake()
    {
        this.GetComponent<Image>().sprite = Sprites.Get_white_queen();
        this.GetComponent<Button>().onClick.AddListener(() => APawn.promotion.Open_box_confirm_promotion(Sprites.Get_white_queen()));
        this.GetComponent<Button>().interactable = true;
    }
    // Create other buttons like this and remove this comment
}