using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbilityRange : MonoBehaviour{

    // todo: pensare bene a come farlo

    // 2 metodi: 1 che trova tutti i bersagli nel range, 1 che checka se un punti è nel range

    public abstract List<GameObject> getTarget(Vector2 selectedPos); //
    public abstract List<GameObject> getTargetsInRange();
}
