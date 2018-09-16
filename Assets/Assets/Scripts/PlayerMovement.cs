using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;

    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator animate;
    float cameraRayLenght = 200f;
    int board;
    

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
        board = LayerMask.GetMask("Board");
    }
	
	void FixedUpdate()
    {
        float horizontalThrow = Input.GetAxisRaw("Horizontal");
        float verticalThrow = Input.GetAxisRaw("Vertical");

        Move(horizontalThrow, verticalThrow);
        Turn();
        Animate(horizontalThrow, verticalThrow);
    }
                                      
    void Move (float horizontalThrow, float verticalThrow)
    {

        Vector3 horizontalMovement = Time.deltaTime * speed * transform.right * horizontalThrow;
        Vector3 verticalMovement = Time.deltaTime * speed * transform.forward * verticalThrow;

        movement = horizontalMovement + verticalMovement;


        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit boardHit;
        if (Physics.Raycast (cameraRay, out boardHit, cameraRayLenght, board))
        {
            Vector3 playerToMouse = boardHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }

    }

    void Animate(float horizontalThrow, float VerticalThrow)
    {
        bool isWalking = horizontalThrow != 0f || VerticalThrow != 0f;

        if (isWalking)
            animate.SetTrigger("Run");
        else
            animate.SetTrigger("Stop");

    }

}

