using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{


    private void Awake()
    {
        DontDestroyOnLoad(this);//アタッチしたやつを消えないようにする
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "CharacterSelectScene1")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetButtonDown("Button_A1") || Input.GetButtonDown("Button_A2"))
            {
                SceneManager.LoadScene("ButtleScene");

            }
            if (Input.GetKey(KeyCode.B) || Input.GetButtonDown("Button_B1") || Input.GetButtonDown("Button_B2"))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        
    }
}
