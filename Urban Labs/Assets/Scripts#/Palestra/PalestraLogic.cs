using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalestraLogic : MonoBehaviour
{
    int state = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int State
    {
        get => state; 
    }

    public void NextState()
    {
        state++;
    }

}
