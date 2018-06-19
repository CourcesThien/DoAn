using UnityEngine;
using System.Collections;


namespace RPG
{
    public class CameraFollow : MonoSingleton<CameraFollow>
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
                posTarget.z = 0;
                myTranform.position = Vector2.MoveTowards(myTranform.position, posTarget, stepMove);// Vector3.Lerp(myTranform.position, posTarget, camSpeed);
            }
        }
    }
}