using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerManager
{
    public float defaultMoveSpeed = 2;
    public float currentMoveSpeed = 0.0f;
    public bool canMove = true;
}

public class PlayerController : MonoBehaviour
{

    //Variables of types Rigidbody and Animator
    private Rigidbody2D RBody;
    private Animator Anim;

    //Variable for Player movement speed

    public float playerSpeed = 0;
    public PlayerManager playerManager;
    [SerializeField]
    private Vector2 movementVector;

    void Start()
    {
        RBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        // set initial speed to default and current speed to default
        playerSpeed = playerManager.defaultMoveSpeed * Time.deltaTime;
        playerManager.currentMoveSpeed = playerManager.defaultMoveSpeed + 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerManager.canMove)
        {
            //Gets Player input. GetAxisRaw returns true or false, GetAxis allows floating point precision which we dont need for this level of movement
            movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            movementVector.Normalize(); // magnitude set at 1 always so diagonal movement isn't faster
            // set updated speed to currentSpeed
            playerSpeed = playerManager.currentMoveSpeed * Time.deltaTime;

            if (Anim)
            {
                
                //Checks to see if movement vector is equal to zero. If not zero, means we set the animator to walking else dont set to walking
                if (movementVector != Vector2.zero)
                {
                    Anim.SetBool("isWalking", true);

                    //Updates the direction so that we don't snap back to original position 
                    Anim.SetFloat("input_x", movementVector.x);
                    Anim.SetFloat("input_y", movementVector.y);
                    Anim.SetFloat("lastMove_x", movementVector.x);
                    Anim.SetFloat("lastMove_y", movementVector.y);
                }
                else
                {
                    Anim.SetBool("isWalking", false);
                }

            }
        }

    }

    void FixedUpdate()
    {
        //Sets amount of movement. Position + the direction the Player is pressing via input * the deltaTime    Time.deltaTime;
        if (playerManager.canMove)
        {
            RBody.MovePosition(RBody.position + (movementVector * playerSpeed));
        }
    }
}
