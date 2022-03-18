using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int p1Score;
    private int p2Score;

    [SerializeField] Text score1;
    [SerializeField] Text score2;

    private void Awake() {
        p1Score = 0;
        p2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateScoreScreen();   
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

}
