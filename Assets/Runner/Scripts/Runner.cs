using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [Header("Settings")]
    private bool _isTarget = false;

    public void SetTarget()
    {
        _isTarget = true;
    }

    public bool IsTarget()
    {
        return _isTarget;
    }
}
