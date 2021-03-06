using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongBallBounce : MonoBehaviour
{

    AudioManager audioManager;
    private Rigidbody2D rb;// rigidbody to get the component from within the gameobject
    [SerializeField] float ballSpeed = 0f; // speed of ball (change in inspector)
    SpriteRenderer ballVisual;

    Vector2 startPosition;// vector saves starting positon of ball

    public Text countdown;
    float time = 3;
    int countDownTimer;

    bool ballVelocityCalled = false;

    private void Awake() {
        gameObject.SetActive(true);
        ballVisual = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
        ballVisual.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// get the rigidbody component for the ball
        startPosition = transform.position;// save the starting positon of the ball for resets when scoring a goal
        countdown.text = time.ToString();
        audioManager.PlayCountdownSound();
         
    }


    private void OnTriggerEnter2D(Collider2D other) {
         transform.position = startPosition;// reset ball position
         BallVelocityInitialization();
    }

    private void Update() {
   
        if(time >= 0){
            countdown.text = countDownTimer.ToString();
            time -= Time.deltaTime;
            countDownTimer = Mathf.RoundToInt(time);
                if(!audioManager.countdownSoundIsPlaying() && countDownTimer > 0){
                    StartCoroutine(SCountdown());
                }
            if(countDownTimer == 0){
                countdown.text = "Start!";
                ballVisual.enabled = true;
                StartCoroutine(StartTextCountdown());
                if(!ballVelocityCalled){
                    audioManager.PlayStartSound();
                    ballVelocityCalled = true;
                    BallVelocityInitialization();
                }
            }  
        } 
    }


    private void BallVelocityInitialization(){// function sets a random velocity for the ball when it is reset at startup
        float x = (Random.Range(0,2) == 0 ? -1 : 1) * ballSpeed;// random +/- range for x-axis
        float y = (Random.Range(0,2) == 0 ? -1 : 1) * ballSpeed;// random +/- range for  y-axis
        rb.velocity = new Vector2(x, y);//set velocity
    }


    IEnumerator StartTextCountdown(){
         yield return new WaitForSeconds(0.5f);
         countdown.enabled = false; 
    }

    
    IEnumerator SCountdown(){
         yield return new WaitForSeconds(0.4f);
         audioManager.PlayCountdownSound();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player1"){
            rb.AddForce(transform.right * 40f);
        } else if(other.gameObject.tag == "Player2"){
            rb.AddForce(-(transform.right) * 40f);
        }
    }
}
