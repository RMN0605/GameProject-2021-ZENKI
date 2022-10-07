using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChange : MonoBehaviour
{
    private bool Button = false;

    [SerializeField]
    private float ChangeTime;

    private float TimeBox;
    // Start is called before the first frame update
    void Start()
    {
        //É^ÉCÉgÉãBGMÇçƒê∂Ç∑ÇÈ
        SoundManager.Instance.PlayBGM(BGM.TitleBGM);
        TimeBox = ChangeTime;
    }

    // Update is called once per frame
    void Update()
    {
        TitleChange();
    }

    public void TitleChange()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetButtonDown("Button_A1"))
        {
            SoundManager.Instance.PlaySE(SE.TitleButton);
            Button = true;
        }
        if(Button == true)
        {
            TimeBox -= Time.deltaTime;
        }
        if(TimeBox <= 0)
        {
            SceneChange();
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("CharacterSelectScene1");
    }
}
