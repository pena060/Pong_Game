using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPongGoal : MonoBehaviour
{


    [SerializeField] Text score1;
    [SerializeField] Text score2;


    [SerializeField] int p1Score = 0;// player 1 score
    [SerializeField] int p2Score = 0;// player 2 score


    private void Update() {
        updateScore();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Goal1"){// give player 2 a point
            p2Score++;
        } else if(other.tag == "Goal2"){// give player 1 a point
            p1Score++;
        }
        
    }



    void updateScore(){
        score2.text = p2Score.ToString();
        score1.text = p1Score.ToString();
    }
}
