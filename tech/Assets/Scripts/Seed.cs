using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public PlayerController player;

    public float speed = 1.0f;

    private float stepMove = 0.0f;

    public Animator anim;

    public void OnEnable()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<PlayerController>();
        }
    }

    void Update()
    {
        if (player != null)
        {
//            transform.LookAt(player.GetPositionSeed());
            stepMove = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.GetPositionSeed(), stepMove);// Vector3.Lerp(myTranform.position, posTarget, camSpeed);
            if (transform.position.Equals(player.GetPositionSeed()))
            {
                anim.SetBool("isMove", true);  
            }
            else
                anim.SetBool("isMove", false);
            Debug.Log(transform.forward);
        }
    }
}
