using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour {
    public Dictionary<CharTypes, int> baseCharacteristics;
    public Dictionary<CharTypes, int> characteristics;

    /*public Characteristics(int s, int d, int i){
        baseCharacteristics.Add(CharTypes.Strenght, s);
        baseCharacteristics.Add(CharTypes.Dexterity, d);
        baseCharacteristics.Add(CharTypes.Intelligence, i);

        characteristics.Add(CharTypes.Strenght, s);
        characteristics.Add(CharTypes.Dexterity, d);
        characteristics.Add(CharTypes.Intelligence, i);
    }*/

        void Awake(){
        baseCharacteristics = new Dictionary<CharTypes, int>();
        characteristics =new Dictionary<CharTypes, int>();
        baseCharacteristics.Add(CharTypes.Strenght, 5);
        baseCharacteristics.Add(CharTypes.Dexterity,5);
        baseCharacteristics.Add(CharTypes.Intelligence,5);
        characteristics.Add(CharTypes.Strenght, 5);
        characteristics.Add(CharTypes.Dexterity, 5);
        characteristics.Add(CharTypes.Intelligence, 5);
    }

    public void tempMod(CharTypes c, int mod){
        characteristics[c] += mod;
    }

    public void permMod(CharTypes c, int mod){
        characteristics[c] += mod;
        baseCharacteristics[c] += mod;
    }

    // questa serve per fare l'overload delle parentesi quadre (Characteristics c = new Characteristics(); int x =  c[StatTypes.Strenght])
    public int this[CharTypes c ]{   
        get{return characteristics[c]; }
        set{}
    }


}
