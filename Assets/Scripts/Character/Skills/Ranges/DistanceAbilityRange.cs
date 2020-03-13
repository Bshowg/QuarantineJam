using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAbilityRange : BaseAbilityRange{
    public float minDistance;
    public float maxDistance;
   
    public override List<GameObject> getTarget(Vector2 origin) {
        Vector3 o = new Vector3(transform.position.x, transform.position.z, 0);
        float distance = Vector2.Distance(o, origin);

        if (distance <= maxDistance && distance >= minDistance) {
            // blabla
        }
        return null;
    }

    public override List<GameObject> getTargetsInRange() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, maxDistance);

        List<GameObject> targets = new List<GameObject>();
        foreach (Collider2D c in colliders) {
            if (Vector2.Distance(transform.position, c.transform.position) > minDistance) {
                targets.Add(c.gameObject);
            }
        }
        return targets;
    }
}
