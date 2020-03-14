using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsDecentralized : MonoBehaviour{
    private static List<BoidsDecentralized> boidz = null;

    public float sightRadius;
    public float minimumAllowedDistance;

    public float pcWeight;
    public float pvWeight;

    public Vector2 velocity { get; private set; }

    private void Awake(){
        if (boidz == null) boidz = new List<BoidsDecentralized>();
        boidz.Add(this);
    }

    void Start(){
        velocity = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        Debug.Log("Boidz: " + boidz.Count);
    }

    void Update(){
        boidRule();
        Debug.Log(velocity); 
    }
    private void LateUpdate(){
        transform.Translate((velocity * Time.deltaTime));
    }




    private void boidRule() {
        Vector2 v1 = rule1();
        v1 = ((Vector2)transform.position - v1) * pcWeight;

        Debug.Log("V1: " + v1);
        Vector2 v2 = rule2();
        Debug.Log("V2: " + v2);
        Vector2 v3 = rule3();
        v3 = (velocity - v3) * pvWeight;
        Debug.Log("V3: " + v3);
        velocity += (v1 + v2 + v3);
   
    }

    private Vector2 rule1() {
        Vector2 percievedCenter = new Vector2(0,0);
        int numboids = 0;
        foreach (BoidsDecentralized b in boidz) {
            if (b != this && Vector2.Distance(transform.position, b.transform.position) < sightRadius ) {
                percievedCenter += (Vector2)b.transform.position;
                numboids++;
            }
        }

        if (numboids > 0) percievedCenter /= numboids;
        return percievedCenter;
    }

    private Vector2 rule2() {
        Vector2 keepDistance = new Vector2(0, 0);
        foreach (BoidsDecentralized b in boidz){
            if (b != this && Vector2.Distance(b.transform.position, transform.position) < minimumAllowedDistance){
                keepDistance -= ((Vector2)b.transform.position - (Vector2)transform.position);
            }
        }
        return keepDistance;
    }

    private Vector3 rule3() {
        Vector2 percievedVelocity = new Vector2(0, 0);
        int numboids = 0;
        foreach (BoidsDecentralized b in boidz){
            if (b != this && Vector2.Distance(transform.position, b.transform.position) < sightRadius){
                percievedVelocity += b.velocity; 
                numboids++;
            }
        }
        if (numboids > 0)  percievedVelocity /= numboids;
        return percievedVelocity;
    }

}

