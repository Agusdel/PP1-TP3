using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{

    public int poolSize = 10;
    public GameObject enemy;
    private List<GameObject> activeObjects;
    private List<GameObject> poolObjects;

    void Start()
    {
        activeObjects = new List<GameObject>();
        poolObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            poolObjects.Add(obj);
            obj.SetActive(false);
        }
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (poolObjects.Count > 0)
            {
                Spawn(poolObjects[poolObjects.Count - 1]);
                Debug.Log("Pool object created.");
            }
            else
            {
                Debug.Log("Error creating pool object.");
            }
        }
    }

    public void Spawn(GameObject obj)
    {
        if (poolObjects.Count > 0)
        {
            obj.transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-0.65f, -0.77f));
            obj.SetActive(true);
            activeObjects.Add(obj);
            poolObjects.RemoveAt(poolObjects.Count - 1);
        }
    }

    public void Destroy(GameObject pooledObject)
    {
        EnemyPool poolableObject = pooledObject.GetComponent <EnemyPool>();
        if (pooledObject == null)
        {
            Debug.LogError("Trying to destroy a non poolable object");
            return;
        }
        poolableObject.Destroy(pooledObject);
    }
}
