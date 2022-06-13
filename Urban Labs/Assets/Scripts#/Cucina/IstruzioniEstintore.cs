using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IstruzioniEstintore : MonoBehaviour
{
    [SerializeField] TMP_Text testo;
    [SerializeField] GameObject istruzioni;
    public void PrendiEstintore()
    {
        testo.text = "Bene ora rimuovi la sicura con la mano sinistra";
    }

    public void RimuoviSicura()
    {
        testo.text = "Ottimo adesso vai vicino al fuoco e spegnilo";
    }

    public void AttivaIstruzioni()
    {
        istruzioni.SetActive(true);
    }
}
