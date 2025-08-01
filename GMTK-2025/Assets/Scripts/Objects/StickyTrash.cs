using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTrash : MonoBehaviour
{
    public void AddStickyComponent(Collider2D collider) 
    {
        collider.GetComponentInParent<PlayerController>().SetStickyBehaviour(true);
    }
}
