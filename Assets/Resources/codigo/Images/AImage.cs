using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AImage : MonoBehaviour
{
    public void Awake()
    {
        this.gameObject.AddComponent<Image>();
    }
}
