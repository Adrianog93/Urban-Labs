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

    PalestraLogic logic;


    bool isAngle = false;
    bool isPos = false;
    bool isGrab = false;
    bool canPunch = false;

    int punchCount = 0;

    float angleDiff;
    SphereCollider myCollider;

    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        PrevPos = transform.position;
        NewPos = transform.position;
        logic = FindObjectOfType<PalestraLogic>();
    }
    private void FixedUpdate()
    {
        GetVelocity();
        //if (ObjVelocity.y < -1f && canPunch)
        //{
        //    Debug.Log(ObjVelocity.y);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        GetGrab();
        GetAngle();
        GetPos();
    }
    public void GetVelocity()
    {
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
    }

    private void GetGrab()
    {
        if (InputBridge.Instance.LeftGrip > 0)
        {
            isGrab = true;
        }
        else
        {
            isGrab = false;
        }
    }

    private void GetPos()
    {
        if (isPos && isAngle && isGrab)
        {
            leftHandOpen.gameObject.SetActive(false);
            leftHandClosed.gameObject.SetActive(true);
            canPunch = true;
        }
        else
        {
            leftHandOpen.gameObject.SetActive(true);
            leftHandClosed.gameObject.SetActive(false);
            canPunch = false;
        }
    }

    private void GetAngle()
    {
        angleDiff = Mathf.Abs(rightAnchor.transform.eulerAngles.y - leftAnchor.transform.eulerAngles.y);
        if (Mathf.Abs(angleDiff) > 180)
        {
            angleDiff -= 360;
        }
        //Debug.Log(angleDiff);

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
        if (other.gameObject.name == "Chest" && ObjVelocity.y < -1f && canPunch)
        {
            if (logic.State == 4)
            {
                punchCount++;
                if (punchCount >= 3)
                {
                    logic.NextState();
                }
            }
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
