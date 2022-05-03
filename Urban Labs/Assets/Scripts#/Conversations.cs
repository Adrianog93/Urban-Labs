using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversations : MonoBehaviour
{
    List<string> conversations = new List<string>();

    private void Start()
    {
        string first = "Amico mio grazie di essere venuto subito, ho avuto una proposta di lavoro e ho 24 ore per accettarla. Accetto oppure no?";
        string second = "La retribuzione è di € 1200 lorde per 38 h settimanali, sabato e domenica esclusi. Sai io sono anche senza alcuna esperienza: ";
        string third = "Dovrei fare Information officer, fornire solo informazioni sui processi aziendali e ho la possibilità di suggerire miglioramenti";
        conversations.Add(first);
        conversations.Add(second);
        conversations.Add(third);
    }

    public string GetConversation(int pos)
    {
        return conversations[pos];
    }
}
