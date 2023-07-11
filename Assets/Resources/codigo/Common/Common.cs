using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Common
{
    public static void Rotate_z(GameObject gameobject, float how_much = 180f)
    {
        if (gameobject)
        {
            gameobject.transform.Rotate(new Vector3(0, 0, how_much));
        }
    }
}
