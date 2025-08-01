using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<Vector2> OnMove;

    public void OnMoveAction(InputAction.CallbackContext value) 
    {
        Vector2 inputAxis = value.ReadValue<Vector2>();

        OnMove.Invoke(inputAxis);
    }
}
