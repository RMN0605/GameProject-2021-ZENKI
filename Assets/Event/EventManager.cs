using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private GameObject Game_Setting;

    [Header("最初の60秒間を飛ばすスイッチ")]
    public bool OnOff = false;

    [Header("A～Bの間にイベントを発生させる")]
    public float TimeA;
    public float TimeB;

    [Header("攻撃力アップ倍率")]
    public float AtcRatio;

    [Header("プレイヤー速度の鈍化割合")]
    public float PlayerSlow;

    [Header("鈍化中の弾速")]
    public float BulletSpeed1, BulletSpeed2;

    [Header("不利プレイヤー攻撃力アップの時間")]
    public float Time_AtcUP;
    [Header("鈍化の時間")]
    public float Time_Speed;
    [Header("吸収攻撃の時間")]
    public float Time_HP;

    [Header("アナウンス文字")]
    public GameObject EventText;
    public string Event1tex;
    public string Event2tex;
    public string Event3tex;
    public string Event4tex;

    [Header("イベント処理用変数(触らないでね)")]
    float EventCount;//イベントまでのカウントダウン
    public bool B_Switch = false;//バリアのスイッチ
    public bool EventSwitch;//時間の乱数生成を制御するスイッチ
    float Time2, Time3, Time5;//各イベントのカウントダウン用
    bool Barrier = false;//バリアが一度使ったか判断するスイッチ
    private float x;//最初の60秒のカウント
    float E_Atc1, E_Atc2;//エンハンス後の攻撃力を保管しておく変数
    public float S_Speed1, S_Speed2;//デバフ後の移動力を保管しておく変数
    int Rand;//乱数格納
    public int EventNumber;//イベントの数
    public GameObject LifeItem;//回復アイテムのprefab
    public GameObject Canvas;
    private bool SoundOn = false;
    //ステータス保存用
    float HP1, Atc1, Speed1, BSpeed1;
    float HP2, Atc2, Speed2, BSpeed2;
    //プレイヤーオブジェクト格納
    public GameObject L1_Rigid, L2_Rigid;//回避側の自機
    public GameObject R1_Shoter, R2_Shoter;//攻撃側の自機
    public GameObject Move_L1, Move_L2;//回避側のスピード取得


    void Start()
    {

        Atc1 = R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent;
        Atc2 = R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent;
        E_Atc1 = Atc1 * AtcRatio;
        E_Atc2 = Atc2 * AtcRatio;
        Speed1 = Move_L1.GetComponent<Player_Move1>().Character_Speed;
        Speed2 = Move_L2.GetComponent<Player_Move2>().Character_Speed;
        S_Speed1 = Speed1 * PlayerSlow;
        S_Speed2 = Speed2 * PlayerSlow;
        EventSwitch = false;
        x = 60;
        SoundManager.Instance.PlayBGM(BGM.BattleBGM);

        Game_Setting = GameObject.Find("Game_Setting");
    }

    void Update()
    {
        if (Game_Setting.GetComponent<Setting>().syouhai == false)
        {
            
            Textchange();

            //最初の60秒
            x -= Time.deltaTime;
            if (x <= 0) { OnOff = true; }

            //イベント発生までの時間の振れ幅を決める
            //どのイベントを行うか決める
            if (EventSwitch == false && OnOff == true)
            {
                EventCount = UnityEngine.Random.Range(TimeA, TimeB);
                //イベントの個数を把握し、その中からランダムな数を取り出す
                Rand = UnityEngine.Random.Range(1, EventNumber + 1);
                EventSwitch = true;
                SoundOn = false;
            }

            EventCount -= Time.deltaTime;//イベント発生までのカウントダウン

            //【デバッグ用】押したキーの番号のイベントに変更
            Eventchange();

            //カウントが終っている間はイベントを行う
            if (EventCount <= 0)
            {
                if(SoundOn == false)
                {
                    SoundManager.Instance.PlaySE(SE.EventSound);
                    SoundOn = true;
                }
                switch (Rand)
                {
                    case 1:
                        Event1();
                        break;
                    case 2:
                        Event2();
                        break;
                    case 3:
                        Event3();
                        break;
                    case 4:
                        Event4();
                        break;
                }
            }
        }
        else
        {
            EventText.SetActive(false);
        }
    }

    //各イベントの処理
    void Event1()//ライフ回復イベント
    {
        GameObject HeelItem = (GameObject)Instantiate(LifeItem);
        HeelItem.transform.SetParent(Canvas.transform, false);
        HeelItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-500,350);
        GameObject HeelItem2 = (GameObject) Instantiate(LifeItem, new Vector2(0,0), Quaternion.Euler(0, 0, 180f));
        HeelItem2.transform.SetParent(Canvas.transform, false);
        HeelItem2.GetComponent<RectTransform>().anchoredPosition = new Vector2(500, -350);
        
        //最後にスイッチを戻してカウントの乱数を生成できるようにする
        EventSwitch = false;
    }

    void Event2()//不利プレイヤー攻撃力アップイベント
    {
        HP1 = L1_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
        HP2 = L2_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
        /*ここにプレイヤーの攻撃力を参照する文を書く*/
        Time2 += Time.deltaTime;
        if (HP1 < HP2)
        {
            R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = E_Atc1;
            R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc2;
        }
        else if (HP1 > HP2)
        {
            R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = E_Atc2;
            R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc1;
        }

        if (Time_AtcUP <= Time2)//攻撃力を元に戻す
        {

            R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc1;
            R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc2;
            Time2 = 0;
            EventSwitch = false;
        }
    }

    void Event3()
    {
        L1_Rigid.GetComponent<Event_Manager>().HPSwitch = true;
        L2_Rigid.GetComponent<Event_Manager>().HPSwitch = true;
        Time5 += Time.deltaTime;
        if (Time5 >= Time_HP)
        {
            L1_Rigid.GetComponent<Event_Manager>().HPSwitch = false;
            L2_Rigid.GetComponent<Event_Manager>().HPSwitch = false;
            EventSwitch = false;
            Time5 = 0;
        }
    }

    void Event4()
    {
        HP1 = L1_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
        HP2 = L2_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
        if (Barrier == false)
        {
            if (HP1 < HP2)
            {
                L1_Rigid.GetComponent<Event_Manager>().barrier_number = 1;
                B_Switch = L1_Rigid.GetComponent<Event_Manager>().B_Switch =true;
                Barrier = true;
                EventSwitch = false;
            }
            else if (HP2 < HP1)
            {
                L2_Rigid.GetComponent<Event_Manager>().barrier_number = 1;
                B_Switch = L2_Rigid.GetComponent<Event_Manager>().B_Switch = true;
                Barrier = true;
                EventSwitch = false;
            }
        }
        else
        {
            Rand = UnityEngine.Random.Range(1, EventNumber + 1);
        }
        
    }

    void Textchange()
    {
        Text Etext = EventText.GetComponent<Text>();

        if (EventCount <= 0)
        {
            switch (Rand)
            {
                case 1:
                    Etext.text = Event1tex;
                    break;
                case 2:
                    Etext.text = Event2tex;
                    break;
                case 3:
                    Etext.text = Event3tex;
                    break;
                case 4:
                    Etext.text = Event4tex;
                    break;
            }
        }
        else
        {
            Etext = null;
        }
    }

    //【デバッグ用】押したキーの番号のイベントに変更
    void Eventchange()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    switch(code)
                    {
                        case KeyCode.Alpha1:
                            Rand = 1;
                            break;
                        case KeyCode.Alpha2:
                            Rand = 2;
                            break;
                        case KeyCode.Alpha3:
                            Rand = 3;
                            break;
                        case KeyCode.Alpha4:
                            Rand = 4;
                            break;
                    }
                    //Debug.Log(Rand);
                    break;
                }
            }
        }
    }
}
