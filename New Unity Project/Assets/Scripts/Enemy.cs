using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public bool alive;
    public float initialVerticalVelocity = 0;
    public float initialHorizontalVelocity = 0;
    public float verticalSpeed;
    public float horizontalSpeed;
    float speed = 1f;
    float verticalVelocity;
    float horizontalVelocity;
    int horizontalDirection;
    float time;


    void Start () {
        alive = true;
        verticalVelocity = initialVerticalVelocity;
        horizontalVelocity = initialHorizontalVelocity;
        horizontalDirection = 1;
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

    public bool isAlive(){
        return alive;
    }
}
