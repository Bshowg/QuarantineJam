using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrowd : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    Camera camera;

    public int initSpawn=100;
    [SerializeField]
    public static int maxSpawn = 150;
    public static float timestepBase = 0.15f;
    public float timestep = 0f; ///DEBUG
    public int  currentlySpawned=0;///DEBUG
    public Color color;

    public GameObject personPrefab;

    private static List<Transform> crowd = new List<Transform>();
    private float radius;
    private Bounds bounds;
    private GameObject player;
    private GameManager GM;
    private int currentObjective=0;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 8, true);
        player = GameObject.FindGameObjectWithTag("Player");
        GM = FindObjectOfType<GameManager>();
        bounds = new Bounds(center, size);
        radius = personPrefab.GetComponent<BoxCollider2D>().bounds.size.x;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        for (int i = 0; i < initSpawn; i++)
        {
            SpawnPerson();
        }
        //SpawnPerson();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bounds.Contains(player.transform.position)){
            timestep += Time.deltaTime;
            Debug.Log(crowd.Count);
            if (timestep >= timestepBase && crowd.Count<maxSpawn)
            {
                timestep = 0;
                SpawnPerson();

            }
        }
        
        currentlySpawned = crowd.Count; ///DEBUG
    }

    void SpawnPerson()
    {
        Vector3 pos=randomPosition();

        
        while (Physics2D.OverlapCircle(pos, radius) || !checkNotVisible(pos))
        {
            pos = randomPosition();
        }
        //Vector3 pos = center + new Vector3(NextGaussian(), NextGaussian(), -1f);
        //if (checkNotVisible(pos))
        //{
            
        var p = Instantiate(personPrefab);
        p.transform.position = pos;
        crowd.Add(p.transform);
        //}
        
        
    }

    void MovePerson(GameObject boid)
    {
        Vector3 pos = randomPosition();


        while (Physics2D.OverlapCircle(pos, radius) || !checkNotVisible(pos))
        {
            pos = randomPosition();
        }

        boid.transform.position = pos;
    }

    bool checkNotVisible(Vector3 pos)
    {
        var viewportPosition = camera.WorldToViewportPoint(pos);
        Debug.Log(viewportPosition);
        if ((viewportPosition.x > -0.1 && viewportPosition.x < 1.1) && (viewportPosition.y > -0.1 && viewportPosition.y < 1.1))
        {
            return false;
        }
        return true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(center, size);
    }

    private float NextGaussian()
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.Range(0f,1f) - 1.0f;
            v = 2.0f * UnityEngine.Random.Range(0f,1f) - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);
        Debug.Log(S);
        float fac =(float) Math.Sqrt(-2.0f * Math.Log(S) / S);
        return u * fac;
    }

    private Vector3 randomPosition()
    {
        return center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), UnityEngine.Random.Range(-size.y / 2, size.y / 2), -1f);
    }

    public bool insideBounds(Vector2 pos)
    {
        if (bounds.Contains(pos) && Physics2D.OverlapCircle(pos, radius))
        {
            return true;
        }
        return false;
    }

    public void boidKilled(GameObject b)
    {
        crowd.Remove(b.transform);
        Destroy(b);
         
    }

    public void UpdateMax(int amount)
    {
        maxSpawn += amount;
        timestepBase -= 0.05f;
    }
}
