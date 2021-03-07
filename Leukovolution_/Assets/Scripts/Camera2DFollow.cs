using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        private Transform followTarget;

        [SerializeField] float smoothSpeed = 0.125f;

        [SerializeField] Vector3 cameraOffset;

        void Start()
        {
            followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = followTarget.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);

            //transform.position = smoothedPosition;

            //Vector3 temp = transform.position; //store camera pos

            //temp.x = followTarget.position.x;
            //temp.y = followTarget.position.y;

            //transform.position = temp;
        }
    }
}
