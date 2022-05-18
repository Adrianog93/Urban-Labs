using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.InputSystem;
using BNG;

public class MassaggioCardiaco : MonoBehaviour
{
    [SerializeField] GameObject leftHandOpen;
    [SerializeField] GameObject leftHandClosed;
    [SerializeField] GameObject rightAnchor;
    [SerializeField] GameObject leftAnchor;


    bool isAngle = false;
    bool isPos = false;
    bool isGrab = false;

    float angleDiff;
    SphereCollider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        if (myCollider != null)
        {
            Debug.Log("AA");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputBridge.Instance.LeftGrip > 0)
        {
            isGrab = true;
        }
        else
        {
            isGrab = false;
        }
        GetAngle();
        if (isPos && isAngle && isGrab)
        {
            leftHandOpen.gameObject.SetActive(false);
            leftHandClosed.gameObject.SetActive(true);
        }
        else
        {
            leftHandOpen.gameObject.SetActive(true);
            leftHandClosed.gameObject.SetActive(false);
        }
    }
    
    private void GetAngle()
    {
        angleDiff = Mathf.Abs(rightAnchor.transform.eulerAngles.y - leftAnchor.transform.eulerAngles.y);
        if (Mathf.Abs(angleDiff) > 180)
        {
            angleDiff -= 360;
        }
        Debug.Log(angleDiff);

        if (Mathf.Abs(angleDiff) < 160f && Mathf.Abs(angleDiff) > 70)
        {
            //Debug.Log(angleDiff);
            isAngle = true;

        }
        else
        {
            isAngle = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightPosition")
        {
            isPos = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RightPosition")
        {
            isPos = false;
        }
    }

}
