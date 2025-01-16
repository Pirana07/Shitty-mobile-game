using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Transform runnersParent;
    [SerializeField] GameObject runnerPrefab;



    [Header("Settings")]
    [SerializeField] float radius;
    [SerializeField] float angle;

    
    void Update()
    {
        PlaceRunners();
    }
    void PlaceRunners(){
    for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPos = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPos;
        }
    }

    Vector3 GetRunnerLocalPosition(int index){
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x,0,z);
    }

    public float GetCrowdRadius(){
        return radius * Mathf.Sqrt(runnersParent.childCount);
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmout){
        switch(bonusType){
            case BonusType.Addition:
                AddRunners(bonusAmout);
               break;

               case BonusType.Product:
               int runnersToAdd = (runnersParent.childCount * bonusAmout) - runnersParent.childCount;
                AddRunners(runnersToAdd);
               break;

               case BonusType.Difference:
               Debug.Log("runnersToAdd");
                RemoveRunners(bonusAmout);
               break;
        
                case BonusType.Division:
               int runnersToRemove = runnersParent.childCount - (runnersParent.childCount / bonusAmout);
                RemoveRunners(runnersToRemove);
               break;
        }
    }

    void AddRunners(int amount){
        for (int i = 0; i < amount; i++)
        {
            Instantiate(runnerPrefab, runnersParent);
        }
    }
    
    void RemoveRunners(int amount){
        if(amount > runnersParent.childCount){
            amount = runnersParent.childCount;
        }

        int runnersAmount = runnersParent.childCount;
        for (int i = runnersAmount - 1; i >= runnersAmount - amount; i--)
        {
            Transform runnerToDestroy = runnersParent.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
        }
    }
}
