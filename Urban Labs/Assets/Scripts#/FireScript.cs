using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireScript : MonoBehaviour
{
    GameLogic gameLogic;
    bool startFire = false;
    ParticleSystem fire;
    [SerializeField] float speed = .05f;
    // Start is called before the first frame update
    void Start()
    {
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Schiuma")
        {
            Debug.Log("Fuoco");
            transform.localScale = new Vector3(transform.localScale.x - speed,
                transform.localScale.y - speed, transform.localScale.z - speed);
            if (transform.localScale.x < speed)
            {
                Destroy(gameObject);
            }
        }
    }
}
