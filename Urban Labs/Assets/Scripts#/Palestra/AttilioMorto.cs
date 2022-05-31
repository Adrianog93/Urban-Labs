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


    GameLogic logic;
    bool mouthCheck = false;
    bool breathCheck = false;
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(value);
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
        instructionText.text = "Adesso controlla che stia respirando ancora! \n Avvicina l'orecchio alla bocca.";
    }

    public void CheckBreath()
    {
        if (mouthCheck)
        {
            breathCheck = true;
            instructionText.text = "Bene ora fai un massaggio cardiaco.\n Prendi la mano sinistra con la destra e spingi forte sul petto 3 volte!";
        }
    }


}
