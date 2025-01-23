using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Enemy enemyPrefab;
    [SerializeField]  Transform enemiesParent;


    [Header("Settings")]
    [SerializeField] int amount;
    [SerializeField] float radius;
    [SerializeField] float angle;

    void Start()
    {
        GenerateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateEnemies(){
        for (int i = 0; i < amount; i++)
        {
            Vector3 enemyLocalPosition = GetRunnerLocalPosition(i);

            Vector3 enemyWorldPosition = enemiesParent.TransformPoint(enemyLocalPosition);

            Instantiate(enemyPrefab, enemyWorldPosition, Quaternion.identity, enemiesParent);
        }
    }
    
    Vector3 GetRunnerLocalPosition(int index){
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x,0,z);
    }

}
