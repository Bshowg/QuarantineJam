using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createFloor : MonoBehaviour
{
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -60; i < 60; i++)
        {
            for (int j = -30; j < 33; j++)
            {
                var t = Instantiate(tile, this.transform);
                t.transform.position = new Vector3(i, j, -1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
