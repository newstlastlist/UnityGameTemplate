using CameraLogic;
using Services.Input;
using UnityEngine;
using Zenject;
using Math = Helpers.Math;

namespace Game.Characters.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;

        #region Injections
        [Inject] private IInputService _inputService;
        [Inject] private CameraFollow _cameraFollow;
        #endregion

        private void Start()
        {
            _cameraFollow.Follow(gameObject);
        }

        private void Update() 
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Math.Constants.Epsilon)
            {
                movementVector = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y);
                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
       

    }
}