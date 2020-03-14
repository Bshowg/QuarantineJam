using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 1.0f;
    [SerializeField] private float currentSpeed = 1.0f;
    [SerializeField] private int peopleAround = 0;
    [SerializeField] private float reduceBy = 0.1f;
    [SerializeField] private float minSpeed = 0.2f;
    [SerializeField] private float paranoiaRadius = 5f;
    [SerializeField] private float interactionDistance = 1f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        movement = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        UpdateSpeed();
        Move();
        Interact();
    }

    void Move()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.magnitude > 1.0f) movement.Normalize();
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        rb.MovePosition(rb.position + movement * currentSpeed * Time.deltaTime);
    }

    void UpdateSpeed()
    {
        int crowdLayer = 1 << LayerMask.NameToLayer("Crowd");
        Collider2D[] people = Physics2D.OverlapCircleAll(transform.position, paranoiaRadius, crowdLayer);
        peopleAround = people.Length;
        //formula da rivedere
        float updatedSpeed = baseSpeed - reduceBy * people.Length;
        currentSpeed = Mathf.Max(minSpeed, updatedSpeed);
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, movement, interactionDistance);
            if (hit[1].collider.GetComponent<Objective>() != null)
            {
                hit[1].collider.GetComponent<Objective>().Interaction();
            }
        }
    }
}
