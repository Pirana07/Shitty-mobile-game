using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CrowdCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] TextMeshPro crowdCounterText;
    [SerializeField] Transform runnersParent;

  

    // Update is called once per frame
    void Update()
    {
      crowdCounterText.text = runnersParent.childCount.ToString();  
      if(runnersParent.childCount <= 0){
        Destroy(gameObject);
      }
    }
}
