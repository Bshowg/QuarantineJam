using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRangeTest : MonoBehaviour{
    float t = 1f;
    
    void Start(){}

    // Update is called once per frame
    void Update(){
        t -= Time.deltaTime;
        if (t < 0f) {
            List<GameObject> x = GameObject.Find("char").GetComponent<BaseAbilityRange>().getTargetsInRange();
            int i = 0;
            foreach (GameObject y in x) {
                Debug.Log((i++) + ": Found an object: " + y.name);
            }
            t = 1;
        }

        
    }
}
