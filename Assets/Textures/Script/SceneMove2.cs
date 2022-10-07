using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove2 : MonoBehaviour
{


    private void Awake()
    {
        DontDestroyOnLoad(this);//アタッチしたやつを消えないようにする
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.CharacterSelect);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "CharacterSelectScene2")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetButtonDown("Button_A1") || Input.GetButtonDown("Button_A2"))
            {
                SceneManager.LoadScene("ButtleScene");
                SoundManager.Instance.PlaySE(SE.OKButton);

            }
            if (Input.GetKey(KeyCode.B) || Input.GetButtonDown("Button_B1") || Input.GetButtonDown("Button_B2"))
            {
                SceneManager.LoadScene("TitleScene");
                SoundManager.Instance.PlaySE(SE.OKButton);
            }
        }
        
    }
}
