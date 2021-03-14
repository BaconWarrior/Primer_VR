using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Fade : MonoBehaviour
{
    public static SCR_Fade instance;
    public Animator crlFade;
    public float fadeDuration;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void Fading()
    {
        crlFade.SetTrigger("Fade");
    }
}
