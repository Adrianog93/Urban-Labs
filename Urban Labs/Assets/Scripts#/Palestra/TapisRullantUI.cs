using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class TapisRullantUI : MonoBehaviour
{
    [SerializeField] Text speedText;
    [SerializeField] Text inclineText;

    [SerializeField] GameObject playButton;
    [SerializeField] GameObject UIButtons;
    [SerializeField] GameObject secondUI;
    [SerializeField] GameObject instructionUI;
    [SerializeField] GameObject levaCascoUI;
 
    [SerializeField] GameObject freccia;

    BNGPlayerController player;
    GameLogic logic;

    int speedValue = 0;
    int inclineValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BNGPlayerController>();
        logic = FindObjectOfType<GameLogic>();
        playButton.SetActive(false);
        UIButtons.SetActive(false);
        UpdateText();
    }

    private void Update()
    {
        if (logic.State == 2)
        {
            freccia.SetActive(true);
            UIButtons.SetActive(true);
        }
        else
        {
            UIButtons.SetActive(false);
        }
        float dist = Vector3.Distance(transform.position, player.gameObject.transform.position);
        if (dist < 3)
        {
            freccia.SetActive(false);
        }
        //if (logic.State == 3)
        //{
        //    secondUI.SetActive(true);
        //}
        //else
        //{
        //    secondUI.SetActive(false);
        //}
    }

    private void UpdateText()
    {
        if (speedValue > 8)
        {
            speedValue = 8;
        }
        if (speedValue < 0)
        {
            speedValue = 0;
        }
        if (inclineValue > 8)
        {
            inclineValue = 8;
        }
        if (inclineValue < 0)
        {
            inclineValue = 0;
        }
        speedText.text = speedValue.ToString();
        inclineText.text = inclineValue.ToString();
        if (speedValue>0 && inclineValue>0)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }

    // Update is called once per frame
    

    public void PlusSpeed()
    {
        speedValue++;
        UpdateText();
    }
    public void PlusIncline()
    {
        inclineValue++;
        UpdateText();
    }
    public void MinusSpeed()
    {
        speedValue--;
        UpdateText();
    }
    public void MinusIncline()
    {
        inclineValue--;
        UpdateText();
    }

    public void NextState()
    {
        if (logic.State == 2)
        {
            logic.NextState();
            secondUI.SetActive(false);
            instructionUI.SetActive(true);
        }
    }

    public void Procedi()
    {
        levaCascoUI.SetActive(false);
        secondUI.SetActive(true);
    }

    public void PlayButton()
    {
        levaCascoUI.SetActive(true);
    }
}
