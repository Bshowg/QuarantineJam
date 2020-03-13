using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    Transform player;
    Skill skill;
    [SerializeField]
    float speed = 1.0f;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        skill = this.GetComponent<Skill>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       this.transform.position= Vector3.MoveTowards(this.transform.position, player.position,speed*Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= 3f) {
        var p = skill.getTargetsInRange();
        if (p.Count > 0)
        {
            skill.use();
        }
            timer = 0f;
        }
    }
}
