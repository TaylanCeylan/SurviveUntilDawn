using System;
using UnityEngine;

namespace _SurviveUntilDawn.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance {get; private set;}
        
        private InputSystem_Actions _inputActions;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.Log("Instance already exists!");
            }
        }

        private void Start()
        {
            _inputActions = new InputSystem_Actions();
            _inputActions.Enable();
        }

        public Vector2 GetMovementVector()
        {
            return _inputActions.Player.Move.ReadValue<Vector2>();
        }
    }
}
