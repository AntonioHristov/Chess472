using UnityEngine;
using UnityEngine.UI;

public class Box_promote : ABox
{
    //public Button White_queen;
    //public Button White_rook;
    //public Button White_bishop;
    //public Button White_knight;
    //public Button Black_queen;
    //public Button Black_rook;
    //public Button Black_bishop;
    //public Button Black_knight;

    //public bool mostrando_caja_de_texto = false;


    public new void Show()
    {
        this.Desactivate_all_buttons();
        if (APawn.promotion.is_white)
        {
            base.Activate_button(this.Get_button_white_queen());
            base.Activate_button(this.Get_button_white_rook());
            base.Activate_button(this.Get_button_white_bishop());
            base.Activate_button(this.Get_button_white_knight());
        }
        else
        {
            base.Activate_button(this.Get_button_black_queen());
            base.Activate_button(this.Get_button_black_rook());
            base.Activate_button(this.Get_button_black_bishop());
            base.Activate_button(this.Get_button_black_knight());
        }
        base.Show();
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
