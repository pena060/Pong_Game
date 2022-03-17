using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerControls playercontrols;// controls for player 1
    private float vertSpeed = 8f;// speed of player 1
    private float movementInput;// float will read players inputs

    private void Awake() {
        playercontrols = new PlayerControls();// new controls object
    }

    private void OnEnable() {
        playercontrols.Enable();// enable object
    }

    private void OnDisable() {
        playercontrols.Disable();//disable object
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = playercontrols.Move.Vertical.ReadValue<float>();// capture user vertical input
    }

    void FixedUpdate() {
        //change players y position based on inputs
        Vector3 currentPosition = transform.position;
        currentPosition.y += movementInput * vertSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
