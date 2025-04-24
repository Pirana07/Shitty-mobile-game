using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{

  [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float slideSpeed;
    [SerializeField] float roadWidth;
    [SerializeField] PlayerAnimator playerAnimator;

    bool canMove;

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    
    
    void Update()
    {
        if(canMove){
        MoveForward();
        }
        StartMoving();
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

    
}
