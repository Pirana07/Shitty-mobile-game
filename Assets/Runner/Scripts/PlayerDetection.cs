using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] CrowdSystem crowdSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectDoors();
    }
    void DetectDoors(){
        Collider[] detectedColiders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < detectedColiders.Length; i++)
        {
            if(detectedColiders[i].TryGetComponent(out Doors doors)){

                int bonusAmout = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType = doors.GetBonusType(transform.position.x);
                
                doors.Disable();
                
                crowdSystem.ApplyBonus(bonusType, bonusAmout);
            }
        }
    }
}
