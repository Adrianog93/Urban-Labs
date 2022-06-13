using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireScript : MonoBehaviour
{
    [SerializeField] GameObject firstConversation;
    [SerializeField] GameObject secondConversation;
    [SerializeField] float speed = .01f;
    [SerializeField] AudioClip fireAudio;


    GameLogic gameLogic;
    bool startFire = false;
    bool getBigger = false;
    ParticleSystem fire;
    AudioSource audio;
    EstintoreScript estintore;
    
    BoxCollider boxColl;
    // Start is called before the first frame update
    void Start()
    {
        estintore = FindObjectOfType<EstintoreScript>();
        audio = GetComponent<AudioSource>();
        audio.Stop();
        boxColl = GetComponent<BoxCollider>();
        gameLogic = FindObjectOfType<GameLogic>();
        fire = transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
        fire.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.GetState() == 2 && !startFire)
        {
            startFire = true;
            fire.enableEmission = true;
            fire.Play();
            audio.Play();
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            getBigger = true;
        }
        if (getBigger)
        {
            float size = fire.gameObject.transform.localScale.x +
                ((speed/5) * Time.deltaTime);
            fire.gameObject.transform.localScale = new Vector3(size, size, size);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
        
    //}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Schiuma" && gameLogic.State >= 2 && !estintore.HaveSecure)
        {
            float size = speed * Time.deltaTime;
            GameObject flame = transform.GetChild(2).gameObject;
            flame.transform.localScale =
                new Vector3(flame.transform.localScale.x - size,
                flame.transform.localScale.y - size,
                flame.transform.localScale.z - size);
            if (flame.transform.localScale.x < 0.01)
            {
                Destroy(gameObject);
                firstConversation.SetActive(false);
                secondConversation.SetActive(true);
            }
        }
    }
    
}
