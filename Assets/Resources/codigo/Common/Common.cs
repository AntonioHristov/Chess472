using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Common
{
    /// <summary>
    /// ROTATE A GAMEOBJECT, THE IMAGE IS THE IDEA.
    /// BY DEFAULT ITS 180º WHICH IS TOP TO DOWN OR DOWN TO TOP THE IMAGE.
    /// THIS IS MAINLY USED IN THE BOARD AND THE PIECES AFTER A TURN IN THE GAME
    /// </summary>
    /// <param name="gameobject"></param>
    /// <param name="how_much"></param>
    public static void Rotate_z(GameObject gameobject, float how_much = 180f)
    {
        if (gameobject)
        {
            gameobject.transform.Rotate(new Vector3(0, 0, how_much));
        }
    }
}
