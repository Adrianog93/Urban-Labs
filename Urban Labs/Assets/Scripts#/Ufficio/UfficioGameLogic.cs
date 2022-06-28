using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfficioGameLogic : MonoBehaviour
{
    [SerializeField] GameObject personaggi;
    int sceneState = 0;
    int completeDialogues = 0;
    GameObject currentUser;
    // Start is called before the first frame update
    void Start()
    {
        currentUser = personaggi.transform.GetChild(completeDialogues).gameObject;
        currentUser = currentUser.transform.Find("Canvas").gameObject;
        currentUser.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NextState()
    {
        currentUser.SetActive(false);
        sceneState++;
        currentUser = personaggi.transform.GetChild(completeDialogues).gameObject;
        currentUser = currentUser.transform.Find("Canvas").gameObject;
        currentUser.SetActive(true);
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
        completeDialogues++;
    }

    public void JumpConversations()
    {
        completeDialogues = 6;
    }
}
