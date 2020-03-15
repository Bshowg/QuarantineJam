using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour{
    public GameObject text;
    public List<string> possibleLines;

    public void requireTexts(List<GameObject> subjects) {
        foreach (GameObject g in subjects) {


            GameObject newText = GameObject.Instantiate(text) as GameObject;
            newText.transform.SetParent(transform);
            newText.GetComponent<WigglyWaggly>().subject = g;
            if (possibleLines != null) {
                if (possibleLines.Count > 0) {
                    int l = Random.Range(0, possibleLines.Count);
                    string s = possibleLines[l];
                    newText.GetComponent<Text>().text = s;
                }
            }

        }
    
    }
}
