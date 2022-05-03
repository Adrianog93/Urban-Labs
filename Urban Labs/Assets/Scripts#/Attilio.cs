using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attilio : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject buttons;

    GameLogic gameLogic;
    
   
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (gameLogic.GetState() == 1)
        {
            buttons.SetActive(true);
        }
        else
        {
            buttons.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameLogic.GetState() == 0)
        {
            gameLogic.NextState();
        }
    }
}
