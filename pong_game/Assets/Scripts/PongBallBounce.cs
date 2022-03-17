using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallBounce : MonoBehaviour
{

    private Rigidbody2D rb;// rigidbody to get the component from within the gameobject
    [SerializeField] float ballSpeed = 0f; // speed of ball (change in inspector)
    Vector2 startPosition;// vector saves starting positon of ball

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();// get the rigidbody component for the ball
        startPosition = transform.position;// save the starting positon of the ball for resets when scoring a goal

        BallVelocityInitialization();// reset ball velocity
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
         transform.position = startPosition;// reset ball position
         BallVelocityInitialization();// reset ball velocity
    }




    private void BallVelocityInitialization(){// function sets a random velocity for the ball when it is reset at startup
        float x = (Random.Range(0,2) == 0 ? -1 : 1) * ballSpeed;// random +/- range for x-axis
        float y = (Random.Range(0,2) == 0 ? -1 : 1) * ballSpeed;// random +/- range for  y-axis
        rb.velocity = new Vector2(x, y);//set velocity
    }



}
