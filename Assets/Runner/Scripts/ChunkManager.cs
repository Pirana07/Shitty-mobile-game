using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField]  Chunk[] chunksPrefabs; 

    [Header("Settings")]
    [SerializeField]  int numberOfChunks = 5; 
    [SerializeField]  Vector3 chunkStartOffset = Vector3.zero; 

    void Start()
    { 
        Vector3 chunkPos = chunkStartOffset; 
        // Instantiate chunks
        for (int i = 0; i < numberOfChunks; i++)
        {
             Chunk chunkToCreate = chunksPrefabs[Random.Range(0, chunksPrefabs.Length)];
             if(i > 0){
                chunkPos.z += chunkToCreate.GetLength() / 2;
             }
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPos, Quaternion.identity, transform); 
            chunkPos.z += chunkInstance.GetLength() / 2;
        }
    }

    void Update()
    {
    }
}
