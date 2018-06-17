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
        private float stepMove = 0;
        private Transform myTranform;
        // Use this for initialization
        void Start()
        {
            myTranform = transform;
        }

        // LateUpdate is called after updating each frame
        void Update()
        {
            if (Target)
            {
                stepMove = camSpeed * Time.deltaTime;
                posTarget = Target.position;
                posTarget.y = 0;
                myTranform.position = Vector3.MoveTowards(myTranform.position, posTarget, stepMove);// Vector3.Lerp(myTranform.position, posTarget, camSpeed);
            }
        }
    }
}