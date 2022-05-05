using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicuraScript : MonoBehaviour
{
    [SerializeField] GameObject estintore;
    SpringJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(estintore.transform.position, transform.position);
        if (dist > .13f)
        {
            Destroy(gameObject);
        }
    }
}
