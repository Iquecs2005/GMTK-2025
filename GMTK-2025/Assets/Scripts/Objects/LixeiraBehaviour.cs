using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LixeiraBehaviour : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text currentTrash;
    [SerializeField] private TMP_Text totalTrash;

    [Header("Lixeira Properts")]
    public int maxLixo;
    public int currentLixo;
    public int lixeiraEspaco;

    [Header("Sprite Changer")]
    public Sprite lixeiraVazia;
    public Sprite lixeiraCheia;
    
    //Private variables
    private LixoManager playerLixoManager;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        lixeiraEspaco = maxLixo - currentLixo;
        UpdateUI();

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
                UpdateUI();

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

    private void UpdateUI() 
    {
        currentTrash.text = currentLixo.ToString();
        totalTrash.text = maxLixo.ToString();
    }
}
