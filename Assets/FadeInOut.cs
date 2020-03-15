using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void FadeOut()
    {
        Debug.Log("FADE");
        anim.SetTrigger("FadeToBlack");
    }

    public void FadeOutComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
