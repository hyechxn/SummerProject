using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolusionFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetResolusion();
    }

    public void SetResolusion()
    {
        int sedWidth = 1920;
        int sedHeight = 1080;

        Screen.SetResolution(sedWidth, sedHeight, true);
    }
}
