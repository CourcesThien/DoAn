using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerManager
{
    public float defaultMoveSpeed = 2;
    public float currentMoveSpeed = 0.0f;
    public bool canMove = true;
    [SerializeField]
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

public class PlayerController : MonoSingleton<PlayerController>
{
    //Variables of types Rigidbody and Animator
    public Rigidbody2D rigi;
    [SerializeField]
    private Animator Anim;
    [SerializeField]
    private Seed seed;

    //Variable for Player movement speed
    public float playerSpeed = 0;
    public PlayerManager playerManager;
    [SerializeField]
    private Vector2 movementVector = Vector2.zero;
    [SerializeField]
    private Vector2 lastMovementVector = Vector2.zero;

    public Transform seedPosition;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        // set initial speed to default and current speed to default
        playerSpeed = playerManager.defaultMoveSpeed * Time.deltaTime;
        playerManager.currentMoveSpeed = playerManager.defaultMoveSpeed;

        StartCoroutine(RandomSeed());
    }

    public void SetSeed(Seed _seed)
    {
        this.seed = _seed;
    }


    private IEnumerator RandomSeed()
    {
        while (true)
        {
            seedPosition.localPosition = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            yield return new WaitForSeconds(Random.Range(3, 4));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Gets Player input. GetAxisRaw returns true or false, GetAxis allows floating point precision which we dont need for this level of movement
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementVector.Normalize(); // magnitude set at 1 always so diagonal movement isn't faster
        playerManager.canMove = (movementVector != Vector2.zero);


        if (playerManager.canMove)
        {
            lastMovementVector = movementVector;
            // set updated speed to currentSpeed
            playerSpeed = (playerManager.currentMoveSpeed - playerManager.SubSpeed) * Time.deltaTime;
            rigi.MovePosition(rigi.position + (movementVector * playerSpeed));

            if (Anim != null)
            {
                //Updates the direction so that we don't snap back to original position 
                Anim.SetFloat("Velocity_X", movementVector.x);
                Anim.SetFloat("Velocity_Y", movementVector.y);

                if (seed != null)
                {
                    seed.anim.SetFloat("Velocity_X", movementVector.x);
                    seed.anim.SetFloat("Velocity_Y", movementVector.y);
                    this.Anim.SetBool("isMove", true);  
                }

                this.Anim.SetBool("isPush", playerManager.HasCollisionBox);
                this.Anim.SetBool("isMove", true);  
            }   
        }
        else
        {
            if (Anim != null)
            {
                this.Anim.SetBool("isMove", false);
                this.Anim.SetBool("isPush", false);

                Anim.SetFloat("Last_Velo_X", lastMovementVector.x);
                Anim.SetFloat("Last_Velo_Y", lastMovementVector.y);

                if (seed != null)
                {
                    this.Anim.SetBool("isMove", false);  
                }
            }
        }


    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public Vector2 GetPositionSeed()
    {
        if (seedPosition != null)
        {
            return seedPosition.position;
        }
        return transform.position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag.Equals("BoxKey"))
        {
            if (playerManager.canMove)
                playerManager.HasCollisionBox = true;
            else
                playerManager.HasCollisionBox = false;

        }
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag.Equals("BoxKey"))
        {
            if (playerManager.canMove)
                playerManager.HasCollisionBox = true;
            else
                playerManager.HasCollisionBox = false;
            
        }

    }


    void OnCollisionExit2D(Collision2D coll)
    {
        Debug.Log("exit");
        if (coll.transform.tag.Equals("BoxKey"))
        {
            playerManager.HasCollisionBox = false;
        }
    }

    public void AddGravity()
    {
        if (rigi)
        {
            rigi.gravityScale = 1;
        }
    }

    public void DisableGravity()
    {
        if (rigi)
        {
            rigi.gravityScale = 0;
        }
    }
}
