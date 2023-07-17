using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_confirm_promotion : ABox
{
    public void Show(APawn pawn, Sprite sprite_promotion)
    {
        base.Desactivate_all_buttons();

        this.GetComponentInChildren<Img_confirm_promotion>().GetComponent<Image>().sprite = sprite_promotion;
        Default_listeners_and_activate(pawn, this.Get_button_yes(), sprite_promotion);
        Default_listeners_and_activate(pawn, this.Get_button_no());

        base.Show();
    }

    public void Default_listeners(APawn pawn, Btn_yes button, Sprite sprite_promotion)
    {
        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponent<Button>().onClick.AddListener(() => pawn.Promote(sprite_promotion));
        button.GetComponent<Button>().onClick.AddListener(() => base.Hide());
    }

    public void Default_listeners(APawn pawn, Btn_no button)
    {
        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_promotion());
        button.GetComponent<Button>().onClick.AddListener(() => base.Hide());
    }

    public void Default_listeners_and_activate(APawn pawn, Btn_yes button, Sprite sprite_promotion)
    {
        this.Default_listeners(pawn, button, sprite_promotion);
        base.Activate_button(button);
    }

    public void Default_listeners_and_activate(APawn pawn, Btn_no button)
    {
        this.Default_listeners(pawn, button);
        base.Activate_button(button);
    }


    #region Get_buttons

    public Btn_yes Get_button_yes()
    {
        foreach (AButton button in base.Get_all_buttons())
        {
            if (button.GetComponent<Btn_yes>())
            {
                return button.GetComponent<Btn_yes>();
            }
        }
        return null;
    }

    
    public Btn_no Get_button_no()
    {
        foreach (AButton button in base.Get_all_buttons())
        {
            if (button.GetComponent<Btn_no>())
            {
                return button.GetComponent<Btn_no>();
            }
        }
        return null;
    }
    

    #endregion

}
