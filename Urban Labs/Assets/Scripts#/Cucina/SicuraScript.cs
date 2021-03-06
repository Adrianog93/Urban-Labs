using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicuraScript : MonoBehaviour
{
    [SerializeField] GameObject estintoreBody;
    SpringJoint joint;
    EstintoreScript estintore;
    IstruzioniEstintore istruzioni;
    // Start is called before the first frame update
    void Start()
    {
        istruzioni = FindObjectOfType<IstruzioniEstintore>();
        estintore = estintoreBody.GetComponent<EstintoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(estintoreBody.transform.position, transform.position);
        if (dist > .13f)
        {
            istruzioni.RimuoviSicura();
            estintore.Secured();
            Destroy(gameObject);
        }
    }

    
}
