using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLogic : MonoBehaviour
{
    [SerializeField] GameObject phoneNumbers;
    [SerializeField] GameObject textNumbers;
    GameLogic gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.GetState() == 3)
        {
            phoneNumbers.SetActive(true);
        }
        else
        {
            phoneNumbers.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameLogic.GetState() == 2)
        {
            gameLogic.NextState();
        }
    }

    public void CheckNumber()
    {
        if (textNumbers.GetComponent<Text>().text == "115")
        {
            gameLogic.NextState();
        }
        else
        {
            textNumbers.GetComponent<Text>().text = "";
        }
    }
}
