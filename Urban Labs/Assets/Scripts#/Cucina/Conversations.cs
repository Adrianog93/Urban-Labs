using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversations : MonoBehaviour
{
    [SerializeField] Sprite[] testi;
    [SerializeField] Sprite[] risposte1;
    [SerializeField] Sprite[] risposte2;
    [SerializeField] Sprite[] risposte3;
    [SerializeField] Sprite[] risposte4;

    [SerializeField] Image testo;
    [SerializeField] Image risposta1;
    [SerializeField] Image risposta2;
    [SerializeField] Image risposta3;
    [SerializeField] Image risposta4;

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
        if (convIndex < risposte1.Length)
        {
            risposta1.sprite = risposte1[convIndex];
            risposta2.sprite = risposte2[convIndex];
            risposta3.sprite = risposte3[convIndex];
            risposta4.sprite = risposte4[convIndex];
        }
        
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
       // Debug.Log(convIndex);
    }
}
