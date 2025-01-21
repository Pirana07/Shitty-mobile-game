using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] TextMeshProUGUI  levelText;


    [SerializeField] Slider progressBar;

    void Start()
    {
        progressBar.value = 0;
        gamePanel.SetActive(false);

        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);
    }

    void Update()
    {
        UpdateProgressBar();
    }
    public void PlayButtonPressed(){
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void UpdateProgressBar(){
        if(!GameManager.instance.IsGameState())
            return;
        

        float progress =  PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;

    }
}

