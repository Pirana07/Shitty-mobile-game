using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] GameObject settingsPanel;



    [SerializeField] TextMeshProUGUI  levelText;


    [SerializeField] Slider progressBar;

    void Start()
    {
        progressBar.value = 0;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        settingsPanel.SetActive(false);

        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);

        GameManager.onGameStateChanged +=  GameStateChangedcallback;
    }

     void OnDestroy() {
        GameManager.onGameStateChanged -=  GameStateChangedcallback;
    
    }

    void Update()
    {
        UpdateProgressBar();
    }

    void GameStateChangedcallback(GameManager.GameState gameState){

        if(gameState == GameManager.GameState.GameOver){
            ShowGameover();
        }else if(gameState == GameManager.GameState.LevelComplete){
            ShowLevelComplete();
        }
    }
    public void PlayButtonPressed(){
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void RetryButtonPressed(){
         SceneManager.LoadScene(0);
    }

    public void ShowGameover(){
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(true);

    }

    void ShowLevelComplete(){
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }

    public void UpdateProgressBar(){
        if(!GameManager.instance.IsGameState())
            return;
        

        float progress =  PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }

    public void ShowSettingsPanel(){
        settingsPanel.SetActive(true);
    }
    public void HideSettingsPanel(){
        settingsPanel.SetActive(false);

    }

}

