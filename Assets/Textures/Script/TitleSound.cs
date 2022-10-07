using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clickSE;
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
        if(SceneManager.GetActiveScene().name == "TitleScene")
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSource.PlayOneShot(clickSE);
        }
        
    }
}
