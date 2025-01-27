using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource ButtonSound;

    [SerializeField] AudioSource doorHitSound;
    [SerializeField] AudioSource runnerDeathSound;

    [SerializeField] AudioSource levelCompleteSound;
    [SerializeField] AudioSource gameOverSound;



    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += PlayDoorHitSound;
        GameManager.onGameStateChanged += GameStateChangedCallback;
        Enemy.onRunnerDied += PlayRunnerDieSound;
    }
    private void OnDestroy() {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;

        Enemy.onRunnerDied -= PlayRunnerDieSound;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameStateChangedCallback(GameManager.GameState gameState){
        if(gameState == GameManager.GameState.LevelComplete){
            levelCompleteSound.Play();
        }else if(gameState == GameManager.GameState.GameOver){
            gameOverSound.Play();
        }
    }

    void PlayRunnerDieSound(){
        runnerDeathSound.Play();
    }
    void PlayDoorHitSound(){
        doorHitSound.Play();
    }

   public void DisableSound(){
        doorHitSound.volume = 0;
        runnerDeathSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        ButtonSound.volume = 0;
    }
    public void EnableSound(){
        doorHitSound.volume = 1;
        runnerDeathSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
        ButtonSound.volume = 1;

    }
}
