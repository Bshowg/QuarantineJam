using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTutorial : MonoBehaviour{
    public GameObject tutorialinfo;
    private Canvas canvas;
    private GameObject ti_obj = null;
    void Start(){
        canvas = GameObject.FindGameObjectWithTag("TextManager").GetComponent<Canvas>();
    }


    private void OnTriggerEnter2D(Collider2D collision){
        ti_obj = GameObject.Instantiate(tutorialinfo);
        ti_obj.transform.SetParent(canvas.transform);
        ti_obj.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (ti_obj != null) Destroy(ti_obj); 
        
    }
}
