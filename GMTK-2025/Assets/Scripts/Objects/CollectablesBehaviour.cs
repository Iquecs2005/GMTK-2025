using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LixoManager playerLixoManager = collision.transform.parent.GetComponent<LixoManager>();
            Destroy(gameObject);
            playerLixoManager.AddLixo(1);
        }
    }
}
