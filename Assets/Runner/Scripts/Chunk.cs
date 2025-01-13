using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 size;

    
    public float GetLength(){
        return size.z;
    }
   public void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, size);
    } 
}
