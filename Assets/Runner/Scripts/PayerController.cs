using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slideSpeed;
    [SerializeField] private float roadWidth;

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    void Update()
    {
        MoveForward();
        ManageControl();
    }

    void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 newPosition = clickedPlayerPosition + Vector3.right * xScreenDifference;
            newPosition.x = Mathf.Clamp(
                newPosition.x,
                -roadWidth / 2 + crowdSystem.GetCrowdRadius(),
                roadWidth / 2 - crowdSystem.GetCrowdRadius()
            );

            transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
        }
    }
}
