using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeerPressure : MonoBehaviour{
    public float radius;


    private TextManager textmanager = null;
    private int crowdLayer = 0;

    private bool continueChecking = true;

    private IEnumerator checkForPeopleAround() {
        while (continueChecking) {
            Collider2D[] cs = Physics2D.OverlapCircleAll(transform.position, radius, crowdLayer);
            //requireTexts(cs.Length);
            List<GameObject> gs = new List<GameObject>();
            foreach(Collider2D c in cs) { 
                gs.Add(c.gameObject); 
            }
            textmanager.requireTexts(gs);

            

            yield return new WaitForSeconds(.5f);
        }
    }

    private void requireTexts(int howMany) {
        Debug.Log("Required " + howMany + " texts");


    }

    void Start(){
        crowdLayer = 1 << LayerMask.NameToLayer("Crowd");
        textmanager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
        StartCoroutine(checkForPeopleAround());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
