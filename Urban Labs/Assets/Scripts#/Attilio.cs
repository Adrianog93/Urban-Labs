using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attilio : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject buttons;

    GameLogic gameLogic;

    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        if (GetDistance() < 2 && !start)
        {
            start = true;
            gameLogic.NextState();
        }
        if (gameLogic.GetState() == 1)
        {
            buttons.SetActive(true);
        }
        else
        {
            buttons.SetActive(false);
        }

    }

    public float GetDistance()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }
}
