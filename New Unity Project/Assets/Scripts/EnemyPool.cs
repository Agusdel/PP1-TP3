using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyPool : MonoBehaviour
{

    public int poolSize = 10;
    public GameObject enemy;
    private List<GameObject> activeObjects;
    private List<GameObject> poolObjects;
    public bool perdio;

    void Start()
    {
        activeObjects = new List<GameObject>();
        poolObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.name = "Enemy_" + (i+1);
            poolObjects.Add(obj);
            obj.SetActive(false);
        }
        perdio = false;
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
        // desactivo los que colisionaron o los que tocaron el fondo.
        for (int i = 0; i < activeObjects.Count; i++)
        {
            Enemy enemy = activeObjects[i].GetComponent<Enemy>();
            if (!enemy.isAlive())
            {
                Debug.Log("Pool object destroyed.");
                Destroy(activeObjects[i]);
            }
            if (enemy.transform.position.y <= -5.5f)
            {
                Debug.Log("You lose.");
                perdio = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            if (activeObjects.Count > 0)
            {
                Destroy(activeObjects[activeObjects.Count - 1]);
                Debug.Log("Pool object destroyed.");
            }
        }
    }

    public void Spawn(GameObject obj)
    {
        if (poolObjects.Count > 0)
        {
            obj.transform.position = new Vector2(Random.Range(-2f, 2f), 6.26f);
            Enemy enemy = obj.GetComponent<Enemy>();
            if (enemy != null){
                enemy.Restart();
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

    public bool SigueElJuego()
    {
        return !perdio;
    }
}
