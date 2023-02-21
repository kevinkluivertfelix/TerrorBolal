using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;
    public float spreadFactor;
    public int damage;
    private float angleMod;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;


    void Start()
    {
        Destroy(gameObject, 2f);
        rb = GetComponent<Rigidbody2D>();

        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //BulletDirectionRotation();
        var rot = transform.rotation;
        transform.rotation = rot * Quaternion.Euler(0, 0, Random.Range(-spreadFactor, spreadFactor)); // t$$anonymous$$s is 90 degrees around y axis
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * force * Time.deltaTime;
    }

    private void BulletDirectionRotation()
    {
        //rb.velocity = Vector3.forward * force;
        //Vector3 direction = mousePos - transform.position;
        //Vector3 rotation = transform.position - mousePos;
        //rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0,0, rot+90);
    }
}
