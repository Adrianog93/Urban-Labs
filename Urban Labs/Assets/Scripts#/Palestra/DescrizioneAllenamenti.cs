using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescrizioneAllenamenti : MonoBehaviour
{
    [SerializeField] GameObject descriptionUI;
    [SerializeField] GameObject choiceUI;
    [SerializeField] GameObject risorseUI;
    [SerializeField] TMP_Text testo;

    GameLogic logic;


    private void Start()
    {
        descriptionUI.SetActive(false);
        logic = FindObjectOfType<GameLogic>();
        risorseUI.SetActive(false);
    }

    public void Calorie()
    {
        choiceUI.SetActive(false);
        descriptionUI.SetActive(true);
        testo.text = "Per la perdita di massa grassa prima o dopo la seduta";
    }

    public void Salute()
    {
        choiceUI.SetActive(false);
        descriptionUI.SetActive(true);
        testo.text = "Per aumentare la tonicità e riprendere un'attività cardio";

    }

    public void Frazionato()
    {
        choiceUI.SetActive(false);
        descriptionUI.SetActive(true);
        testo.text = "Per sviluppare e mantenere la potenza";

    }

    public void Resistenza()
    {
        choiceUI.SetActive(false);
        descriptionUI.SetActive(true);
        testo.text = "Per migliorare la condizione fisica e la resistenza";

    }

    public void Indietro()
    {
        choiceUI.SetActive(true);
        descriptionUI.SetActive(false);
    }

    public void Next()
    {
        choiceUI.SetActive(false);
        descriptionUI.SetActive(false);
        risorseUI.SetActive(true);
    }

    public void Finish()
    {
        risorseUI.SetActive(false);
        logic.NextState();
    }

}
