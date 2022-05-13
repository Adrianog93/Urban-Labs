using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;
using BNG;

public class ActivateLocomotion : MonoBehaviour
{
    public ControllerBinding ToggleHandsInput = ControllerBinding.RightThumbstickDown;

    // Start is called before the first frame update
    void Start()
    {
       //bridge = GetComponent<InputBridge>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ToggleHandsInput.GetDown())
        {
            //Debug.Log("Diocane");
        }
    }

    public void OnOk()
    {

    }
}
