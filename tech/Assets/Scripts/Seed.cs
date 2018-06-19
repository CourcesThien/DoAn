using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public PlayerController player;

    public float speed = 1.0f;

    private float stepMove = 0.0f;

    public Animator anim;

    public bool canMove = true;


    public void OnEnable()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<PlayerController>();
        }
        player.onMove += OnMove;
    }

    public void OnMove(Vector2 input)
    {
        if (anim != null)
        {   
            if (canMove)
            {
                if (input != Vector2.zero)
                {
                    this.anim.SetBool("isMove", true);
                    this.anim.SetFloat("Velocity_X", input.x);
                    this.anim.SetFloat("Velocity_Y", input.y);
                }
                else
                {
                    this.anim.SetBool("isMove", false);
                    this.anim.SetFloat("Velocity_X", player.lastMovementVector.x);
                    this.anim.SetFloat("Velocity_Y", player.lastMovementVector.y);
                }  
            }
        }

    }

    void Update()
    {
        if (player != null)
        {
//            transform.LookAt(player.GetPositionSeed());
            if (canMove)
            {
                stepMove = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.GetPositionSeed(), stepMove);// Vector3.Lerp(myTranform.position, posTarget, camSpeed);
                if (transform.position.Equals(player.GetPositionSeed()))
                {
                    anim.SetBool("isMove", true);  
                }
                else
                    anim.SetBool("isMove", false);
            }
            else
            {
                anim.SetBool("isMove", false);
            }
            Debug.Log(transform.forward);
        }
    }
}
