using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class EstintoreScript : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    bool canShoot = false;
    Interactable interactable;
    Vector3 startPos;
    [SerializeField] ParticleSystem particle;
    [SerializeField] CapsuleCollider schiuma;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (fireAction[source].state && canShoot)
            {
                particle.Play();
                schiuma.enabled = true;
            }
            else
            {
                particle.Stop();
                schiuma.enabled = false;
            }
        }
      //  Debug.Log(transform.GetChild(0).childCount);
        if (transform.childCount==2 && !canShoot)
        {
            canShoot = true;
        }
    }

}
