using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour{
    private GameObject panel;

    // Start is called before the first frame update
    void Start(){
        panel = GameObject.FindGameObjectWithTag("PausePanel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!panel.activeSelf){
                panel.SetActive(true);
                panel.GetComponent<PauseManager>().activate();
            }
            else {
                panel.GetComponent<PauseManager>().deactivate();
                panel.SetActive(false);
            }
            
        }      
    }
}
