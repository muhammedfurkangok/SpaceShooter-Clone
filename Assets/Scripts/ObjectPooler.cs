using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public int amountToPool;
    public GameObject astroids;
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i <amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(astroids);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i = 0; i <astroids.Count; i++)
        {
            if (!astroids[i].activeInHierarchy)
            {
                return astroids[i];
            }
        }
        return null;
    }

  
      
}
