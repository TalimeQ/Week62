using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player Values")]
    [SerializeField][Tooltip("MovementSpeed")]
    float walkSpeed = 6f;
    [SerializeField]
    float sprintSpeed = 12f;
    [SerializeField]
    [Tooltip("Camera rotation Speed")]
    float cameraSpeed = 10f;
    [SerializeField]
    float cameraDistance = 1f;
    [SerializeField]
    float lerpParameter = 1f;
    [SerializeField]
    float sprintTime = 10f;
    [SerializeField]
    float exhaustionPenalty = 5f;

    float playerSpeed;

    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator animate;
    Camera mainCamera;

    float sprintEnergy;
    float energyRegen = 3f;
    //float cameraRayLenght = 200f;
    //int board;
    

    void Awake()
    {
        playerSpeed = walkSpeed;
        mainCamera = Camera.main;
        sprintEnergy = sprintTime;
        playerRigidbody = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();

        //board = LayerMask.GetMask("Board");

        mainCamera.transform.parent = this.gameObject.transform;

    }
	
	void FixedUpdate()
    {
        float horizontalThrow = Input.GetAxisRaw("Horizontal");
        float verticalThrow = Input.GetAxisRaw("Vertical");
        if (sprintEnergy > 0f && Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = sprintSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) || sprintEnergy <= 0f)
        {
            if (sprintEnergy <= 0f && playerSpeed == sprintSpeed)
                sprintEnergy -= exhaustionPenalty;
            playerSpeed = walkSpeed;
            
        }
        if(playerSpeed==sprintSpeed)
            sprintEnergy -= Time.deltaTime;
        if (sprintEnergy < sprintTime && playerSpeed == walkSpeed)
        {
            sprintEnergy += energyRegen * Time.deltaTime;
        }
        if (sprintEnergy > sprintTime)
        {
            sprintEnergy = sprintTime;
        }
        Move(verticalThrow);
        TurnCamera(horizontalThrow);
        Turn();
        
        Animate( verticalThrow);
    }
                                      
    void Move ( float verticalThrow)
    {

       
        Vector3 verticalMovement = Time.deltaTime * playerSpeed * transform.forward * verticalThrow;

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
        playerRigidbody.freezeRotation = true;

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

