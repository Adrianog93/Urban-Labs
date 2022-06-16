using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BNG;

public class ComandiScript : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] Sprite[] imgs;
    [SerializeField] Image img;
    [SerializeField] GameObject cube;
    int index = 0;
    float timer = 5f;
    bool isGrab = false;
    InputBridge player;
    private void Start()
    {
        img.sprite = imgs[index];
        player = InputBridge.Instance;
    }
    private void Update()
    {
        switch (index)
        {
            case 0:
                timer -= Time.deltaTime;
                button.SetActive(timer < 0);
                break;
            case 1:
                if (player.RightThumbstickDown)
                {
                    button.SetActive(true);
                }
                break;
            case 2:
                if (player.LeftThumbstickUp)
                {
                    button.SetActive(true);
                }
                break;
            case 3:
                cube.SetActive(true);
                if (isGrab)
                {
                    button.SetActive(true);
                }
                break;
            case 4:
                timer = 3;
                button.SetActive(timer < 0);
                break;
        }
        
    }

    public void IsGrab()
    {
        isGrab = true;
    }

    public void NextButton()
    {
        index++;
        if (index >= imgs.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else {
            img.sprite = imgs[index];
            button.SetActive(false);
        }
        

    }
}
