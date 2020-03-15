using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeerPressure : MonoBehaviour{
    public float radius;
    
    
    
    private int crowdLayer = 1 << LayerMask.NameToLayer("Crowd");

    private bool continueChecking = true;

    private IEnumerator checkForPeopleAround() {
        while (continueChecking) {
            Collider2D[] cs = Physics2D.OverlapCircleAll(transform.position, radius, crowdLayer);
            yield return new WaitForSeconds(.5f);
        }
    }

    private void requireTexts(int howMany) {
        Debug.Log("Required " + howMany + " texts");

    }

    void Start(){
        StartCoroutine(checkForPeopleAround());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
