using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform location;
    Rigidbody2D ThisBody;
    public Direction currentDirection;
    public float walkForce = 4f;
    public float rot;

    public enum Direction
    {
        LEFT, RIGHT
    }

    // Start is called before the first frame update
    void Start()
    {
        location = this.gameObject.GetComponent<Transform>();
        ThisBody = this.gameObject.GetComponent<Rigidbody2D>();
        currentDirection = Direction.LEFT;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDirection == Direction.LEFT)
            ThisBody.AddForce(Vector2.left * walkForce);
        else
            ThisBody.AddForce(Vector2.right * walkForce);
        ThisBody.velocity = new Vector2( Mathf.Clamp( ThisBody.velocity.x, -.1f, .1f ) , Mathf.Clamp( ThisBody.velocity.y, -.1f, .1f ) );

        rot = ThisBody.rotation;
        ThisBody.rotation = Mathf.Clamp(ThisBody.rotation, -45f, 45f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.tag == "TurnAround")
        {
            Debug.Log("Tag = TurnAround");
            swapDirection();  
        }
          
    }

    private void swapDirection()
    {
        if (transform.rotation.y == 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 1);
            currentDirection = Direction.RIGHT;
        }
        else
        {
            transform.rotation = transform.rotation = new Quaternion(0, 0, 0, 1);
            currentDirection = Direction.LEFT;
        }
            
        /*
        if (currentDirection == Direction.LEFT)
            currentDirection = Direction.RIGHT;
        else
            currentDirection = Direction.LEFT;
        */
    }
}
