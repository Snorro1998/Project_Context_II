using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingSetter : Singleton<PostProcessingSetter>
{
    public Volume postVolum;
    private ColorAdjustments cols;

    // Start is called before the first frame update
    public void UpdatePostProcessing()
    {
        Debug.Log("UpdatePostProcessing");
        postVolum.profile.TryGet(out cols);

        int val = 0;
        switch (GameManager.Instance.musicInt)
        {
            default:
                Debug.Log("default");
                val = -80;
                break;
            case 1:
                val = -50;
                break;
            case 2:
                val = -20;
                break;
            case 3:
                val = 0;
                break;
        }
        cols.saturation.value = val;
    }
}
