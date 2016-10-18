using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {

    public int poolSize = 30;
    public GameObject bullet;
    private List<GameObject> activeObjects;
    private List<GameObject> poolObjects;

    void Start ()
    {
        activeObjects = new List<GameObject>();
        poolObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            if (obj)
            {
                obj.name = "Bullet_" + (i + 1);
                poolObjects.Add(obj);
                obj.SetActive(false);
            }
            else { Debug.LogError("No se encontró el gameObject bullet"); }
        }

    }
	
	void Update ()
    {

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (poolObjects.Count > 0)
            {
                Spawn(poolObjects[poolObjects.Count - 1]);
                Debug.Log("Bullet object created.");
            }
            else
            {
                Debug.Log("Error creating bullet pool object.");
            }
        }*/
        // desactivo las que colisionaron
        for (int i = 0; i < activeObjects.Count; i++)
        {
            Bullet bullet = activeObjects[i].GetComponent<Bullet>();
            if (!bullet.isAlive())
            {
                Debug.Log("Bullet destroyed.");
                Destroy(activeObjects[i]);
            }
        }

    }

    /*public void Spawn(GameObject obj)
    {
        if (poolObjects.Count > 0)
        {
            obj.transform.position = new Vector2(0f, initialYPosition);
            Bullet bullet = obj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Restart();
            }
            obj.SetActive(true);
            activeObjects.Add(obj);
            poolObjects.RemoveAt(poolObjects.Count - 1);
        }
    }*/
    public void Spawn(float initialX, float initialY)
    {
        if (poolObjects.Count > 0)
        {
            GameObject obj = poolObjects[poolObjects.Count - 1];
            obj.transform.position = new Vector2(initialX, initialY);
            Bullet bullet = obj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Restart();
            }
            obj.SetActive(true);
            activeObjects.Add(obj);
            poolObjects.RemoveAt(poolObjects.Count - 1);
        }
    }

    public void Destroy(GameObject obj)
    {
        obj.SetActive(false);
        poolObjects.Add(obj);
        activeObjects.Remove(obj);
    }
}
