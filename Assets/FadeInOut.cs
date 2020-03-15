using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void FadeOut()
    {
        Debug.Log("FADE");
        anim.SetTrigger("FadeToBlack");
    }
}
