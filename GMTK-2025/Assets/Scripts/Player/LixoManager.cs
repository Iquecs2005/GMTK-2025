using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoManager : MonoBehaviour
{
    [SerializeField] private PlayerController pc;

    public int currentLixo;

    public void AddLixo(int value)
    {
        currentLixo += value;
        pc.ballSizeController.AddTrash(value);
    }

    public void JogarLixoFora(int value)
    {
        currentLixo -= value;
        pc.SetStickyBehaviour(false);
        pc.ballSizeController.RemoveTrash(value);
    }
}
