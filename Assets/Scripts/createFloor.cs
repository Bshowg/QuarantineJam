using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createFloor : MonoBehaviour
{
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -20; i < 20; i++)
        {
            for (int j = -10; j < 11; j++)
            {
                var t = Instantiate(tile, this.transform);
                t.transform.position = new Vector3(i*3, j*3, -1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
