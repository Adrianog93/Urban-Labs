using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.VFX;
//using Valve.VR.InteractionSystem;

public class EstintoreScript : MonoBehaviour
{
    
    bool canShoot = false;
    bool haveSecure = true;
    
    Vector3 startPos;
   // [SerializeField] ParticleSystem particle;
    [SerializeField] ParticleSystem schiuma;
    // Start is called before the first frame update
    void Start()
    {
        //interactable = GetComponent<Interactable>();
        schiuma.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && !haveSecure)
        {
            //particle.Play();
            schiuma.Play();
            Debug.Log("AAAA");
        }
        else
        {
            schiuma.Stop();
//            schiuma.enabled = false;
        }

    }

    public void Fire()
    {
        canShoot = true;
    }
    
    public void NotFire()
    {
        canShoot = false;
    }

    public void Secured()
    {
        haveSecure = false;
    }

    
}
