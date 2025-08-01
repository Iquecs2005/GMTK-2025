using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectablesBehaviour : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private string onCollectionAudioName;

    [Header("Events")]
    [SerializeField] private UnityEvent<Collider2D> OnCollision;

    private void Start()
    {
        GameManager.Instance.GetLixoControllerRef().AddLixoScene(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LixoManager playerLixoManager = collision.transform.parent.GetComponent<LixoManager>();
            SoundEffectManager.Play(onCollectionAudioName);
            OnCollision.Invoke(collision);
            playerLixoManager.AddLixo(1);
            Destroy(gameObject);
        }
    }
}
