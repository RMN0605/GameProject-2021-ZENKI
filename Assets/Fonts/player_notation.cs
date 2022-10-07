using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_notation : MonoBehaviour
{
    public Text count_text;  //テキストをいじるためにテキストを格納するものだよ
    public GameObject Start_Timer;  //タイマーの残り時間を参照するものだよ

    void Start()
    {
        if (this.CompareTag("Player_L1"))
        {
            count_text.text = "P1";
        }
        else if (this.CompareTag("Player_L2"))
        {
            count_text.text = "P2";
        }
    }


    void Update()
    {
        if (Start_Timer.GetComponent<Start_Timer>().count_down <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}