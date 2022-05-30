using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class SpalshScreen : MonoBehaviour
{
    [SerializeField] VideoPlayer player;

    float time = 9;
    int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }
}
