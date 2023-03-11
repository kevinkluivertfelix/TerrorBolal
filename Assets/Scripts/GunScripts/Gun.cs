using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("Gun")]
    [SerializeField] private int damage;
    [SerializeField] private float spread;
    [SerializeField] private int magazine;
    [SerializeField] private GameObject bulletPrefab;
    private Bullet bullet;
    [SerializeField] private Transform[] shootPoint;
    public float rateOfFire;
    [SerializeField] private bool canFire;
    private float timer;
    GameObject bulletPool;
    private PoolingManager pooling;
    [SerializeField] private List<GameObject> BulletPoolList = new List<GameObject>();
    [SerializeField] private int sizeOfPool;
    float nextfire;

    void Awake()
    {
        bulletPool = new GameObject(this.gameObject.name + "BulletPool");
        bullet = bulletPrefab.GetComponent<Bullet>();
    }

    private void OnEnable()
    { 
        bullet.spreadFactor = spread;
        bullet.damage = damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooling = PoolingManager.instance;
        pooling.ObjectPooling(BulletPoolList, bulletPrefab, bulletPool, sizeOfPool);
    }

    void Update()
    {
        CanFire();

        if (Time.time > nextfire && Input.GetMouseButton(0) && canFire)
        {
            nextfire = Time.time + rateOfFire;
            Fire();
        }
    }
    private void Fire()
    {
        for (int i = 0; i < shootPoint.Length; i++)
        {
            GameObject bulletPrefab = pooling.GetPooledObjects(BulletPoolList);

            if (bulletPrefab == null)
                return;

            bulletPrefab.transform.position = shootPoint[i].transform.position;
            bulletPrefab.transform.rotation = shootPoint[i].transform.rotation;
            bulletPrefab.SetActive(true);
        }
    }

    private void CanFire()
    {
        if (GunHolder.mousePosDistanceFromPlayer < GunHolder.mousePosMinDistance)
        {
            canFire = false;
        }
        else
        {
            canFire = true;
        }
    }
}
