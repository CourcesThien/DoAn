using UnityEngine;
using System.Collections;


namespace RPG
{
    public class CameraFollow : MonoBehaviour
    {

        //References the Player object
        public Transform Target;
        private Vector3 posTarget = Vector3.zero;
        public float camSpeed = 0.1f;
        Camera mainCam;

        GameObject Player;

        private Transform myTranform;
        // Use this for initialization
        void Start()
        {
            mainCam = GetComponent<Camera>();
            myTranform = transform;
        }

        // LateUpdate is called after updating each frame
        void Update()
        {
            if (Target)
            {
                posTarget = Target.position;
                posTarget.z = -10;
                myTranform.position = Vector3.Lerp(myTranform.position, posTarget, camSpeed);
            }
        }
    }
}