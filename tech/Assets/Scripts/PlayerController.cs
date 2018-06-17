using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerManager
{
    public float defaultMoveSpeed = 2;
    public float currentMoveSpeed = 0.0f;
    public bool canMove = true;
    private bool hasCollisionBox = false;

    public bool HasCollisionBox
    {
        get{ return hasCollisionBox; }
        set
        { 
            this.hasCollisionBox = value;
            SubSpeed = (hasCollisionBox) ? 0.25f : 0.0f;
        }
    }
    //
    public float SubSpeed = 0.0f;
}

public class PlayerController : MonoBehaviour
{

    //Variables of types Rigidbody and Animator
    private Rigidbody RBody;
    [SerializeField]
    private Animator Anim;

    //Variable for Player movement speed

    public float playerSpeed = 0;
    public PlayerManager playerManager;
    [SerializeField]
    private Vector3 movementVector = Vector3.zero;
    [SerializeField]
    private Vector3 lastMovementVector = Vector3.zero;

    void Start()
    {
        RBody = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();

        // set initial speed to default and current speed to default
        playerSpeed = playerManager.defaultMoveSpeed * Time.deltaTime;
        playerManager.currentMoveSpeed = playerManager.defaultMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets Player input. GetAxisRaw returns true or false, GetAxis allows floating point precision which we dont need for this level of movement
        movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movementVector.Normalize(); // magnitude set at 1 always so diagonal movement isn't faster
        playerManager.canMove = (movementVector != Vector3.zero);


        if (playerManager.canMove)
        {
            lastMovementVector = movementVector;
            // set updated speed to currentSpeed
            playerSpeed = (playerManager.currentMoveSpeed - playerManager.SubSpeed) * Time.deltaTime;

            //Updates the direction so that we don't snap back to original position 
            Anim.SetFloat("Velocity_X", movementVector.x);
            Anim.SetFloat("Velocity_Y", movementVector.z);

            RBody.MovePosition(RBody.position + (movementVector * playerSpeed));


            this.Anim.SetBool("isPush", playerManager.HasCollisionBox);
            this.Anim.SetBool("isMove", true);     
        }
        else
        {
            this.Anim.SetBool("isMove", false);
            this.Anim.SetBool("isPush", false);

            Anim.SetFloat("Last_Velo_X", lastMovementVector.x);
            Anim.SetFloat("Last_Velo_Y", lastMovementVector.z);
        }
         
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Box"))
        {
            if (playerManager.canMove)
                playerManager.HasCollisionBox = true;
            else
                playerManager.HasCollisionBox = false;

        }
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag.Equals("BoxKey"))
        {
            normalTime = collision.relativeVelocity;
            if (playerManager.canMove)
                playerManager.HasCollisionBox = true;
            else
                playerManager.HasCollisionBox = false;
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("BoxKey"))
        {
            playerManager.HasCollisionBox = false;
        }
    }

    private Vector3 normalTime = Vector3.zero;

    //    void OnGUI()
    //    {
    //        GUILayout.Label("collision - " + normalTime);
    //    }
}
