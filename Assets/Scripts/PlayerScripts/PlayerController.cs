using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        Move();
    }

    void Update()
    {        
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, horizontal * speed);
    }
}

