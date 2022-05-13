using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Parry parryController;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool isJumping;
    bool canParry;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("AltJump")) {
            isJumping = true;
        }
        if (Input.GetButtonDown("Jump") && parryController.isParrying) 
        {
            parryController.Parry_Time();
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, isJumping);
        isJumping = false;
    }
}
