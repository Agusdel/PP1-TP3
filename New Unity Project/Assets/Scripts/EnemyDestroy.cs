using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour
{

    private Enemy enemy;

    void Start()
    {
        enemy = gameObject.GetComponentInParent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //enemy.grounded = true;
    }
}