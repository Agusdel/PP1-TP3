using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float initialVerticalVelocity = 0;
    public float initialHorizontalVelocity = 0;
    public float verticalSpeed;
    public float horizontalSpeed;
    private bool alive;
    private bool exploded;
    private float speed = 1f;
    private float verticalVelocity;
    private float horizontalVelocity;
    private int horizontalDirection;
    private float time;
    private Animator anim;
    private float explotionTime;


    void Start () {
        alive = true;
        exploded = false;
        verticalVelocity = initialVerticalVelocity;
        horizontalVelocity = initialHorizontalVelocity;
        horizontalDirection = 1;
        time = 0;
        anim = gameObject.GetComponent<Animator>();
    }
    

    void Update ()
    {
        anim.SetBool("Exploded", exploded);

        time += Time.deltaTime;
        if (!exploded)
        {
            verticalVelocity += speed * Time.deltaTime * verticalSpeed;
            horizontalVelocity += speed * Time.deltaTime * horizontalSpeed;
            if (time >= 2)
            {
                horizontalDirection *= -1;
                time = 0;
            }
        }

        if (alive && !exploded)
        {
            transform.position = new Vector3(transform.position.x + horizontalDirection * horizontalVelocity * Time.deltaTime, transform.position.y - verticalVelocity * Time.deltaTime, transform.position.z);
        }

        if (exploded && (time - explotionTime > 0.5f))
        {
            alive = false;
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enemy collision");
        exploded = true;
        time = 0;
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
