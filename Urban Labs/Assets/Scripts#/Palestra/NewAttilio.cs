using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttilio : MonoBehaviour
{
    [SerializeField] GameObject choiceButtons;
    [SerializeField] GameObject finishButtons;

    public void Choose()
    {
        choiceButtons.SetActive(false);
        finishButtons.SetActive(true);
    }
}
