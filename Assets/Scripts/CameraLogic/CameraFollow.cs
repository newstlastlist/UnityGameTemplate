using UnityEngine;

namespace CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private float _rotationAngleY;
        [SerializeField] private float _rotationAngleZ;
        [SerializeField] private float _offsetX;
        [SerializeField] private float _offsetY;
        [SerializeField] private float _offsetZ;

        private Transform _following;

        private void LateUpdate()
        {
            if (_following == null)
            {
                return;
            }

            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            // Vector3 position = rotation * new Vector3(0, 0, -_offsetZ) + FollowingPointPosition();
            Vector3 position = rotation * new Vector3(0, 0, 0) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject following)
        {
            _following = following.transform;

            SetupCamera();
        }

        private void SetupCamera()
        {
            Vector3 followingPosition = _following.position;
            
            _offsetX = transform.position.x - followingPosition.x;
            _offsetY = transform.position.y - followingPosition.y;
            _offsetZ = transform.position.z - followingPosition.z;

            _rotationAngleX = transform.eulerAngles.x;
            _rotationAngleY = transform.eulerAngles.y;
            _rotationAngleZ = transform.eulerAngles.z;
        }
        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.x += _offsetX;
            followingPosition.y += _offsetY;
            followingPosition.z += _offsetZ;

            return followingPosition;
        }
    }
}