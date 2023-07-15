using UnityEngine;
using UnityEngine.UI;

public class Box_promote : ABox
{
    public void Show(APawn pawn)
    {
        base.Desactivate_all_buttons();
        if (pawn.is_white)
        {
            var button_white_queen = this.Get_button_white_queen();
            button_white_queen.GetComponent<Button>().onClick.RemoveAllListeners();
            button_white_queen.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_white_queen.GetComponent<Image>().sprite));
            button_white_queen.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            var button_white_rook = this.Get_button_white_rook();
            button_white_rook.GetComponent<Button>().onClick.RemoveAllListeners();
            button_white_rook.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_white_rook.GetComponent<Image>().sprite));
            button_white_rook.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            var button_white_bishop = this.Get_button_white_bishop();
            button_white_bishop.GetComponent<Button>().onClick.RemoveAllListeners();
            button_white_bishop.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_white_bishop.GetComponent<Image>().sprite));
            button_white_bishop.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            var button_white_knight = this.Get_button_white_knight();
            button_white_knight.GetComponent<Button>().onClick.RemoveAllListeners();
            button_white_knight.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_white_knight.GetComponent<Image>().sprite));
            button_white_knight.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            base.Activate_button(button_white_queen);
            base.Activate_button(button_white_rook);
            base.Activate_button(button_white_bishop);
            base.Activate_button(button_white_knight);
        }
        else
        {
            var button_black_queen = this.Get_button_black_queen();
            button_black_queen.GetComponent<Button>().onClick.RemoveAllListeners();
            button_black_queen.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_black_queen.GetComponent<Image>().sprite));
            button_black_queen.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            var button_black_rook = this.Get_button_black_rook();
            button_black_rook.GetComponent<Button>().onClick.RemoveAllListeners();
            button_black_rook.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_black_rook.GetComponent<Image>().sprite));
            button_black_rook.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            var button_black_bishop = this.Get_button_black_bishop();
            button_black_bishop.GetComponent<Button>().onClick.RemoveAllListeners();
            button_black_bishop.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_black_bishop.GetComponent<Image>().sprite));
            button_black_bishop.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            var button_black_knight = this.Get_button_black_knight();
            button_black_knight.GetComponent<Button>().onClick.RemoveAllListeners();
            button_black_knight.GetComponent<Button>().onClick.AddListener(() => pawn.Open_box_confirm_promotion(pawn, button_black_knight.GetComponent<Image>().sprite));
            button_black_knight.GetComponent<Button>().onClick.AddListener(() => this.Hide());

            base.Activate_button(button_black_queen);
            base.Activate_button(button_black_rook);
            base.Activate_button(button_black_bishop);
            base.Activate_button(button_black_knight);
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
