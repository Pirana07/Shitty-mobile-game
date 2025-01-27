using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState{
        Menu, Game, LevelComplete, GameOver
    }
    GameState gamestate;

    public static Action<GameState> onGameStateChanged;

    void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }

    void Start()
    {
        // PlayerPrefs.DeleteAll();
        
    }

    public void SetGameState(GameState gamestate){
        this.gamestate = gamestate;
        onGameStateChanged?.Invoke(gamestate);
    }
    
    public bool IsGameState(){
       return gamestate == GameState.Game;
    }
}
