using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum BonusType{ Addition, Difference, Product, Division }
public class Doors : MonoBehaviour
{
    


    [Header("Elements")]
    [SerializeField] SpriteRenderer rightDoorRenderer;
    [SerializeField] SpriteRenderer leftDoorRenderer;
    [SerializeField] TextMeshPro rightDoorText;
    [SerializeField] TextMeshPro leftDoorText;
    [SerializeField] Collider collider;



    [Header("Settings")]
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] int rightDoorBonusAmout;
    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] int leftDoorBonusAmout;

    [SerializeField] Color bonusColor;
    [SerializeField] Color penaltyColor;

    void Start()
    {
        ConfigureDoors();
    }
    void Update()
    {
        
    }
    void  ConfigureDoors(){
        switch(rightDoorBonusType){
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmout;
               break;
            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmout;
               break; 
            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmout;
               break; 
            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "x" + rightDoorBonusAmout;
               break;
        }

     switch(leftDoorBonusType){
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmout;
               break;
            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmout;
               break; 
            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmout;
               break; 
            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmout;
               break;
        }
      }

      public int GetBonusAmount(float xPosition){
        if(xPosition > 0){
            return rightDoorBonusAmout;
        }else{
            return leftDoorBonusAmout;
        }
      }
       public BonusType GetBonusType(float xPosition){
        if(xPosition > 0){
            return rightDoorBonusType;
        }else{
            return leftDoorBonusType;
        }
      }

    public void Disable(){
        collider.enabled = false;
    }
}
