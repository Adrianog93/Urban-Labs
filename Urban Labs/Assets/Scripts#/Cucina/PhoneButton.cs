using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    [SerializeField] string num;

    PhoneLogic phoneLogic;
    AudioSource buttonAudio;

    private void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
        phoneLogic = FindObjectOfType<PhoneLogic>();
    }
    // Start is called before the first frame update
    public void AddButton()
    {
        phoneLogic.AddNumber(num);
    }

    public void PlayButton()
    {
        buttonAudio.Play();
    }


}
