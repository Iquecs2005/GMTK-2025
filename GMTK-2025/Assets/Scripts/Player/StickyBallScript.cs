using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBallScript : MonoBehaviour
{
    [SerializeField] private PlayerController pc;
    private SpriteRenderer spriteRenderer;

    private Collider2D ballCollider;
    private Color originalColor;

    private void Awake()
    {
        ballCollider = GetComponent<Collider2D>();
        pc = GetComponentInParent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.green;
    }

    private void FixedUpdate()
    {
        CheckForWall();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    CheckForWall(collision);
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    CheckForWall(collision);
    //}

    private void CheckForWall() 
    {
        List<ContactPoint2D> contactList = new List<ContactPoint2D>();
        int contactPoints = ballCollider.GetContacts(contactList);
        if (contactPoints == 0)
        {
            DisableStickyMovement();
            return;
        }

        int newestContactPoint = contactPoints - 1;
        ContactPoint2D currentContactPoint = contactList[newestContactPoint];
        Vector2 contactNormal = currentContactPoint.normal;
        print(contactNormal);

        if (Mathf.Abs(contactNormal.x) >= 0.5)
        {
            EnableStickyMovement(contactNormal);
        }
        else 
        {
            DisableStickyMovement();
        }
    }

    private void EnableStickyMovement(Vector2 normal) 
    {
        pc.ballRb.gravityScale = 0;

        int normalDir = 1;
        if (normal.x > 0)
        {
            normalDir = -1;
        }
        pc.playerMovement.SetStickyMovement(true, normalDir);
    }

    private void DisableStickyMovement() 
    {
        pc.ballRb.gravityScale = 1;
        pc.playerMovement.SetStickyMovement(false, 1);
    }

    private void OnDestroy()
    {
        spriteRenderer.color = originalColor;
        DisableStickyMovement();
    }
}
