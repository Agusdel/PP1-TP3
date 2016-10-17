using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float initialVerticalVelocity = 0;
    public float initialHorizontalVelocity = 0;
    public float verticalSpeed;
    public float horizontalSpeed;
    private bool alive;
    private float speed = 1f;
    private float verticalVelocity;
    private float horizontalVelocity;
    private int horizontalDirection;
    private float time;


    void Start () {
        alive = true;
        verticalVelocity = initialVerticalVelocity;
        horizontalVelocity = initialHorizontalVelocity;
        horizontalDirection = 1;
        time = 0;
    }
    

    void Update () {
        time += Time.deltaTime;
        verticalVelocity += speed * Time.deltaTime * verticalSpeed;
        horizontalVelocity += speed * Time.deltaTime * horizontalSpeed;
        if (time >= 2){
            horizontalDirection *= -1;
            time = 0;
        }

        transform.position = new Vector3(transform.position.x +  horizontalDirection*horizontalVelocity*Time.deltaTime, transform.position.y - verticalVelocity * Time.deltaTime,transform.position.z); 

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enemy colision");
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
