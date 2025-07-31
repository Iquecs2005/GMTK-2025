using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoManager : MonoBehaviour
{
    public int currentLixo;

    public void AddLixo(int value)
    {
        currentLixo += value;
    }
}
