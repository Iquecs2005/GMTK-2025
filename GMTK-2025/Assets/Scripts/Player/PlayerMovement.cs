using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerController pc;

    [Header("Variables")]
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveDesacceleration;

    [Header("Debug")]
    [SerializeField] private bool accelerationColor;
    [SerializeField] SpriteRenderer sr;

    private Vector2 moveInput;
    private float currentAcceleration;
    private float currentDesacceleration;
    private bool canMove = true;
    private bool stickyMovement = false;
    private float normalDir = 1;

    private void Start()
    {
        currentAcceleration = moveAcceleration;
        currentDesacceleration = moveDesacceleration;
    }

    private void FixedUpdate()
    {
        ApplyHorizontalMovement(); 
        ApplyVerticalMovement();
    }

    public void ChangeMovementDirection(Vector2 value) 
    {
        moveInput = value;
    }

    private void ApplyHorizontalMovement()
    {
        if (!canMove || stickyMovement) return;

        float targetSpeed = moveInput.x * maxMoveSpeed;

        float speedDif = targetSpeed - pc.ballRb.velocity.x;

        float accelRate;
        if (targetSpeed * pc.ballRb.velocity.x >= 0) 
        {
            if (Mathf.Abs(targetSpeed) >= Mathf.Abs(pc.ballRb.velocity.x)) 
            {
                accelRate = currentAcceleration;
                if (accelerationColor)  sr.color = Color.yellow;
            }
            else 
            {
                accelRate = currentDesacceleration;
                if (accelerationColor) sr.color = Color.blue;
            }
        }
        else 
        {
            accelRate = currentDesacceleration;
            if (accelerationColor) sr.color = Color.blue;
        }

        pc.ballRb.AddForce(Vector2.right * speedDif * accelRate);
    }

    private void ApplyVerticalMovement()
    {
        if (!canMove || !stickyMovement) return;

        float targetSpeed = normalDir * moveInput.x * maxMoveSpeed;

        float speedDif = targetSpeed - pc.ballRb.velocity.y;

        float accelRate;
        if (targetSpeed * pc.ballRb.velocity.y >= 0)
        {
            if (Mathf.Abs(targetSpeed) >= Mathf.Abs(pc.ballRb.velocity.y))
            {
                accelRate = currentAcceleration;
                if (accelerationColor) sr.color = Color.yellow;
            }
            else
            {
                accelRate = currentDesacceleration;
                if (accelerationColor) sr.color = Color.blue;
            }
        }
        else
        {
            accelRate = currentDesacceleration;
            if (accelerationColor) sr.color = Color.blue;
        }

        pc.ballRb.AddForce(Vector2.up * speedDif * accelRate);
    }

    public void SetMovement(bool value) 
    {
        canMove = value;
    }

    public void SetStickyMovement(bool stickyValue, int normalValue) 
    {
        stickyMovement = stickyValue;
        normalDir = normalValue;
    }
}
