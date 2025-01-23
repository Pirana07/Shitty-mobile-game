using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State{ Idle, Running }

    [Header("Settings")]
    [SerializeField] float searchRadius;
    [SerializeField] float moveSpeed;
    State state;
    Transform targetRunner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageSate();
        
    }
    void ManageSate(){
        switch(state){
            case State.Idle:
                SearchForTarget();
             break;
             case State.Running:
                RunTorwardsTargt();
              break;
        }
    }
    void SearchForTarget(){
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);
        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if(detectedColliders[i].TryGetComponent(out targetRunner runner)){
                if(runner.IsTarget()){
                    continue;
                }
                runner.SetTarget();
                targetRunner = runner;

                StartRunningTorwardsTarget();
            }
        }
    }
    void StartRunningTorwardsTarget(){
        state = State.Running;
        GetComponent<Animator>().Play("Run");
    }
    void RunTorwardsTarget(){
        if(targetRunner == null){
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, Time.deltaTime * moveSpeed);
        if(Vector3.Distance(transform.position, targetRunner.position) > .1f){
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }
    }
}
