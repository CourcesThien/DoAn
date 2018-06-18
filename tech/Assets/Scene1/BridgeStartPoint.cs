using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeStartPoint : MonoBehaviour
{
    private Collider2D collider;
    public BoxCollider2D boxColliderBridge;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            PlayerController player = col.GetComponent<PlayerController>();
            if (player != null)
            {
                collider.enabled = false;
                player.AddGravity();
                boxColliderBridge.enabled = true;
                SceneOne.Instance.SetActiveWallBlock(false);
                SceneOne.Instance.SetActiveBoxKey(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            PlayerController player = col.GetComponent<PlayerController>();
            if (player != null)
            {
//                collider.enabled = false;
//                player.DisableGravity();
//                boxColliderBridge.enabled = true;
//                SceneOne.Instance.SetActiveWallBlock(true);
            }
        }
    }
}
