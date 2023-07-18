using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AOnlyImage : MonoBehaviour
{
    public void Awake()
    {
        this.gameObject.AddComponent<Image>();
    }
}
