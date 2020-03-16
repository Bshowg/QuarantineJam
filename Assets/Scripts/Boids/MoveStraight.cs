using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    public int speed = 2;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetFloat("Vertical", -1);
        anim.SetFloat("Speed", speed);
        this.transform.position += -Vector3.up * speed * Time.deltaTime;
    }
}
