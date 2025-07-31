using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLean : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerController pc;
    //[SerializeField] private float rotationSpeed;

    [Header("Variables")]
    [SerializeField] private float speedToRotation;
    [SerializeField] private float rotationDrag;
    [SerializeField] private float maxResetForce;
    [SerializeField] private float minResetForce;
    [SerializeField] private float minAngleResetForce;
    [SerializeField] private float opposingForce;
    [SerializeField] private float angleInfluence;
    [SerializeField] private float deathAngleBound;

    private float angularVelocity;
    private float angularAcceleration;
    private float currentAngle;

    [Header("Debug")]
    [SerializeField] private bool opposingForceVisualization;
    [SerializeField] SpriteRenderer sr;

    Color defaultColor;

    private void Start()
    {
        defaultColor = sr.color;
    }

    private void FixedUpdate()
    {
        currentAngle = GetCurrentAngle();
        ApplyRotation();
        CheckAngleBound();
    }

    private float GetCurrentAngle() 
    {
        //Returns a angle from -180 to 180
        //Counterclockwise rotation is positive, Clockwise is negative

        float currentAngleDiff = transform.eulerAngles.z;
        if (currentAngleDiff > 180)
        {
            //Changes from 180 to 360, to -180 to 0
            currentAngleDiff -= 360;
        }

        return currentAngleDiff;
    }

    private void ApplyRotation() 
    {
        //TODO Refatorar em funções

        angularAcceleration = -speedToRotation * pc.ballRb.velocity.x;
        angularVelocity += angularAcceleration * Time.deltaTime;
        angularVelocity *= (1 - rotationDrag);
        if (Mathf.Abs(angularVelocity) < 0.01f) angularVelocity = 0;

        ApplyResetForce(angularVelocity);

        float currentAngleInfluence = 1 + angleInfluence * Mathf.Abs(currentAngle);

        transform.eulerAngles += new Vector3(0, 0, -angularVelocity * Time.deltaTime * currentAngleInfluence);
    }

    private void ApplyResetForce(float currentAngularVelocity) 
    {
        if (Mathf.Abs(currentAngle) < minAngleResetForce) return;

        float currentResetForce = maxResetForce;

        if (currentAngularVelocity * currentAngle > 0)
        {
            currentResetForce = opposingForce;

            if (opposingForceVisualization) sr.color = Color.green;
        }
        else
        {
            if (Mathf.Abs(currentAngularVelocity) >= 1)
            {
                currentResetForce *= (1 / Mathf.Abs(currentAngularVelocity));
            }

            if (opposingForceVisualization) sr.color = defaultColor;
        }

        if (currentResetForce < minResetForce)
        {
            currentResetForce = minResetForce;
        }

        if (currentAngle > 0)
        {
            transform.eulerAngles -= new Vector3(0, 0, currentResetForce * Time.deltaTime);
            if (GetCurrentAngle() < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }
        else if (currentAngle < 0)
        {
            transform.eulerAngles += new Vector3(0, 0, currentResetForce * Time.deltaTime);
            if (GetCurrentAngle() > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }
    }

    private void CheckAngleBound() 
    {
        if (Mathf.Abs(currentAngle) > deathAngleBound) 
        {
            Destroy(gameObject);
        }
    }
}
