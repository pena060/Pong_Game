using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{
   
    private GuestControls guestcontrols;// controls for guest
    private float vertSpeed = 8f;// speed of guest
    private float movementInput;// float will read guest inputs

    private void Awake() {
        guestcontrols = new GuestControls();// new controls object
    }

    private void OnEnable() {
        guestcontrols.Enable();// enable object
    
    }

    private void OnDisable() {
        guestcontrols.Disable();//disable object
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = guestcontrols.Move.Vertical.ReadValue<float>();// capture user vertical input
    }

    void FixedUpdate() {
        //change players y position based on inputs
        Vector3 currentPosition = transform.position;
        currentPosition.y += movementInput * vertSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
