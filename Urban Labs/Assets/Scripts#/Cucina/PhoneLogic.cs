using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class PhoneLogic : MonoBehaviour
{
    [SerializeField] GameObject phoneNumbers;
    [SerializeField] Text textNumbers;
    [SerializeField] GameObject frase;

    [SerializeField] AudioClip audioSbagliato;
    [SerializeField] AudioClip audio115;

    AudioSource audioTelefono;
    GameLogic gameLogic;
    string phoneText = "";

    IstruzioniEstintore istruzioni;

    // Start is called before the first frame update
    void Start()
    {
        audioTelefono = GetComponent<AudioSource>();
        gameLogic = FindObjectOfType<GameLogic>();
        phoneNumbers.SetActive(false);
        Debug.Log(SteamVR.instance.hmd_Type);
        istruzioni = FindObjectOfType<IstruzioniEstintore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameLogic.GetState() == 2)
        {
            gameLogic.NextState();
            phoneNumbers.SetActive(true);

        }
    }

    public void CheckNumber()
    {
        if (textNumbers.text.Length == 3)
        {
            if (textNumbers.text == "115")
            {
                gameLogic.NextState();
                phoneNumbers.SetActive(false);
                frase.SetActive(false);
                audioTelefono.clip = audio115;
                audioTelefono.Play();
                istruzioni.AttivaIstruzioni();
            }
            else
            {
                phoneText = "";
                textNumbers.text = "";
                audioTelefono.clip = audioSbagliato;
                audioTelefono.Play();
            }
        }
        
    }

    public void AddNumber(string s)
    {
        phoneText += s;
        textNumbers.text = phoneText;
        CheckNumber();
    }
}
