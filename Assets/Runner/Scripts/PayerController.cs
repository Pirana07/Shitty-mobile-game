using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Elements")]
    [SerializeField] CrowdSystem crowdSystem;

    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float slideSpeed;
    [SerializeField] float roadWidth;
    [SerializeField] PlayerAnimator playerAnimator;

    bool canMove;

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

 void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }
    
    void Start(){
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    void OnDestroy() {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
        
    }
    void Update()
    {
        if(canMove){
        MoveForward();
        ManageControl();
        }

    }
    
    void GameStateChangedCallback(GameManager.GameState gameState){
       if(gameState == GameManager.GameState.Game){
            StartMoving();
       } else if(gameState == GameManager.GameState.GameOver || gameState == GameManager.GameState.LevelComplete){
            StopMoving();
       }
    }
    void StartMoving(){
        canMove = true;
        playerAnimator.Run();
    }
    void StopMoving(){
        canMove = false;
        playerAnimator.Idile();

    }
    void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 newPosition = clickedPlayerPosition + Vector3.right * xScreenDifference;
            newPosition.x = Mathf.Clamp(
                newPosition.x,
                -roadWidth / 2 + crowdSystem.GetCrowdRadius(),
                roadWidth / 2 - crowdSystem.GetCrowdRadius()
            );

            transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
        }
    }
}


