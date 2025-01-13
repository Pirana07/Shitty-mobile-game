using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;

    [Header("Control")]
    [SerializeField] float slideSpeed;
    Vector3 clickedScreenPosition;
    Vector3 clickedPlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        ManageControl();
    }

    void MoveForward(){
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;

    }
    void ManageControl(){
        if(Input.GetMouseButtonDown(0)){ 
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }else if(Input.GetMouseButton(0)){
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x; 

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

        Vector3 newPosition = clickedPlayerPosition + Vector3.right * xScreenDifference;
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);

        }
    }
}
