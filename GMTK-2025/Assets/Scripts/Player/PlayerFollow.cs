using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform target;

    private Vector2 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        transform.position = target.position + (Vector3)offset;
    }

    public void ChangeYOffset(float ballScale) 
    {
        offset.y = ballScale / 2;
    }
}
