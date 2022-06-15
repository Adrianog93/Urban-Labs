using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attilio : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject choices;

    GameLogic gameLogic;

    bool start = false;
    bool startDescription = false;
    Vector3 AttilioRotation;
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        AttilioRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(AttilioRotation.x, transform.eulerAngles.y, AttilioRotation.z);

        if (GetDistance() < 3 && !start)
        {
            start = true;
            gameLogic.NextState();
        }
        if (gameLogic.GetState() == 1)
        {
            if (!startDescription)
            {
                startDescription = true;
                buttons.SetActive(true);
                choices.SetActive(true);
            }
            
        }
        else
        {
            choices.SetActive(false);
        }

    }

    public float GetDistance()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }

}
