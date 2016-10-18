using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float range = 10f;
    private bool alive;
    private bool exploded;
    private Animator anim;
    private Vector3 initialPosition;
    private float time;
    private float explotionTime;

    void Start ()
    {
        alive = true;
        exploded = false;
        anim = gameObject.GetComponent<Animator>();
        initialPosition = transform.position;
        time = 0;
    }


    void Update()
    {
        time += Time.deltaTime;

        anim.SetBool("Exploded", exploded);
        if (alive && !exploded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

        //range limiting
        if (!exploded && Mathf.Abs(transform.position.y - initialPosition.y) > range)
        {
            exploded = true;
            explotionTime = time;
        }

        if (exploded && (time - explotionTime > 0.5f) )
        {
            alive = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Bullet colision");
        exploded = true;
        explotionTime = time;
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
