using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class PhoneLogic : MonoBehaviour
{
    [SerializeField] GameObject phoneNumbers;
    [SerializeField] Text textNumbers;
    GameLogic gameLogic;
    string phoneText = "";

    

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        phoneNumbers.SetActive(false);
        Debug.Log(SteamVR.instance.hmd_Type);
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
            }
            else
            {
                phoneText = "";
                textNumbers.text = "";
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
