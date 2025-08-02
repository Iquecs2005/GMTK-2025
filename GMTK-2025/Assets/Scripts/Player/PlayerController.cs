using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    public GameObject beetle;
    public GameObject ball;
    public PlayerFollow playerFollow;
    public Rigidbody2D ballRb;
    public SpriteRenderer ballSr;
    public BallSizeController ballSizeController;
    public PlayerMovement playerMovement;

    [Header("Variables")]
    [SerializeField] private Sprite stickyBallSprite;

    [Header("Events")]
    public UnityEvent OnDeath;

    public bool dead { get; private set; } = false;
    public bool sticky { get; private set; } = false;
    private Sprite originalSprite;

    public void SetStickyBehaviour(bool stickyValue) 
    {
        if (stickyValue && !sticky) 
        {
            sticky = true;
            originalSprite = ballSr.sprite;
            ballSr.sprite = stickyBallSprite;
            ball.AddComponent<StickyBallScript>();
        }
        else if (!stickyValue && sticky) 
        {
            sticky = false;
            ballSr.sprite = originalSprite;
            print(ball.GetComponent<StickyBallScript>());
            Destroy(ball.GetComponent<StickyBallScript>());
        }
    }

    public void SetPlayerDeath() 
    {
        if (dead) return;

        dead = true;
        OnDeath.Invoke();
    }
}
