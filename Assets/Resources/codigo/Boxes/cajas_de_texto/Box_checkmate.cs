using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_checkmate : Box_read
{
    new void Awake()
    {
        base.Awake();
        this.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        this.GetComponentInChildren<Button>().onClick.AddListener(() => base.Hide());
    }
}
