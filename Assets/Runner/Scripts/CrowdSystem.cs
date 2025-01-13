using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Transform runnersParent;


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
}
