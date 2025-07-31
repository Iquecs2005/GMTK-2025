using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    public PlayerFollow playerFollow;
    public Rigidbody2D ballRb;

    [Header("Events")]
    public UnityEvent OnDeath;
}
