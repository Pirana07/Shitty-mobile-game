using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Chunk chunkprefab
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(chunkprefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
