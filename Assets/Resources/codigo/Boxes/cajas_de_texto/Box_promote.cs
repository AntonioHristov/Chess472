using UnityEngine;
using UnityEngine.UI;

public class Box_promote : ABox
{
    public void Show(APawn pawn)
    {
        base.Desactivate_all_buttons();
        if (pawn.is_white)
        {
            Default_listeners_and_activate(pawn, this.Get_button_white_queen());
            Default_listeners_and_activate(pawn, this.Get_button_white_rook());
            Default_listeners_and_activate(pawn, this.Get_button_white_bishop());
            Default_listeners_and_activate(pawn, this.Get_button_white_knight());
        }
        else
        {
            Default_listeners_and_activate(pawn, this.Get_button_black_queen());
            Default_listeners_and_activate(pawn, this.Get_button_black_rook());
            Default_listeners_and_activate(pawn, this.Get_button_black_bishop());
            Default_listeners_and_activate(pawn, this.Get_button_black_knight());
        }
        base.Show();
    }

    public void Default_listeners(APawn pawn, AButton button)
    {
        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(button.GetComponent<Image>().sprite));
        button.GetComponent<Button>().onClick.AddListener(() => base.Hide());
    }

    public void Default_listeners_and_activate(APawn pawn, AButton button)
    {
        this.Default_listeners(pawn, button);
        base.Activate_button(button);
    }

    #region Get_buttons

    public AButton Get_button_white_queen()
    {
        return base.Get_button_by_sprite(Sprites.Get_white_queen());
    }

    public AButton Get_button_white_rook()
    {
        return base.Get_button_by_sprite(Sprites.Get_white_rook());
    }

    public AButton Get_button_white_bishop()
    {
        return base.Get_button_by_sprite(Sprites.Get_white_bishop());
    }

    public AButton Get_button_white_knight()
    {
        return base.Get_button_by_sprite(Sprites.Get_white_knight());
    }

    public AButton Get_button_black_queen()
    {
        return base.Get_button_by_sprite(Sprites.Get_black_queen());
    }

    public AButton Get_button_black_rook()
    {
        return base.Get_button_by_sprite(Sprites.Get_black_rook());
    }

    public AButton Get_button_black_bishop()
    {
        return base.Get_button_by_sprite(Sprites.Get_white_bishop());
    }

    public AButton Get_button_black_knight()
    {
        return base.Get_button_by_sprite(Sprites.Get_black_knight());
    }

    #endregion

}
