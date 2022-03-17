using UnityEngine;

public class BallPongGoal : MonoBehaviour
{


    private GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Goal1"){// give player 2 a point
            gm.updateP2Score();
        } else if(other.tag == "Goal2"){// give player 1 a point
            gm.updateP1Score();
        }
        
    }
}
