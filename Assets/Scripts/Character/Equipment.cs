using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Equipment : MonoBehaviour {
    public List<EquipSlotsTypes> init_slots;
    private List<KeyValuePair<EquipSlotsTypes, Equippable>> slots = new List<KeyValuePair<EquipSlotsTypes, Equippable>>(); //--> keyvaluepair<Equip..., equippable>

    private List<Equippable> inventory = new List<Equippable>();
    private int maxInventory = 12;

    public void initSlots(List<EquipSlotsTypes> t) {
        slots = new List<KeyValuePair<EquipSlotsTypes, Equippable>>();

        //for each element in the list, add a new slot without anything on it
        for (int i = 0; i < t.Count; i++) {
            slots.Add(new KeyValuePair<EquipSlotsTypes, Equippable>(t[i], null));
        }
    }

    public void equipItem(Equippable item) {
        if (!item.checkEquippable(gameObject)) return;

        // apply item effect(s)...................
        item.onEquip(gameObject);
        // occupy the slots.......................
        for (int i = 0; i < item.slots.Count; i++) {
            for (int j = 0; j < slots.Count; j++) {
                if (slots[j].Key == item.slots[i] && slots[j].Value == null) {
                    slots[j] = new KeyValuePair<EquipSlotsTypes, Equippable>(item.slots[i], item);
                    break;
                }
            }
        }
    }

    public void unequipItem(Equippable item) {
        // check if the item was really already equipped....
        List<Equippable> l = (from x in slots select x.Value).ToList();
        if (!l.Contains(item)) return;

        // remove the effect(s).........................
        item.onUnequip(gameObject);
        //free the slots................................
        for (int i = 0; i < slots.Count; i++) {
            if (slots[i].Value == item) {
                KeyValuePair<EquipSlotsTypes, Equippable> oldentry = slots[i];
                slots[i] = new KeyValuePair<EquipSlotsTypes, Equippable>(oldentry.Key, null);
            }
        }


    }

    public List<EquipSlotsTypes> freeSlots() {
        return (from x in slots where x.Value == null select x.Key).ToList();
    }

    // Start is called before the first frame update
    void Awake()
    {

        foreach(EquipSlotsTypes e in init_slots)
        {
            slots.Add(new KeyValuePair<EquipSlotsTypes, Equippable>(e, null));
        }
        
        

    }

    public void addInventory(Equippable e)
    {
        inventory.Add(e);
    }

    public bool inventoryFull()
    {
        if (inventory.Count >= maxInventory)
        {
            return true;
        }
        else return false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
