using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ABox : MonoBehaviour
{
    public AButton[] buttons;

    public void Awake()
    {
        this.buttons = this.GetComponentsInChildren<AButton>();
    }


    public void Show()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void Activate_button(AButton button)
    {
        if (button && button.gameObject && !button.gameObject.activeSelf)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Desactivate_button(AButton button)
    {
        if (button && button.gameObject && button.gameObject.activeSelf)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void Activate_all_buttons()
    {
        foreach (AButton button in this.buttons)
        {
            this.Activate_button(button);
        }
    }

    public void Desactivate_all_buttons()
    {
        foreach (AButton button in this.buttons)
        {
            this.Desactivate_button(button);
        }
    }

    public AButton[] Get_all_buttons()
    {
        return this.buttons;
    }

    public AButton Get_button_by_sprite(Sprite sprite)
    {
        foreach (AButton button in this.buttons)
        {
            if (button.GetComponent<Image>().sprite == sprite)
            {
                return button;
            }
        }
        return null;
    }
}
