using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float spreadFactor;
    public int damage;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
    }

    void Start()
    {
        var rot = transform.rotation;
        transform.rotation = rot * Quaternion.Euler(0, 0, Random.Range(-spreadFactor, spreadFactor));
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().ApplyDamage(damage);
            Hit();
        }
    }
}
