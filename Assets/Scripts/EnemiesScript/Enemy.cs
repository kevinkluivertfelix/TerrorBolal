using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyDamage;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = -transform.right * enemySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 8)
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponent<Wall>().WallHit(enemyDamage);
        }
    }
}
