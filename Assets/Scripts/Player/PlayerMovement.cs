using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float horizontalMovement, verticalMovement;
    public float moveSpeed, rotationSpeed;
    Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //Get player input
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        //Set movement direction
        moveDirection = new Vector3(horizontalMovement, verticalMovement, 0f).normalized;

        //Move player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        //Check if player moved to rotate
        if (horizontalMovement != 0 && verticalMovement != 0)
        {
            RotatePlayer();
        }
        else
        {
            ResetPlayerRotation();
        }
    }

    void RotatePlayer()
    {
        //Calculate rotation angle according to movement vector
        float rotationAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        if (horizontalMovement > 0)
        {
            //Limit rotation angle
            rotationAngle = Mathf.Clamp(rotationAngle, -90f, 90f);
            
            //Create rotation only in Z axis
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            //Apply rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else if (horizontalMovement < 0)
        {
            //Limit rotation angle
            rotationAngle = Mathf.Clamp(rotationAngle, 90f, -90f);
            //Create rotation only in Z axis
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, -rotationAngle);

            //Apply rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void ResetPlayerRotation()
    {
        //Create rotation only in Z axis
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);

        //Apply rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
