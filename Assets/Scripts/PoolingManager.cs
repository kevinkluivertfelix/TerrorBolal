using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance;
    
    private void Awake()
    {
        instance = this;
    }
    //pooling

    public void ObjectPooling(List<GameObject> poolList, GameObject Prefab, GameObject Pool, int poolSize)
    {
        poolList.Clear();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject p = Instantiate(Prefab, Pool.transform);
            p.SetActive(false);

            poolList.Add(p);
        }
    }

    public GameObject GetPooledObjects(List<GameObject> pooledList)
    {
        for (int i = 0; i < pooledList.Count; i++)
        {
            if (!pooledList[i].activeInHierarchy)
                return pooledList[i];
        }

        return null;
    }

}
