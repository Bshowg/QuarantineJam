using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate() {
        Time.timeScale = 0f;
    }

    public void deactivate() {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void OnDestroy()
    {
        Time.timeScale = 1f;   
    }

    public void exit(){
        Application.Quit();
    }
}
