using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerController pc;

    [Header("Variables")]
    [SerializeField] private float weightPerSize;

    private float originalScale;
    private float ballTrashWeight = 0;

    private void Start()
    {
        originalScale = transform.localScale.x;
    }

    public void AddTrash(float trashWeight) 
    {
        ballTrashWeight += trashWeight;
        ResizeBall();
    }

    public void RemoveTrash(float trashWeight) 
    {
        ballTrashWeight -= trashWeight;
        ResizeBall();
    }

    private void ResizeBall() 
    {
        float additionalScale = ballTrashWeight * weightPerSize;
        float newScale = originalScale + additionalScale;

        transform.localScale = new Vector3(newScale, newScale);
        pc.playerFollow.ChangeYOffset(newScale);
    } 
}
