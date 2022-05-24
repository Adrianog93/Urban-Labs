using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttilioMorto : MonoBehaviour
{
    [SerializeField] GameObject attilio;
    [SerializeField] GameObject pt;
    [SerializeField] SkinnedMeshRenderer mouthBlend;

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
     * 3 finisci il tapis
     * 4 apri la bocca e controlli il respiro
     * 5 massaggio
     */
}
