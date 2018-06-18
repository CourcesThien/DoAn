using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{

    //Variables of types Rigidbody and Animator
    public Rigidbody2D RBody;
    [SerializeField]
    private Animator Anim;

    //Variable for Player movement speed

    public float playerSpeed = 1;
    //    public PlayerManager playerManager;
    [SerializeField]
    private Vector2 movementVector = Vector3.zero;
    [SerializeField]
    private Vector3 lastMovementVector = Vector3.zero;
    // Use this for initialization
    void Start()
    {
		
    }

    void Update()
    {

        //Gets Player input. GetAxisRaw returns true or false, GetAxis allows floating point precision which we dont need for this level of movement
        movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementVector.Normalize(); // magnitude set at 1 always so diagonal movement isn't faster
//        playerManager.canMove = (movementVector != Vector3.zero);
        RBody.MovePosition(RBody.position + (movementVector * playerSpeed));
    }
}
