using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feature : MonoBehaviour{
    protected GameObject target { get; private set; } = null;

    public void activate(GameObject _target) {
        if (target == null) {
            target = _target;
            onApply();
        }

    }
    public void deactivate() {
        if (target != null) {
            onRemove();
            target = null;
        }
    }

    public void apply(GameObject _target) {
        if (target == null) {
            target = _target;
            onApply();
            target = null;
        }
    }

    protected abstract void onApply();
    protected abstract void onRemove();

}
