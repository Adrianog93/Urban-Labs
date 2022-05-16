using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDoorScene : MonoBehaviour
{
    public enum Menuscene
    {
        Cucina,
        Ufficio,
        Palestra
    }

    [SerializeField] GameObject doorObject;
    public Menuscene nameScene;
    Vector3 startPoint;
    // Start is called before the first frame update
    private void Start()
    {
        startPoint = doorObject.transform.localRotation.eulerAngles;  
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 angle = doorObject.transform.localRotation.eulerAngles -
            startPoint;
        
        if (Mathf.Abs(angle.magnitude) > 30)
        {
           // Debug.Log("AAA");
            SceneManager.LoadScene(nameScene.ToString());
        } 
    }
}
