using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("Gun")]
    [SerializeField] private int Damage;
    [SerializeField] private float spread;
    [SerializeField] private int magazine;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPoint;
    public float rateOfFire;
    private bool canFire;
    private float timer;

    


    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab.GetComponent<Bullet>().spreadFactor = spread;
        bulletPrefab.GetComponent<Bullet>().damage = Damage;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        CanFire();
    }

    private void Fire()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            foreach (var item in shootPoint)
            {
                Instantiate(bulletPrefab, item.position, item.rotation);
            }

        }
    }

    private void CanFire()
    {

        if (GunHolder.mousePosDistanceFromPlayer < GunHolder.mousePosMinDistance)
        {
            canFire = false;
        }
        else if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > rateOfFire)
            {
                canFire = true;
                timer = 0;
            }
        }
    }
}
