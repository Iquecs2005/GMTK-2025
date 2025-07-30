using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bolaRb;
    [SerializeField] private Rigidbody2D caraRb;

    private void FixedUpdate()
    {
        int valor = 0;
        
        if (Input.GetKey(KeyCode.D)) 
        {
            valor += 1;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            valor -= 1;
        }

        bolaRb.AddForce(Vector2.right * valor * 5f);
        caraRb.AddForce(Vector2.right * -valor * 4.95f);
    }

}
