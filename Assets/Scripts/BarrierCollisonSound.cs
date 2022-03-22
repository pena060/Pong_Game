using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollisonSound : MonoBehaviour
{


    AudioManager audioManager;
    [SerializeField] GameObject ball;



    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
    }
  

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == ball){
            audioManager.PlayPingBallSound();
        }
    }
}
