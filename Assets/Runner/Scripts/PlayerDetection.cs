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
        DetectColliders();
        }
    }
    void DetectColliders(){
        Collider[] detectedColiders = Physics.OverlapSphere(transform.position, crowdSystem.GetCrowdRadius());

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
             }else if(detectedColiders[i].tag == "Coin"){
                Destroy(detectedColiders[i].gameObject);
                DataManager.instance.AddCoins(1);
             }
        }
    }
}
