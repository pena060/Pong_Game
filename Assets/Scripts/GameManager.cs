using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    AudioManager audioManager;
    UIControls uiControls;
    private int p1Score;
    private int p2Score;

    private float timer;
    [SerializeField] Text score1;
    [SerializeField] Text score2;
    [SerializeField] Text winText;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject scoreUI;
    [SerializeField] GameObject ball;

    bool isPaused = false;

    private void Awake(){
        p1Score = 0;
        p2Score = 0;
        uiControls = new UIControls();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnEnable() {
        uiControls.Enable();
    }

    private void OnDisable() {
        uiControls.Disable();
    }


    private void Start() {
        uiControls.Pause.pauseGame.performed += _ => pauseTheScreen();//pause key pressed
    }
    // Update is called once per frame
    void Update()
    {
        updateScoreScreen();
        gameWin();
       
    }

    public void updateP1Score(){
        p1Score++;
    }

    public void updateP2Score(){
        p2Score++;
    }

    void updateScoreScreen(){
        score2.text = p2Score.ToString();
        score1.text = p1Score.ToString();
    }


    void pauseTheScreen(){
        if(isPaused){
            resumeGame();
        }else{  
            pauseGame();
        }
    }

    void pauseGame(){
        Time.timeScale = 0;
        isPaused = true;
        pauseScreen.SetActive(true);  
    }

    void resumeGame(){
        Time.timeScale = 1;
        isPaused = false;
        pauseScreen.SetActive(false);
    }

    public void gamereset(){
        resumeGame();
        resetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void quitGame(){
        Application.Quit();
    }

    void gameWin(){
        if(p1Score == 10 || p2Score == 10){
            Time.timeScale = 0;
            isPaused = true;
            scoreUI.SetActive(false);
            if(p1Score == 10){
                winText.text = "Player 1 Wins!";
            }else if(p2Score == 10){
                winText.text = "Player 2 Wins!";
            }

            resetScore();
            winUI.SetActive(true);
            audioManager.StopSound();
            audioManager.PlayWinSound();

            ball.SetActive(false);


            Time.timeScale = 1;
            Invoke("newGame", 2);  
        }
    }

    void resetScore(){
        p1Score = 0;
        p2Score = 0;
    }

    void newGame(){
        winUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPaused = false;
        scoreUI.SetActive(true);
    }


}
