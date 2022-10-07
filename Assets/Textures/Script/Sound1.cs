using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound1 : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clickSE;
    public float time = 1.0f;
    private void Awake()
    {
        DontDestroyOnLoad(this);//アタッチしたやつを消えないようにする
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "CharacterSelectScene1")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                audioSource.PlayOneShot(clickSE);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                audioSource.PlayOneShot(clickSE);
            }
        }
    }
}
