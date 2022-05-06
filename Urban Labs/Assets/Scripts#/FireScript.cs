using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireScript : MonoBehaviour
{
    GameLogic gameLogic;
    bool startFire = false;
    VisualEffect fire;
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        fire = GetComponent<VisualEffect>();
        fire.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.GetState() == 2 && !startFire)
        {
            startFire = true;
            fire.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Schiuma")
        {
            Debug.Log("Fuoco");
            transform.localScale = new Vector3(transform.localScale.x - .1f, transform.localScale.y - .1f, transform.localScale.z - .1f);
            if (transform.localScale.x < .1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
