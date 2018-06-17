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

    private float disToKey = 0;
    private float hard = 0.4f;
    [SerializeField]
    private bool isDone = false;
    // Use this for initialization
    void Start()
    {
        sprRender = GetComponent<SpriteRenderer>();
        sprDefault = sprRender.sprite;
        positionBoxKey = transform.position;
        positionBoxKey.z += 0.4f;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (currTransKey == null)
            return;
        if (hasKey)
        {
            if (!isDone)
            {
                disToKey = (transform.position - currTransKey.position).magnitude;
                if (disToKey <= hard)
                {
                    currTransKey.position = positionBoxKey;
                    Debug.Log("done");
                    isDone = true;
                }
            }
            else
            {
                disToKey = (transform.position - currTransKey.position).magnitude;
                if (disToKey > hard + 0.1f)
                {
                    isDone = false;
                }
            }
        }

    }

    //    void OnGUI()
    //    {
    //        GUILayout.Label("abc = " + disToKey);
    //    }

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
