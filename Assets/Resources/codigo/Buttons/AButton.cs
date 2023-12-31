﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AButton : MonoBehaviour
{
    public void Awake()
    {
        this.gameObject.AddComponent<Image>();
        this.gameObject.AddComponent<Button>();
    }
}
