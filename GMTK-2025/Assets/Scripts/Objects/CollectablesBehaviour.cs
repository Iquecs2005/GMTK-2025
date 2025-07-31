using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesBehaviour : MonoBehaviour
{
    private LixoManager playerLixoManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerLixoManager = collision.transform.parent.GetComponent<LixoManager>();
            Destroy(this.gameObject);
            playerLixoManager.AddLixo(1);
        }
    }
}
