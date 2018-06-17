using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKey : MonoBehaviour
{
    //    public GameObject objDone;
    private bool hasKey = false;
    [SerializeField]
    private Vector3 positionBoxKey = new Vector3(0, 0.3f, 0);
    [SerializeField]
    private Transform currTransKey = null;

    public Sprite sprKeyDown;
    private Sprite sprDefault;

    private SpriteRenderer sprRender;
    // Use this for initialization
    void Start()
    {
        sprRender = GetComponent<SpriteRenderer>();
        sprDefault = sprRender.sprite;
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
            sprRender.sprite = sprKeyDown;
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
            sprRender.sprite = sprDefault;
        }
    }

}
