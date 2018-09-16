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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turn();
        Animate(h, v);
    }
                                        
    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        Debug.Log(Input.mousePosition);
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

    void Animate(float h, float v)
    {
        bool isWalking = h != 0f || v != 0f;

        if (isWalking)
            animate.SetTrigger("Run");
        else
            animate.SetTrigger("Stop");

    }

}

