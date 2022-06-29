using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class UfficioGameLogic : MonoBehaviour
{
    [SerializeField] GameObject personaggi;
    [SerializeField] GameObject computerUI;
    int sceneState = 0;
    int completeDialogues = 0;
    GameObject currentUser;
    ScreenFader fade;
    bool startQuit = false;
    float timeQuit = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        currentUser = personaggi.transform.GetChild(completeDialogues).gameObject;
        currentUser = currentUser.transform.Find("Canvas").gameObject;
        currentUser.SetActive(true);
        fade = FindObjectOfType<ScreenFader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startQuit)
        {
            timeQuit -= Time.deltaTime;
            if (timeQuit <= 0)
            {
                Application.Quit();
            }
        }
    }

    public void NextState()
    {
        currentUser.SetActive(false);
        //sceneState++;
        completeDialogues++;
        if (CheckDialogues())
        {
            computerUI.SetActive(true);
        }
        else
        {
            currentUser = personaggi.transform.GetChild(completeDialogues).gameObject;
            currentUser = currentUser.transform.Find("Canvas").gameObject;
            currentUser.SetActive(true);
        }
        
    }
    public bool CheckDialogues()
    {
        if (completeDialogues >= 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void NextConversation()
    {
        //completeDialogues++;
        NextState();
    }

    public void JumpConversations()
    {
        completeDialogues = 6;
    }

    public int GetDialogue()
    {
        return completeDialogues;
    }

    public void FinishScene()
    {
        fade.DoFadeIn();
        startQuit = true;
    }
}
