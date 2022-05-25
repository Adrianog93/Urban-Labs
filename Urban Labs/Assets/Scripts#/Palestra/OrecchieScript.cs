using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrecchieScript : MonoBehaviour
{
    CapsuleCollider orecchieCollider;
    GameLogic logic;
    AttilioMorto attilio;
    // Start is called before the first frame update
    void Start()
    {
        orecchieCollider = GetComponent<CapsuleCollider>();
        logic = FindObjectOfType<GameLogic>();
        attilio = FindObjectOfType<AttilioMorto>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "audio")
        {
            if (logic.State == 3)
            {
                attilio.CheckBreath();
            }
        }
    }
}
