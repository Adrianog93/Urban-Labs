using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrecciaUfficio : MonoBehaviour
{
    [SerializeField] Transform[] targetPositions;
    int pos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = FindObjectOfType<UfficioGameLogic>().GetDialogue();
        transform.position = targetPositions[pos].position;
    }

}
