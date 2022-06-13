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
    [SerializeField] Animator anim;
    [SerializeField] GameObject mouthSlider;
    [SerializeField] GameObject headSlider;

    [SerializeField] GameObject respiroButtons;
 
    GameLogic logic;
    bool mouthCheck = false;
    bool breathCheck = false;
    bool canRotate = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = FindObjectOfType<GameLogic>();
        attilio.SetActive(false);
        mouthSlider.SetActive(false);
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
        if (value > 100)
        {
            value = 100;
        }
        if (value < 0)
        {
            value = 0;
        }
        Debug.Log(value);
        mouthBlend.SetBlendShapeWeight(61, value);
        mouthBlend.SetBlendShapeWeight(67, value);

        if (value == 100)
        {
            CheckMouth();
        }
    }

    public void RotateHead(float value)
    {
        if (value < 100 && canRotate)
        {
            anim.Play("Base Layer.AttilioRotation", 0, value / 100);

        }
        else
        {
            canRotate = false;
            mouthSlider.SetActive(true);
            headSlider.SetActive(false);
        }

    }

    public void CheckMouth()
    {
        mouthCheck = true;
        respiroButtons.SetActive(true);
        instructionText.text = "Avvicina l'orecchio alla bocca e verifica rigonfiamento cassa toracica. \nSi gonfia?";
    }



    public void CheckBreath()
    {
        if (mouthCheck)
        {
            respiroButtons.SetActive(false);
            breathCheck = true;
            instructionText.text = "Bene ora fai un massaggio cardiaco.\n Prendi la mano sinistra con la destra e spingi forte sul petto 30 volte!";
        }
    }


}
