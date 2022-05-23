using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttilioMorto : MonoBehaviour
{
    [SerializeField] GameObject attilio;
    [SerializeField] GameObject pt;
    [SerializeField] SkinnedMeshRenderer mouthBlend;
    [SerializeField] SkinnedMeshRenderer teethBlend;

    GameLogic logic;
    bool mouthCheck = false;
    bool breathCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        logic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.State == 4 && !mouthCheck)
        {
            attilio.SetActive(true);
            pt.SetActive(false);
        }else if(logic.State == 4 && mouthCheck && breathCheck){
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
    }

    public void CheckBreath()
    {
        breathCheck = true;
    }

    /* 1 ti avvicini
     * 2 finisci di parlare
     * 3 inizi il tapis
     * 4 finisci il tapis
     * 5 apri la bocca e controlli il respiro
     * 6 massaggio
     */
}
