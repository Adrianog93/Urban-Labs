using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    [SerializeField] string num;

    PhoneLogic phoneLogic;

    private void Start()
    {
        phoneLogic = FindObjectOfType<PhoneLogic>();
    }
    // Start is called before the first frame update
    public void AddButton()
    {
        phoneLogic.AddNumber(num);
    }
}
