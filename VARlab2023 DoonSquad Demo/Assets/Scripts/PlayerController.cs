using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkingSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    //animator
    public Animator anim;

    //boosted jump height
    public bool boostedHeight = false;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    public bool doubleJumpUsed = false;
    private const float JUMP_COOLDOWN = 0.25f;
    public float remainingJumpCooldown = 0;

    public bool dashUsed = false;
    private const float DASH_COOLDOWN = 1f;
    public float remainingDashCooldown = 0;
    public const float DASH_SPEED = 30.0f;
    public const float DASH_DURATION = 0.6f;
    public float remainingDashDuration = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //get animator from player
        anim = GetComponent<Animator>();

        // Hides cursor while playing. Uncomment to see cursor.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if player velocity is greater than 0, play walk animation
        if(characterController.velocity.magnitude > 0){
            anim.SetBool("Run", true);
        }else{
            anim.SetBool("Run", false);
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = 0;
        float curSpeedY = 0;

        // Dash and jump countdowns and resets
        remainingJumpCooldown = Math.Max(remainingJumpCooldown - Time.deltaTime, 0);
        remainingDashCooldown = Math.Max(remainingDashCooldown - Time.deltaTime, 0);
        remainingDashDuration = Math.Max(remainingDashDuration - Time.deltaTime, 0);

        if (characterController.isGrounded)
        {
            doubleJumpUsed = false;
            dashUsed = false;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canMove && !dashUsed && remainingDashCooldown == 0)
        {
            remainingDashDuration = DASH_DURATION;
            remainingDashCooldown = DASH_COOLDOWN;
            dashUsed = true;
        }

        if (remainingDashDuration > DASH_DURATION / 2)
        {
            curSpeedX = canMove ? DASH_SPEED * Input.GetAxis("Vertical") : 0;
            curSpeedY = canMove ? DASH_SPEED * Input.GetAxis("Horizontal") : 0;
        }
        else if(remainingDashDuration > 0 && DASH_SPEED * (remainingDashDuration / DASH_DURATION) > walkingSpeed)
        {
            curSpeedX = canMove ? DASH_SPEED * (remainingDashDuration / DASH_DURATION) * Input.GetAxis("Vertical") : 0;
            curSpeedY = canMove ? DASH_SPEED * (remainingDashDuration / DASH_DURATION) * Input.GetAxis("Horizontal") : 0;
        }
        else
        {
            curSpeedX = canMove ? walkingSpeed * Input.GetAxis("Vertical") : 0;
            curSpeedY = canMove ? walkingSpeed * Input.GetAxis("Horizontal") : 0;
        }

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && canMove && characterController.isGrounded)
        {
            float modifiedJumpSpeed = jumpSpeed;
            if(boostedHeight){
                modifiedJumpSpeed = jumpSpeed * 2f;
                moveDirection.y = modifiedJumpSpeed;
                boostedHeight = false;
            }else{
                moveDirection.y = jumpSpeed;
            }
            anim.SetTrigger("Jump");
            remainingJumpCooldown = JUMP_COOLDOWN;
            remainingDashDuration = 0;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Double jump
        if (Input.GetKeyDown(KeyCode.Space) && canMove && !doubleJumpUsed && remainingJumpCooldown == 0)
        {
            float modifiedJumpSpeed = jumpSpeed;
            if(boostedHeight){
                modifiedJumpSpeed = jumpSpeed * 2f;
                moveDirection.y = modifiedJumpSpeed;
                boostedHeight = false;
                doubleJumpUsed = false;

            }else{
                moveDirection.y = jumpSpeed;
                doubleJumpUsed = true;

            }
            anim.SetTrigger("Jump");
            remainingJumpCooldown = JUMP_COOLDOWN;
            remainingDashDuration = 0;
        }

        // Gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // No elevation change while dashing
        if (remainingDashDuration > DASH_DURATION / 3)
        {
            moveDirection.y = 0;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotation
        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
