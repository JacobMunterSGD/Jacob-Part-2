using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{

    public void sixteenByNine()
    {
        Screen.SetResolution(1600, 900, false);
    }

    public void fullHD()
    {
        Screen.SetResolution(1920, 1080, false);
    }

}
