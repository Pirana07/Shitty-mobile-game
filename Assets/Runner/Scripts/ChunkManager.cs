using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;
    
    [Header("Elements")]
    [SerializeField]  Chunk[] chunksPrefabs; 
    [SerializeField]  Chunk[] levelChunks; 
    GameObject finishLine;

    [Header("Settings")]
    [SerializeField]  int numberOfChunks = 5; 
    [SerializeField]  Vector3 chunkStartOffset = Vector3.zero; 
    
     void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }

    void Start()
    { 
        CreateOrderedLevel();
        finishLine = GameObject.FindWithTag("Finish");
    }

    void CreateOrderedLevel(){
        Vector3 chunkPos = chunkStartOffset; 
        for (int i = 0; i < levelChunks.Length; i++){
            Chunk chunkToCreate = levelChunks[i];
             if(i > 0){
                chunkPos.z += chunkToCreate.GetLength() / 2;
             }
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPos, Quaternion.identity, transform); 
            chunkPos.z += chunkInstance.GetLength() / 2;
        }

    }
    void CreateRandomLevel(){
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
    public float GetFinishZ(){
        return finishLine.transform.position.z;
    }
}
