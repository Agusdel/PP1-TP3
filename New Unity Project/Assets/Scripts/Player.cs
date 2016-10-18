using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float maxSpeed = 18f;
    public float boundary = 10;
    public float speed = 1f;
    private Vector3 initialPosition;
    private Rigidbody2D rb2d;
    private float horizontalSpeed;
    private BulletPool bulletPool;

    void Start () {
        initialPosition = transform.position;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        horizontalSpeed = 0;
        bulletPool = gameObject.GetComponent<BulletPool>();
    }
	
	void Update ()
    {
        horizontalSpeed = Input.GetAxis("Horizontal") * speed;

        rb2d.AddForce(Vector2.right * horizontalSpeed);

        //Speed limiting
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        //boundary limiting
        if (Mathf.Abs(transform.position.x - initialPosition.x) > boundary)
        {
            rb2d.velocity = new Vector2(-rb2d.velocity.x, rb2d.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Spawn(transform.position.x - 0.7f, transform.position.y + 1.2f);
            bulletPool.Spawn(transform.position.x + 0.7f, transform.position.y + 1.2f);
        }
    }
}
