using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBridgePoint : MonoBehaviour
{
    public GameObject bridge;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            PlayerController player = col.GetComponent<PlayerController>();
            if (player != null)
            {
                
                player.DisableGravity();
                bridge.SetActive(false);
                SceneOne.Instance.SetActiveWallBlock(false);
                SceneOne.Instance.SetActiveBoxKey(false);

                SceneOne.Instance.SetActiveWallBlock(true);
            }
        }
    }
        
}
