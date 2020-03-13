using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour{
    private float actualTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
       /*var sword= GameObject.Find("sword").GetComponent<Equippable>();
       var dagger = GameObject.Find("dagger").GetComponent<Equippable>();
        var character = gameObject.GetComponent<Equipment>();
        character.equipItem(sword);
        character.equipItem(dagger);*/

    }

    // Update is called once per frame
    void Update(){
        /*actualTime -= Time.deltaTime;
        if (actualTime < 3) {
            Characteristics c = gameObject.GetComponent<Characteristics>();
            Debug.Log("Character Sheet: S: " + c[CharTypes.Strenght] + " D: " + c[CharTypes.Dexterity] + " I: " + c[CharTypes.Intelligence]);
        }
        if (actualTime < 2) {
            Debug.Log("unequip....");
            var sword = GameObject.Find("sword").GetComponent<Equippable>();
            var dagger = GameObject.Find("dagger").GetComponent<Equippable>();
            var character = gameObject.GetComponent<Equipment>();
            character.unequipItem(sword);
            character.unequipItem(dagger);
        }*/

    }
}
