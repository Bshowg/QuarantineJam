using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createFloor : MonoBehaviour
{
    public int x_pos = 20;
    public int x_neg = -20;
    public int y_pos = 11;
    public int y_neg = -10;
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = x_neg; i < x_pos; i++)
        {
            for (int j = y_neg; j < y_pos; j++)
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
