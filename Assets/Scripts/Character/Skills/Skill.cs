using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour{
    private BaseAbilityRange range = null;
    private List<BaseAbilityEffect> effects = null;
    
    void Awake(){
        range = gameObject.GetComponent<BaseAbilityRange>();
        effects = new List<BaseAbilityEffect>();

        foreach (BaseAbilityEffect c in gameObject.GetComponents<BaseAbilityEffect>() ) {
            effects.Add(c);
        }
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void use() {
        List<GameObject> targets = range.getTargetsInRange(); // change vector2 to something else

        foreach (GameObject target in targets) {
            foreach (BaseAbilityEffect effect in effects) {
                effect.apply(target);
            }
        }

        
    }

    public List<GameObject> getTargetsInRange()
    {
        return range.getTargetsInRange();
    }
}
