using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    private ABox[] all;

    public Game game { get; set; }


    #region Show and Hide
    public void Show(ABox[] list)
    {
        foreach (ABox box in list)
        {
            box.Show();
        }
    }

    public void Show_all()
    {
        this.Show(this.all);
    }

    public void Hide(ABox[] list)
    {
        foreach (ABox box in list)
        {
            box.Hide();
        }
    }

    public void Hide_all()
    {
        this.Hide(this.all);
    }

    #endregion








    public Box_promote Get_box_promote(ABox[] list)
    {
        if (list != null)
        {
            foreach (ABox box in list)
            {
                if (box.GetComponent<Box_promote>())
                {
                    return box.GetComponent<Box_promote>();
                }
            }
        }

        return null;
    }

    public Box_promote Get_box_promote()
    {
        return this.Get_box_promote(this.all);
    }

    public Box_confirm_promotion Get_box_confirm_promotion(ABox[] list)
    {
        if (list != null)
        {
            foreach (ABox box in list)
            {
                if (box.GetComponent<Box_confirm_promotion>())
                {
                    return box.GetComponent<Box_confirm_promotion>();
                }
            }
        }
        return null;
    }

    public Box_confirm_promotion Get_box_confirm_promotion()
    {
        return this.Get_box_confirm_promotion(this.all);
    }

    public Box_stalemate Get_box_stalemate(ABox[] list)
    {
        if (list != null)
        {
            foreach (ABox box in list)
            {
                if (box.GetComponent<Box_stalemate>())
                {
                    return box.GetComponent<Box_stalemate>();
                }
            }
        }
        return null;
    }

    public Box_stalemate Get_box_stalemate()
    {
        return this.Get_box_stalemate(this.all);
    }

    public Box_checkmate Get_box_checkmate(ABox[] list)
    {
        if (list != null)
        {
            foreach (ABox box in list)
            {
                if (box.GetComponent<Box_checkmate>())
                {
                    return box.GetComponent<Box_checkmate>();
                }
            }
        }
        return null;
    }

    public Box_checkmate Get_box_checkmate()
    {
        return this.Get_box_checkmate(this.all);
    }






    void Awake()
    {
        this.all = this.GetComponentsInChildren<ABox>();   
        this.game = this.GetComponentInParent<Game>();
    }

    private void Start()
    {
        this.Hide_all();
    }
}
