using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Timer : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//参照系

    public Text count_text_L1;  //テキストをいじるためにテキストを格納するものだよ
    public Text count_text_L2;  //テキストをいじるためにテキストを格納するものだよ

//--------------------------------------------------------------------------------------
//変数系

    public float count_down = 4f;  //カウントダウンする時間だよ
    int count;  //整数に直した数字を入れる変数だよ

    public bool is_start_chack = false;    //ゲームの開始するか見るよ
    bool chack = false; //処理が行われたかチェック
//--------------------------------------------------------------------------------------
//カウントダウンの処理

    void Update()
    {
        if(count_down >= 0)
        {
            count_down -= Time.deltaTime;
            count = (int)count_down;   //整数に直すよ
        //--------------------------------------------------------------------------------------
            count_text_L1.text = 
                (count != 0) ? count.ToString(): //表示するよ
                               "Start";          //表示するよ
            count_text_L2.text =
                (count != 0) ? count.ToString(): //表示するよ
                               "Start";          //表示するよ
        //--------------------------------------------------------------------------------------
        }
        if (count_down <= 0 && !chack)
        {
            count_text_L1.text = "";    //テキストを消すよ
            count_text_L2.text = "";    //テキストを消すよ
            is_start_chack = true;     //ゲームの開始だ！
            chack = true;
        }
    }
}
