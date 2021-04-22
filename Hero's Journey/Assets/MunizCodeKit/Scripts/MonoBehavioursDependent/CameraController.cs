 

//THIS IS A CODEMONKEY CAMERA SYSTEM WITH SOME CHANGES MADE BY MUNIZ USING DOTWEEN//

using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace MunizCodeKit.MonoBehaviours
{
    /*
     * Script to handle Camera Movement and Zoom
     * Place on Camera GameObject
     * */
    public class CameraController : MonoBehaviour
    {

        private Camera myCamera;
        private Func<Vector3> GetCameraFollowPositionFunc;
        private Func<float> GetCameraZoomFunc;
        static Tween cameraShakeTween;

        public void Setup(Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc)
        {
            this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
            this.GetCameraZoomFunc = GetCameraZoomFunc;
        }

        private void Start()
        {
            myCamera = transform.GetComponent<Camera>();
        }

        public void SetCameraFollowPosition(Vector3 cameraFollowPosition)
        {
            SetGetCameraFollowPositionFunc(() => cameraFollowPosition);
        }

        public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc)
        {
            this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        }

        public void SetCameraZoom(float cameraZoom)
        {
            SetGetCameraZoomFunc(() => cameraZoom);
        }

        public void SetGetCameraZoomFunc(Func<float> GetCameraZoomFunc)
        {
            this.GetCameraZoomFunc = GetCameraZoomFunc;
        }


        // Update is called once per frame
        void Update()
        {
            HandleMovement();
            HandleZoom();
        }

        private void HandleMovement()
        {
            Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
            cameraFollowPosition.z = transform.position.z;

            Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
            float distance = Vector3.Distance(cameraFollowPosition, transform.position);
            float cameraMoveSpeed = 3f;

            if (distance > 0)
            {
                Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

                float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

                if (distanceAfterMoving > distance)
                {
                    // Overshot the target
                    newCameraPosition = cameraFollowPosition;
                }

                transform.position = newCameraPosition;
            }
        }

        private void HandleZoom()
        {
            float cameraZoom = GetCameraZoomFunc();

            float cameraZoomDifference = cameraZoom - myCamera.orthographicSize;
            float cameraZoomSpeed = 1f;

            myCamera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;

            if (cameraZoomDifference > 0)
            {
                if (myCamera.orthographicSize > cameraZoom)
                {
                    myCamera.orthographicSize = cameraZoom;
                }
            }
            else
            {
                if (myCamera.orthographicSize < cameraZoom)
                {
                    myCamera.orthographicSize = cameraZoom;
                }
            }
        }


        // Screen Shake
        public static void ShakeCamera(float duration, float strength = 1, int vibrato = 10, float randomness = 90, bool snapping = false, bool fadeout = true)
        {
            cameraShakeTween?.Complete();
            cameraShakeTween = Camera.main.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeout);

        }


    }

}