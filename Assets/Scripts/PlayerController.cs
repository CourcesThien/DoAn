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
    [SerializeField]
    private Animator Anim;

    //Variable for Player movement speed

    public float playerSpeed = 0;
    public PlayerManager playerManager;
    [SerializeField]
    private Vector2 movementVector = Vector2.zero;
    [SerializeField]
    private Vector2 lastMovementVector = Vector2.zero;

    void Start()
    {
        RBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        // set initial speed to default and current speed to default
        playerSpeed = playerManager.defaultMoveSpeed * Time.deltaTime;
        playerManager.currentMoveSpeed = playerManager.defaultMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets Player input. GetAxisRaw returns true or false, GetAxis allows floating point precision which we dont need for this level of movement
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementVector.Normalize(); // magnitude set at 1 always so diagonal movement isn't faster
        playerManager.canMove = (movementVector != Vector2.zero);

        this.Anim.SetBool("isMove", playerManager.canMove);
        if (playerManager.canMove)
        {
            lastMovementVector = movementVector;
            // set updated speed to currentSpeed
            playerSpeed = playerManager.currentMoveSpeed * Time.deltaTime;

            //Updates the direction so that we don't snap back to original position 
            Anim.SetFloat("Velocity_X", movementVector.x);
            Anim.SetFloat("Velocity_Y", movementVector.y);

//            //Checks to see if movement vector is equal to zero. If not zero, means we set the animator to walking else dont set to walking
//            if (movementVector != Vector2.zero)
//            {
//                Anim.SetBool("isWalking", true);
//            }
//            else
//            {
//                Anim.SetBool("isWalking", false);
//            }
                    
        }
        else
        {
            Anim.SetFloat("Last_Velo_X", lastMovementVector.x);
            Anim.SetFloat("Last_Velo_Y", lastMovementVector.y);
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
