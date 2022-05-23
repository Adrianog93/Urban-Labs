using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.VFX;
//using Valve.VR.InteractionSystem;

public class EstintoreScript : MonoBehaviour
{
    AudioSource estAudio;
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
        estAudio = GetComponent<AudioSource>();
        estAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && !haveSecure)
        {
            //particle.Play();
            schiuma.Play();
        }
        else
        {
            schiuma.Stop();
        }

    }

    public void Fire()
    {
        canShoot = true;
        estAudio.Play();

    }

    public void NotFire()
    {
        canShoot = false;
        estAudio.Stop();

    }

    public void Secured()
    {
        haveSecure = false;
    }

    
}
