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
        foreach (ABox box in list)
        {
            if(box.GetComponent<Box_promote>())
            {
                return box.GetComponent<Box_promote>();
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
        foreach (ABox box in list)
        {
            if (box.GetComponent<Box_confirm_promotion>())
            {
                return box.GetComponent<Box_confirm_promotion>();
            }
        }
        return null;
    }

    public Box_confirm_promotion Get_box_confirm_promotion()
    {
        return this.Get_box_confirm_promotion(this.all);
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
