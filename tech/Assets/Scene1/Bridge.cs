using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Collider2D colliderWallBlock2;

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag.Equals("Player"))
        {
            PlayerController player = coll.transform.GetComponent<PlayerController>();
            if (player != null)
            {
                Debug.Log("ok 1");
                colliderWallBlock2.enabled = false;
            }
        }
    }
}
