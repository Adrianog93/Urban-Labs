using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.VFX;
//using Valve.VR.InteractionSystem;

public class EstintoreScript : MonoBehaviour
{
    AudioSource audio;
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
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && !haveSecure)
        {
            //particle.Play();
            schiuma.Play();
            audio.Play();
        }
        else
        {
            schiuma.Stop();
            audio.Stop();
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
