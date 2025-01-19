using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Transform runnersParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Run(){
        for (int i = 0; i < runnersParent.childCount; i++){
            Transform runner = runnersParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();

            runnerAnimator.Play("Run");
        }
    }
    public void Idile(){
        for (int i = 0; i < runnersParent.childCount; i++){
            Transform runner = runnersParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();

            runnerAnimator.Play("Idile");
         }
    }
}
