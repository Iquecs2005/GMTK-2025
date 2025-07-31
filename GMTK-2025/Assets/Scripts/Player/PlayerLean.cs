using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLean : MonoBehaviour
{
    [SerializeField] private PlayerController pc;
    //[SerializeField] private float rotationSpeed;
    [SerializeField] private float speedToRotation;
    [SerializeField] private float rotationDrag;
    [SerializeField] private float maxResetForce;
    [SerializeField] private float minResetForce;
    [SerializeField] private float opposingForce;
    [SerializeField] private float angleInfluence;

    private float angularVelocity;
    private float angularAcceleration;

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
        NormalBalance();
    }

    private void NormalBalance() 
    {
        angularAcceleration = -speedToRotation * pc.ballRb.velocity.x;
        angularVelocity += angularAcceleration * Time.deltaTime;
        angularVelocity *= (1 - rotationDrag);
        if (Mathf.Abs(angularVelocity) < 0.01f) angularVelocity = 0;

        float currentAngleDiff = transform.eulerAngles.z;
        if (currentAngleDiff > 180) 
        {
            //Changes from 180 to 360, to -180 to 0
            currentAngleDiff -= 360;
        }
        //Current Angle is a value between -180 and 180

        float currentResetForce = maxResetForce;
        if (angularVelocity * currentAngleDiff > 0) 
        {
            currentResetForce = opposingForce;
            if (opposingForceVisualization) sr.color = Color.green;
        }
        else 
        {
            if (opposingForceVisualization) sr.color = defaultColor;
            if (Mathf.Abs(angularVelocity) >= 1)
            {
                currentResetForce *= (1 / Mathf.Abs(angularVelocity));
            }
        }

        if (currentResetForce < minResetForce) 
        {
            currentResetForce = minResetForce;
        }

        if (transform.eulerAngles.z <= 180) 
        {
            transform.eulerAngles -= new Vector3(0, 0, currentResetForce * Time.deltaTime);
            if (transform.eulerAngles.z > 180) 
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }
        else 
        {
            transform.eulerAngles += new Vector3(0, 0, currentResetForce * Time.deltaTime);
            if (transform.eulerAngles.z < 180)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }

        float currentAngleInfluence = 1 + angleInfluence * Mathf.Abs(currentAngleDiff);

        transform.eulerAngles += new Vector3(0, 0, -angularVelocity * Time.deltaTime * currentAngleInfluence);
    }
}
