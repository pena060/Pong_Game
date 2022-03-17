using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionPlayerSound : MonoBehaviour
{


    private AudioSource pong;
    [SerializeField] GameObject ball;

   private void Awake() {
       pong = GetComponent<AudioSource>();
   }


   private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject == ball){
           pong.Play();
       }
   }
}
