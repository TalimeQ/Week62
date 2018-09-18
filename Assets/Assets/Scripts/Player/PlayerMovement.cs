using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player Values")]
    [SerializeField][Tooltip("MovementSpeed")]
    float speed = 6f;
    [SerializeField]
    [Tooltip("Camera rotation Speed")]
    float cameraSpeed = 10f;
    [SerializeField]
    float cameraDistance = 1f;
    [SerializeField]
    float lerpParameter = 1f;

    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator animate;
    Camera mainCamera;
    float cameraRayLenght = 200f;
    int board;
    

    void Awake()
    {
        mainCamera = Camera.main;
        playerRigidbody = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
        board = LayerMask.GetMask("Board");
    }
	
	void FixedUpdate()
    {
        float horizontalThrow = Input.GetAxisRaw("Horizontal");
        float verticalThrow = Input.GetAxisRaw("Vertical");

        Move(verticalThrow);
        TurnCamera(horizontalThrow);
        Turn();
        Animate( verticalThrow);
    }
                                      
    void Move ( float verticalThrow)
    {

       
        Vector3 verticalMovement = Time.deltaTime * speed * transform.forward * verticalThrow;

        movement = verticalMovement;


        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        /* Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit boardHit;
         if (Physics.Raycast (cameraRay, out boardHit, cameraRayLenght, board))
         {
             Vector3 playerToMouse = boardHit.point - transform.position;
             playerToMouse.y = 0f;
             Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
             playerRigidbody.MoveRotation(newRotation);
         }   
         */
        Vector3 cameraToPlayer;
        cameraToPlayer = transform.position - mainCamera.transform.position;
        cameraToPlayer.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(cameraToPlayer);
        playerRigidbody.MoveRotation(newRotation);
            

    }
    void TurnCamera(float horizontalThrow)
    {

        float newX = Mathf.Sin(horizontalThrow * cameraSpeed * Time.deltaTime) * cameraDistance;
        float newZ = Mathf.Cos(horizontalThrow * cameraSpeed * Time.deltaTime) * cameraDistance;
        Vector3 newPosition;
        newPosition.x = newX;
        newPosition.y = mainCamera.transform.localPosition.y;
        newPosition.z = newZ;
        mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, newPosition, lerpParameter);
        //float newCameraAngle = mainCamera.transform.localRotation.eulerAngles.y + horizontalThrow * Time.deltaTime * cameraSpeed;
        //float mainCameraEulerX = mainCamera.transform.localRotation.eulerAngles.x;
        //float mainCameraEulerZ = mainCamera.transform.localRotation.eulerAngles.z;

        //mainCamera.transform.localRotation = Quaternion.Euler(mainCameraEulerX,newCameraAngle,mainCameraEulerZ);



    }
    void Animate( float VerticalThrow)
    {
        bool isWalking = VerticalThrow != 0f;

        if (isWalking)
            animate.SetTrigger("Run");
        else
            animate.SetTrigger("Stop");

    }

}

