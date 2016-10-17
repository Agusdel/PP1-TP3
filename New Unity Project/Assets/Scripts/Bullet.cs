using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float range = 10f;
    private bool alive;
    private Animator anim;
    private Vector3 initialPosition;

    void Start ()
    {
        alive = true;
        anim = gameObject.GetComponent<Animator>();
        initialPosition = transform.position;
    }


    void Update()
    {
        anim.SetBool("Exploded", !alive);
        if (alive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

        //range limiting
        if (Mathf.Abs(transform.position.y - initialPosition.y) > range)
        {
            alive = false;
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Bullet colision");
        alive = false;
    }


    public bool isAlive()
    {
        return alive;
    }

    public void Restart()
    {
        Start();
    }
}
