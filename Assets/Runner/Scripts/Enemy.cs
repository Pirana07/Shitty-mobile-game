using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { Idle, Running }

    [Header("Settings")]
    [SerializeField]  float searchRadius = 5f;
    [SerializeField]  float moveSpeed = 2f;


     State _state = State.Idle;
     Transform _targetRunner;

    void Update()
    {
        ManageState();
    }

    void ManageState()
    {
        switch (_state)
        {
            case State.Idle:
                SearchForTarget();
                break;
            case State.Running:
                RunTowardsTarget();
                break;
        }
    }

    void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);
        foreach (var collider in detectedColliders)
        {
            if (collider.TryGetComponent(out Runner runner) && !runner.IsTarget())
            {
                runner.SetTarget();
                _targetRunner = runner.transform;
                StartRunningTowardsTarget();
                return;
            }
        }
    }

    void StartRunningTowardsTarget()
    {
        _state = State.Running;
        GetComponent<Animator>().Play("Run");
    }

    void RunTowardsTarget()
    {
        if (_targetRunner == null)
        {
            _state = State.Idle; 
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetRunner.position, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, _targetRunner.position) < 0.1f)
        {
            Destroy(_targetRunner.gameObject); 
            Destroy(gameObject); 
        }
    } 

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}
