using UnityEngine;

public class AudioManager : MonoBehaviour
{
     [SerializeField] AudioSource gameAudio;
     [SerializeField] AudioClip winSound;
     [SerializeField] AudioClip countdownSound;
     [SerializeField] AudioClip startSound;
     [SerializeField] AudioClip pongSound;
     [SerializeField] AudioClip pingSound;
     [SerializeField] AudioClip goalSound;
     [SerializeField] AudioClip menuSound;



     public void PlayWinSound(){
        gameAudio.PlayOneShot(winSound,1f);
     
     }

      public void PlayCountdownSound(){
        if(!gameAudio.isPlaying){
            gameAudio.PlayOneShot(countdownSound,1f);
        }
     }

     public void PlayStartSound(){
        if(!gameAudio.isPlaying){
            gameAudio.PlayOneShot(startSound,1f);
        }
     }

     public void PlayPongBallSound(){
        gameAudio.PlayOneShot(pongSound,1f);
            
     }

    public void PlayPingBallSound(){
        gameAudio.PlayOneShot(pingSound,1f);
           
     }

     public void PlayGoalSound(){
        gameAudio.PlayOneShot(goalSound,1f);
     }

     public void PlayMenuSound(){
        gameAudio.PlayOneShot(menuSound, 1f);
     }

    public void StopSound(){
        if(gameAudio.isPlaying){
            gameAudio.Stop();
        }
     }

     public bool countdownSoundIsPlaying(){
        if(gameAudio.isPlaying){
            return true;
        }

        return false;
     }


}
