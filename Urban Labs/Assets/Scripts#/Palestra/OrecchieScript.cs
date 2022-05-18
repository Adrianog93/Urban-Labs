using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrecchieScript : MonoBehaviour
{
    CapsuleCollider orecchieCollider;
    PalestraLogic logic;
    // Start is called before the first frame update
    void Start()
    {
        orecchieCollider = GetComponent<CapsuleCollider>();
        logic = FindObjectOfType<PalestraLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "audio")
        {
            if (logic.State == 0)
            {
                logic.NextState();
            }
        }
    }
}
