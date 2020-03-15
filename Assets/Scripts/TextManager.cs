using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour{
    public GameObject text;

    public void requireTexts(List<GameObject> subjects) {
        foreach (GameObject g in subjects) {


            GameObject newText = GameObject.Instantiate(text) as GameObject;
            newText.transform.SetParent(transform);
            newText.GetComponent<WigglyWaggly>().subject = g;
        }
    
    }
}
