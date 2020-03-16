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
        var scene = SceneManager.GetActiveScene().buildIndex + 1;
        if (scene >= SceneManager.sceneCount) { scene = 0; }
        SceneManager.LoadScene(scene);
    }
}
