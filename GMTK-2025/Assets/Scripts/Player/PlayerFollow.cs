using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 offset;
    private bool shouldFollow = true;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (shouldFollow) rb.MovePosition(target.position + (Vector3)offset);
    }

    public void ChangeYOffset(float ballScale) 
    {
        offset.y = ballScale / 2;
    }

    public void SetFollow(bool value) 
    {
        shouldFollow = value;
    }
}
