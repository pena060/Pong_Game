using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollisonSound : MonoBehaviour
{


    private AudioSource ping;
    [SerializeField] GameObject ball;


    private void Awake() {
        ping = GetComponent<AudioSource>();
    }
  

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == ball){
            ping.Play();
        }
    }
}
