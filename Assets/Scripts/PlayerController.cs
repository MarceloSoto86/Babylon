using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public Transform orientationPlayer;
    Vector3 moveDirection;
    public float movementSpeed = 30;
    float horizontalInput;
    float verticalInput;


   // [SerializeField] Animator playerAnimController;


    //IN CASE WE ADD JUMP ABILITY TO THE PLAYER (MAYBE AN UNLOCKABLE SKILL OR BUFF WHEN GAME ADVANCES TO SPEED UP COLLECTION OF ITEMS???)
    /*public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    public float groundDrag;
    public float playerHeight;
    bool readyToJump = true;
    bool grounded;
    public LayerMask whatIsGround;
    public KeyCode jumpKey = KeyCode.Space;*/



    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
   //     playerAnimController = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        PlayerInput();
        SpeedControl();
    }

    private void PlayerInput() //SCRIPT TO MAKE PLAYER MOVE
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //ADD SCRIPT TO JUMP IN CASE ABILITY IS ADDED LATER IN GAME DEV
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(horizontalInput,0.0f,verticalInput);
        if(movement !=Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),0.2f);
          //  playerAnimController.SetBool("Running", true);
        }
        else
        {
          //  playerAnimController.SetBool("Running", false);
        }
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);
        if (flatVelocity.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            playerRb.velocity = new Vector3(limitedVelocity.x,playerRb.velocity.y, limitedVelocity.z);
        }
    }

}
