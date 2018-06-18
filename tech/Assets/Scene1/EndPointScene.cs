using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointScene : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            //SceneManager.LoadScene("Scene2");
            Initiate.Fade("Scene2", Color.black, 1.0f);
        }
    }
        
}
