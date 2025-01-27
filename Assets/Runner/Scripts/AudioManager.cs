using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
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
}
