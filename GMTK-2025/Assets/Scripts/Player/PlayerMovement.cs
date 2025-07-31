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

    private float moveInput;
    private float currentAcceleration;
    private float currentDesacceleration;

    private void Start()
    {
        currentAcceleration = moveAcceleration;
        currentDesacceleration = moveDesacceleration;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    public void ChangeMovementDirection(float value) 
    {
        moveInput = value;
    }

    private void ApplyMovement()
    {
        //if (!shouldMove) return;

        //Vector2 targetSpeed = moveInput * maxMoveSpeed;

        //Vector2 speedDif = targetSpeed - pc.rb.velocity;

        //float accelRate;
        //if (targetSpeed.magnitude > 0.01f)
        //{
        //    accelRate = currentAcceleration;
        //}
        //else
        //{
        //    accelRate = currentDesacceleration;
        //}

        //pc.rb.AddForce(speedDif * accelRate);

        float targetSpeed = moveInput * maxMoveSpeed;

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
}
