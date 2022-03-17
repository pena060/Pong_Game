using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    private float vertSpeed = 9f;// speed of player 1
    [HideInInspector] public float inputVector;
    [SerializeField] int playerIndex = 0;

    public int getPlayerIndex(){
        return playerIndex;
    }

    // Update is called once per frame
      void FixedUpdate() {
        //change players y position based on inputs
        Vector2 currentPosition = transform.position;
        currentPosition.y += inputVector * vertSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }


}
