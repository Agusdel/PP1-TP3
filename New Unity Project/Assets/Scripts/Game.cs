using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject player;
    public GameObject enemPool;
    private EnemyPool enemyPool;
    private float time;
    private GameObject enemy;

    void Start () {

        GameObject play = (GameObject)Instantiate(player);
        if (play)
        {
            play.name = "Player";
        }
        else { Debug.LogError("Could not find GameObject Player"); }
        enemy = (GameObject)Instantiate(enemPool);
        if (enemy)
        {
            enemy.name = "Enemy Pool";
            enemyPool = enemy.GetComponent<EnemyPool>();
        }
        else { Debug.LogError("Could not find GameObject EnemyPool"); }

        time = 0f;
    }
	
	void Update () {
        time += Time.deltaTime;

        if (time >= 2f)
        {
            enemyPool.Spawn(Random.Range(-5f, 5f), Random.Range(6.26f, 6.26f + 3f));

            time = 0;
        }
	
	}
}
