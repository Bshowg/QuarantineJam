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
            rt.localPosition = pos;
        }

        //rt.localPosition = new Vector2(rt.localPosition.x + (Random.Range(-5f, 5f) * wiggleSpeed * Time.deltaTime), rt.localPosition.y + (Random.Range(-5f, 5f) * wiggleSpeed * Time.deltaTime));
        
    }
}
