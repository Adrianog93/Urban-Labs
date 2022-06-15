using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IstruzioniEstintore : MonoBehaviour
{
    [SerializeField] TMP_Text testo;
    [SerializeField] GameObject istruzioni;
    [SerializeField] RectTransform ui;
    [SerializeField] GameObject player;
    [SerializeField] GameObject secondUI;
    [SerializeField] GameObject frecciaEstintore;
 
    bool isGrab = false;
    private void Update()
    {
        if (isGrab)
        {
            ui.gameObject.SetActive(true);
            secondUI.SetActive(false);
        }
        ui.LookAt(player.transform);

    }
    public void PrendiEstintore()
    {
        testo.text = "Bene ora rimuovi la sicura con la mano sinistra";
        isGrab = true;
        frecciaEstintore.SetActive(false);
        AttivaIstruzioni();
    }

    public void RimuoviSicura()
    {
        testo.text = "Ottimo adesso vai vicino al fuoco, direziona il getto alla base e esegui un movimento a ventaglio";
    }


    public void AttivaIstruzioni()
    {
        istruzioni.SetActive(true);
    }
}
