using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : Singleton<LevelChanger>
{
    public Animator animator;

    public void FadeOut()
    {
        Debug.Log("FadeOut");
        animator.SetTrigger("FadeOut");
        animator.ResetTrigger("FadeIn");
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
        animator.ResetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        //Scenemanager.loadscene();
        SaveSystem.Instance.ChangeSceneP2();
    }
}
