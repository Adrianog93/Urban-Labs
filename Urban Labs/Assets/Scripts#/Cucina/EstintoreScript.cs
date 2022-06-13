using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using UnityEngine.VFX;
//using Valve.VR.InteractionSystem;

public class EstintoreScript : MonoBehaviour
{
    AudioSource estAudio;
    bool canShoot = false;
    bool haveSecure = true;

    float timer = 0;
    
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
        FixPosition();
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
        if (!haveSecure)
        {
            estAudio.Play();
        }
        else
        {
        }

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

    public bool HaveSecure
    {
        get => haveSecure;
    }

    public void FixPosition()
    {
        if (transform.position.x > 8.4f)
        {
            transform.position = new Vector3(8.4f,
                transform.position.y, transform.position.z);
        }
        if (transform.position.x < -7.7f)
        {
            transform.position = new Vector3(-7.7f,
                transform.position.y, transform.position.z);
        }
        if (transform.position.y > 3)
        {
            transform.position = new Vector3(transform.position.x,
                3, transform.position.z);
        }
        if (transform.position.y < .1f)
        {
            transform.position = new Vector3(transform.position.x,
                .3f, transform.position.z);
        }
        if (transform.position.z > 4.75f)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y, 4.75f);
        }
        if (transform.position.z < -4.75f)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y, -4.75f);
        }


    }
    
}
