using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversations : MonoBehaviour
{
    [SerializeField] Sprite[] testi;
    [SerializeField] Sprite[] risposte1;
    [SerializeField] Sprite[] risposte2;

    [SerializeField] Image testo;
    [SerializeField] Image risposta1;
    [SerializeField] Image risposta2;


    GameLogic gameLogic;

    int convIndex = 0;
    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        UpdateConversation();
    }

    public void UpdateConversation()
    {
        testo.sprite = testi[convIndex];
        risposta1.sprite = risposte1[convIndex];
        risposta2.sprite = risposte2[convIndex];
    }

    public void Next()
    {
        convIndex++;
        if (convIndex >= testi.Length)
        {
            gameLogic.NextState();
        }
        else
        {
            UpdateConversation();
        }
        Debug.Log(convIndex);
    }
}
