using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrecciaUfficio : MonoBehaviour
{
    [SerializeField] Transform[] targetPositions;
    [SerializeField] int positionIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetPositions[positionIndex].position;
    }

    public void NextPos()
    {
        positionIndex++;
    }
}
