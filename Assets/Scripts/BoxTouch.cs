using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTouch : MonoBehaviour
{
    public static bool isBoxThrown = false;

    public void ThrowBox()
    {
        isBoxThrown = true;
    }
}
