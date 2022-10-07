using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelect1 : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Panel3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Button_A1"))
        {
            if (Panel1.activeSelf)
            {
                DataManager.Character = 1;
            }

            else if (Panel2.activeSelf)
            {
                DataManager.Character = 2;
            }
        }
    }
}
