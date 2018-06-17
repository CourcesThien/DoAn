using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKey : MonoBehaviour
{
    public GameObject objDone;
    private bool hasKey = false;

    private Transform currTransKey = null;
    // Use this for initialization
    void Start()
    {
        objDone.SetActive(false);
    }
	
    // Update is called once per frame
    void Update()
    {
        if (hasKey && currTransKey != null)
        {
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("BoxKey"))
        {
            hasKey = true;
            currTransKey = other.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("BoxKey"))
        {
            hasKey = true;
            currTransKey = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("BoxKey"))
        {
            hasKey = false;
        }
    }

}
