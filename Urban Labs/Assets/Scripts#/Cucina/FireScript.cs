using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireScript : MonoBehaviour
{
    [SerializeField] GameObject firstConversation;
    [SerializeField] GameObject secondConversation;
    [SerializeField] float speed = .01f;

    GameLogic gameLogic;
    bool startFire = false;
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
        fire = GetComponent<ParticleSystem>();
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
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
        
    //}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Schiuma" && gameLogic.State >= 2 && !estintore.HaveSecure)
        {

            Debug.Log("Fuoco");
            transform.localScale = new Vector3(transform.localScale.x - speed * Time.deltaTime,
                transform.localScale.y - speed * Time.deltaTime, transform.localScale.z - speed * Time.deltaTime);
            if (transform.localScale.x < speed)
            {
                Destroy(gameObject);
                firstConversation.SetActive(false);
                secondConversation.SetActive(true);
            }
        }
    }
    
}
