using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifierFeature : Feature{
    public int amount;
    public CharTypes statType; // todo: questo va cambiato, potrebbe diventare un enum

    protected override void onApply() {
        target.GetComponent<Characteristics>().tempMod(statType, amount);
        return;
    }
    protected override void onRemove() {
       target.GetComponent<Characteristics>().tempMod(statType, -amount);
        return;
    }



}
