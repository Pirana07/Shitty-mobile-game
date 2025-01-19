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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(GameState gamestate){
        this.gamestate = gamestate;
        onGameStateChanged?.Invoke(gamestate);
    }
}
