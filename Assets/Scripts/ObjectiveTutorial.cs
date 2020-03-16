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
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Ciao");
            ti_obj = GameObject.Instantiate(tutorialinfo);
            ti_obj.transform.SetParent(canvas.transform);
            ti_obj.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }
        
    }

    private void Update(){
        if (ti_obj != null) {
            Vector2 c = Camera.main.WorldToScreenPoint(transform.position);

            ti_obj.transform.position = new Vector2(c.x + 200, c.y + 50);
        }        
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" && ti_obj != null) Destroy(ti_obj); 
        
    }
}
