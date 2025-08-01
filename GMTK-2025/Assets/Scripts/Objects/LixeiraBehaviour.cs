using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixeiraBehaviour : MonoBehaviour
{
    [Header("Private Properts")]
    private LixoManager playerLixoManager;
    SpriteRenderer spriteRenderer;

    [Header("Lixeira Properts")]
    public int maxLixo;
    public int currentLixo;
    public int lixeiraEspaco;

    [Header("Sprite Changer")]
    public Sprite lixeiraVazia;
    public Sprite lixeiraCheia;

    void Start()
    {
        lixeiraEspaco = maxLixo - currentLixo;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerLixoManager = collision.transform.parent.GetComponent<LixoManager>();

            // Debug.Log("Aviso antes do null retur");

            if (playerLixoManager == null)
            {
                Debug.LogWarning("Player não possui LixoManager!");
                return;
            }

            int playerLixo = playerLixoManager.currentLixo;

            if (playerLixo > 0 && lixeiraEspaco > 0)
            {
                int lixoTransferido = Mathf.Min(playerLixo, lixeiraEspaco);

                playerLixoManager.JogarLixoFora(lixoTransferido);
                GameManager.Instance.GetLixoControllerRef().AddLixoCollected(lixoTransferido);
                currentLixo += lixoTransferido;
                lixeiraEspaco -= lixoTransferido;
                ChangeSprite();

                Debug.Log($"Jogou fora: {lixoTransferido} | Player lixo: {playerLixoManager.currentLixo} | Lixeira lixo: {currentLixo}");
            }
            else
            {
                Debug.Log("Nada para jogar fora ou lixeira cheia!");
            }
        }
    }

    private void ChangeSprite()
    {
        if (lixeiraEspaco == 0)
        {
            spriteRenderer.sprite = lixeiraCheia;
        }
        else
        {
            spriteRenderer.sprite = lixeiraVazia;
        }
    }
}
