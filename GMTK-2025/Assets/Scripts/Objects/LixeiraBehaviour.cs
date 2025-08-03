using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LixeiraBehaviour : MonoBehaviour
{
    [Header("Lixeira Properts")]
    public int maxLixo;
    public int currentLixo;
    public int lixeiraEspaco;

    [Header("Sprite Changer")]
    public Sprite[] spritesLixeira;
    
    //Private variables
    private LixoManager playerLixoManager;
    SpriteRenderer spriteRenderer;

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
        spriteRenderer.sprite = spritesLixeira[currentLixo];
    }
}
