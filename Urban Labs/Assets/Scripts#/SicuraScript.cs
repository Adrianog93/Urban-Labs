using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicuraScript : MonoBehaviour
{
    [SerializeField] GameObject estintoreBody;
    SpringJoint joint;
    EstintoreScript estintore;
    // Start is called before the first frame update
    void Start()
    {
        estintore = estintoreBody.GetComponent<EstintoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(estintoreBody.transform.position, transform.position);
        if (dist > .13f)
        {
            estintore.Secured();
            Destroy(gameObject);
        }
    }

    
}
