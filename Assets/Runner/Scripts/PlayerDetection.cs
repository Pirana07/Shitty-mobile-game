using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class PlayerDetection : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] CrowdSystem crowdSystem;

    [Header("Events")]
    public static Action onDoorsHit;
    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.instance.IsGameState()){
        DetectDoors();
        }
    }
    void DetectDoors(){
        Collider[] detectedColiders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < detectedColiders.Length; i++)
        {
            if(detectedColiders[i].TryGetComponent(out Doors doors)){

                int bonusAmout = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType = doors.GetBonusType(transform.position.x);
                
                doors.Disable();
                onDoorsHit?.Invoke();
                
                crowdSystem.ApplyBonus(bonusType, bonusAmout);
            }
            else if(detectedColiders[i].tag == "Finish"){
                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

                GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);

                // SceneManager.LoadScene(0);
             }
        }
    }
}
