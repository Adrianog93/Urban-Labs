using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversations : MonoBehaviour
{
    [SerializeField] Text testo;
    [SerializeField] Text risposta1;
    [SerializeField] Text risposta2;


    List<string> conversations = new List<string>();
    List<string> answer1 = new List<string>();
    List<string> answer2 = new List<string>();

    GameLogic gameLogic;

    int convIndex = 0;
    private void Start()
    {
        CreateCOnversation();
        gameLogic = FindObjectOfType<GameLogic>();
        UpdateConversation();
    }

    private void CreateCOnversation()
    {
        string first = "Amico mio grazie di essere venuto subito, ho avuto una proposta di lavoro e ho 24 ore per accettarla. Accetto oppure no?";
        string second = "La retribuzione è di € 1200 lorde per 38 h settimanali, sabato e domenica esclusi. Sai io sono anche senza alcuna esperienza: ";
        string third = "Dovrei fare Information officer, fornire solo informazioni sui processi aziendali e ho la possibilità di suggerire miglioramenti";
        conversations.Add(first);
        conversations.Add(second);
        conversations.Add(third);

        answer1.Add("Si, subito!");
        answer1.Add("Accetta!");
        answer1.Add("Puoi anche migliorarli!");

        answer2.Add("La retribuzione?");
        answer2.Add("Cosa dovresti fare?");
        answer2.Add("Qual è l’Azienda?");
    }

    public string GetConversation(int pos)
    {
        return conversations[pos];
    }

    public void UpdateConversation()
    {
        testo.text = conversations[convIndex];
        risposta1.text = answer1[convIndex];
        risposta2.text = answer2[convIndex];
    }

    public void Next()
    {
        convIndex++;
        if (convIndex >= conversations.Count)
        {
            gameLogic.NextState();
        }
        else
        {
            UpdateConversation();
        }
    }
}
