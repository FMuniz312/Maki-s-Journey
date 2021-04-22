
 
using System.Collections.Generic;
using UnityEngine;

namespace MunizCodeKit.MonoBehaviours {

    /*
     * Easy set up for CameraFollow, it will follow the transform with zoom
     * */
    public class CameraFollowSetup : MonoBehaviour {

        [SerializeField] private CameraController cameraFollow;
        [SerializeField] private Vector3 followPosition;
        [SerializeField] private float zoom;

        private void Start() {
            if (followPosition == null) {
                Debug.Log("followTransform is null! Intended?");
                cameraFollow.Setup(() => Vector3.zero, () => zoom);
            } else {
                cameraFollow.Setup(() => followPosition, () => zoom);
            }
        }
    }

}