using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrowd : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    Camera camera;

    public GameObject personPrefab;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        for (int i = 0; i < 100; i++)
        {
            SpawnPerson();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPerson()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), -1f);
        if (checkNotVisible(pos))
        {
            var p = Instantiate(personPrefab);
            p.transform.position = pos;
        }
        
        
    }

    bool checkNotVisible(Vector3 pos)
    {
        var viewportPosition = camera.WorldToViewportPoint(pos);
        if ((viewportPosition.x > -0.1 && viewportPosition.x < 1.1) && (viewportPosition.y > -0.1 && viewportPosition.y < 1.1))
        {
            return false;
        }
        return true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.3f);
        Gizmos.DrawCube(center, size);
    }
}
