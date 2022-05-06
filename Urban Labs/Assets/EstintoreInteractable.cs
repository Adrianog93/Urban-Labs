using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EstintoreInteractable : InteractableNew
{

    [HideInInspector] public bool canUse;
    private VisualEffect effect;
    private BoxCollider coll;

    private void Start() {
        isGrabbable = false;
        effect = transform.GetChild(1).gameObject.GetComponent<VisualEffect>();
        coll = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
    }
    public override void InteractEvent()
    {
        if(canUse){
            effect.Play();
            coll.enabled = true;
            SoundManager.instance.PlayAudio("Estintore");
        }
    }

    public override void StopEvent()
    {
        effect.Stop();
        coll.enabled = false;
        SoundManager.instance.StopAudio("Estintore");
    }
}
