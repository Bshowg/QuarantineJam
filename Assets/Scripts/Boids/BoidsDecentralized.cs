using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsDecentralized : MonoBehaviour{
    private static List<BoidsDecentralized> boidz = null;
    private static GameObject player = null;
    private static float maxRadiusAroundPlayer = -1;
    private static float minRadiusAroundPlayer = -1;

    public float sightRadius;
    public float minimumAllowedDistance;

    public float pcWeight;
    public float pvWeight;

    public float speed;

    public Vector2 velocity { get; private set; }

    private bool continueCalcBoids = true;
    private float timeBetweenCalcs = .1f;


    IEnumerator boidsCoroutine() {
        while (continueCalcBoids) {
            boidRule();
            yield return new WaitForSeconds(timeBetweenCalcs);
        }
    }


    private void Awake(){
        if (minRadiusAroundPlayer < 0) minRadiusAroundPlayer = Camera.main.orthographicSize * 2.5f;
        if (maxRadiusAroundPlayer < 0) maxRadiusAroundPlayer = minRadiusAroundPlayer * 2.5f;
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        if (boidz == null) boidz = new List<BoidsDecentralized>();
        boidz.Add(this);
    }

    void Start(){
        velocity = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        Debug.Log("Boidz: " + boidz.Count);
        StartCoroutine(boidsCoroutine());

        minimumAllowedDistance += Random.Range(0, minimumAllowedDistance * .5f);
        sightRadius = sightRadius * Random.Range(.7f, 1.5f);
    }


    
    private void LateUpdate(){
        rearrangeAroundPlayer();

        transform.Translate((velocity * Time.deltaTime));
    }


    private void rearrangeAroundPlayer() {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log("MinDist is: " + minRadiusAroundPlayer);
        if (distance > 3 * minRadiusAroundPlayer) {
            Debug.Log("invoked");


            float radius = Random.Range(minRadiusAroundPlayer, maxRadiusAroundPlayer);
            float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
            Vector2 newpos = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
            transform.position = newpos;

        }
    }

    private void boidRule() {
        Vector2 v1 = rule1();

        v1 = (v1 - (Vector2)transform.position) * (pcWeight);

        Vector2 v2 = rule2(); 
        
        Vector2 v3 = rule3();
        v3 = (velocity - v3) * pvWeight;

        velocity *= .7f;
        velocity += (v1 + v2 + v3);
        velocity = velocity.normalized * speed;
   
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

