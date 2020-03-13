using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour {
    public List<EquipSlotsTypes> slots; //{ get; private set; } //es: un armatura avrà [torso], uno spadone [primaryhand, secondaryhand]

    
    public bool isEquipped { get; private set; }

    public void onEquip(GameObject target) {
        if (isEquipped) return;

        // check if the selected item can be equipped.........
        if (checkEquippable(target)) { // in teoria viene gia fatto... si potrebbe eliminare? 
            isEquipped = true;

            // apply item effects.............................
            Feature[] allFeatures = gameObject.GetComponents<Feature>();
            for (int i = 0; i < allFeatures.Length; i++) {
                allFeatures[i].activate(target);
            }
        }
    }

    public void onUnequip(GameObject target) {
        if (!isEquipped) return;

        // apply item effects...............
        Feature[] allFeatures = gameObject.GetComponents<Feature>();
        for (int i = 0; i < allFeatures.Length; i++) {
            allFeatures[i].deactivate();
        }
        isEquipped = false;
    }

    public bool checkEquippable(GameObject target) {
        List<EquipSlotsTypes> freeSlots = target.GetComponent<Equipment>().freeSlots();
        foreach (EquipSlotsTypes x in slots) { // molto brutto, ma di base cicla sugli slot richiesti dall'oggetto; fino a che trova uno slot libero corrispondente continua, altrimenti ritona false
            if (freeSlots.Contains(x)) {
                freeSlots.Remove(x);
            } else {
                return false;
            }
        }
        return true;

   
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<character>())
        {
            var go = collision.gameObject;
            var eq = go.GetComponent<Equipment>();
            if (checkEquippable(go))
            {
                this.transform.position = collision.transform.position;
                this.gameObject.transform.SetParent(collision.transform);
                collision.gameObject.GetComponent<Equipment>().equipItem(this);
            }
            else if (!eq.inventoryFull()) { 
                this.transform.position = collision.transform.position;
                this.gameObject.transform.SetParent(collision.transform);
                collision.gameObject.GetComponent<Equipment>().addInventory(this);
            }
            
            
        }
    }





}
