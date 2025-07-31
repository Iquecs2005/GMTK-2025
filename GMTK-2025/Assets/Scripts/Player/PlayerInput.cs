using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> OnMove;

    public void OnMoveAction(InputAction.CallbackContext value) 
    {
        float inputAxis = value.ReadValue<float>();

        OnMove.Invoke(inputAxis);
    }
}
