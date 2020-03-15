using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WigglyWaggly : MonoBehaviour{
    public float wiggleSpeed;
    public float timetolive;
    public GameObject subject = null;

    private RectTransform rt;


    private IEnumerator countdown() {
        yield return new WaitForSeconds(timetolive);
        Destroy(this.gameObject);
    }


    private void Start(){
        rt = gameObject.GetComponent<RectTransform>();
        StartCoroutine(countdown());
    }

    


    // Update is called once per frame
    void Update() {
        Debug.Log("Ciao: " + subject);
        if (subject != null) {
            Debug.Log(subject.name + Camera.main.WorldToScreenPoint(subject.transform.position));
            Vector2 pos = Camera.main.WorldToScreenPoint(subject.transform.position);
            transform.position = new Vector2((Random.Range(-50f, 50f) * wiggleSpeed * Time.deltaTime) + pos.x, (Random.Range(-50f, 50f) * wiggleSpeed * Time.deltaTime) + pos.y);
        }

        //rt.localPosition = new Vector2(rt.localPosition.x + (Random.Range(-5f, 5f) * wiggleSpeed * Time.deltaTime), rt.localPosition.y + (Random.Range(-5f, 5f) * wiggleSpeed * Time.deltaTime));
        
    }
}
