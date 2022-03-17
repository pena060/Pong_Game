
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    private PlayerInput playerInput;
    private PlayerMovement playerMovement;

    private void Awake() {
        var playerMovers = FindObjectsOfType<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        var index = playerInput.playerIndex;
        playerMovement = playerMovers.FirstOrDefault(m => m.getPlayerIndex() == index);
    }
    public void onMove(CallbackContext context){
        playerMovement.inputVector = context.ReadValue<float>();
    }
}
