using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfficioGameLogic : MonoBehaviour
{
    int sceneState = 0;
    int completeDialogues = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextState()
    {
        sceneState++;
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
        completeDialogues = 7;
    }
}
