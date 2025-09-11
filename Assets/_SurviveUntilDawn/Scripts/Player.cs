using System;
using UnityEngine;

namespace _SurviveUntilDawn.Scripts
{
    public class Player : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private InputManager _inputManager;
        private CharacterController _characterController;
        private Animator _animator;
        private Vector3 _lastMovementDirection;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponentInChildren<Animator>();
        }
        
        private void Start()
        {
            _inputManager = InputManager.Instance;
        }

        private void Update()
        {
            Vector3 movementDirection = new Vector3(_inputManager.GetMovementVector().x, 0f, _inputManager.GetMovementVector().y);

            if (movementDirection != Vector3.zero)
            {
                _lastMovementDirection  = movementDirection;
            }
            
            _characterController.Move(movementDirection * (5f * Time.deltaTime));

            transform.forward = new Vector3(_lastMovementDirection.x, 0f, _lastMovementDirection.z);

            if (movementDirection != Vector3.zero)
            {
                _animator.SetBool(IsRunning, true);
            }
            else if (movementDirection == Vector3.zero)
            {
                _animator.SetBool(IsRunning, false);
            }
        }
    }
}
