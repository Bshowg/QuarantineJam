using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 1.0f;
    private bool moveRight=false;
    private bool moveLeft=false;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.position -= Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) || (moveRight && !moveLeft))
            transform.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) || (moveRight && !moveLeft))
            transform.position -= Vector3.right * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            ////TODO
        }
    }

   
}
