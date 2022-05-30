using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttilioMorto : MonoBehaviour
{
    [SerializeField] GameObject attilio;
    [SerializeField] GameObject pt;
    [SerializeField] SkinnedMeshRenderer mouthBlend;
    [SerializeField] TMP_Text instructionText;

    Vector3 position0;
    Vector3 position1;
    [SerializeField] GameObject head;

    GameLogic logic;
    bool mouthCheck = false;
    bool breathCheck = false;
    // Start is called before the first frame update
    void Start()
    {
       // position0 = transform.localRotation;
        position1 = new Vector3(position0.x, position0.y + 50, position0.z);
        logic = FindObjectOfType<GameLogic>();
        attilio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.State == 3 && !mouthCheck)
        {
            attilio.SetActive(true);
            pt.SetActive(false);
        }else if(logic.State == 3 && mouthCheck && breathCheck){
            logic.NextState();
        }
    }

    public void OpenMouth(float value)
    {
        mouthBlend.SetBlendShapeWeight(61, value);
        mouthBlend.SetBlendShapeWeight(67, value);
        if (value == 100)
        {
            CheckMouth();
        }
    }

    public void CheckMouth()
    {
        mouthCheck = true;
        instructionText.text = "Ora controlla che stia respirando ancora!";
    }

    public void CheckBreath()
    {
        if (mouthCheck)
        {
            breathCheck = true;
            instructionText.text = "Bene adesso fai un massaggio cardiaco";
        }
    }

    public void RotateHead(float value)
    {
        Debug.Log(value);
        head.transform.localEulerAngles = Vector3.Lerp(position0, position1, value);
        
    }

    /* 1 ti avvicini
     * 2 finisci di parlare
     * 3 finisci il tapis
     * 4 apri la bocca e controlli il respiro
     * 5 massaggio
     */
}
