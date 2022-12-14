//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_R : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_R;
 
    public float m_Player_MAXHP;
    public float m_Player_HP;
    public int m_set_agaki_HP;  //あがきが使えるようになるHP

    //勝敗を決める変数入れるよう
    GameObject Syouhai;
    GameObject PA;  //弾が当たった際のプレイヤーが受けるダメージ量を調べる変すだよ

    //--------------------------------------------------------------------------------------
    // ゲームのスタート時の処理

    private void Awake()
    {
        m_Player_MAXHP = 100;
        m_Player_HP = m_Player_MAXHP;
    }

    void Start()
    {
        //Rigidbody2D　コンポーネントを取得して変数　Player_R　に格納
        Player_R = GetComponent<Rigidbody2D>();

        //勝敗Bool取得
        Syouhai = GameObject.Find("Game_Setting");

        if (this.gameObject.CompareTag("Hit_Body_P1"))
        {
            PA = GameObject.Find("Player_L1");
        }
        else if (this.gameObject.CompareTag("Hit_Body_P2"))
        {
            PA = GameObject.Find("Player_L2");
        }
    }

    //--------------------------------------------------------------------------------------
    //あがきに関する処理

    void Update()
    {
        if((m_Player_HP < m_set_agaki_HP) && (PA.GetComponent<Player_Manager_L>().agaki == false))
        {
            PA.GetComponent<Player_Manager_L>().agaki = true;   //あがきを使えるようにするよ。
        }

        //体力が０以下の場合
        if (m_Player_HP <= 0)
        {
            #region 攻撃自機削除
            if (this.gameObject.CompareTag("Hit_Body_P1"))
            {
                Syouhai.GetComponent<Setting>().WINER = false;   //L２の勝ちにする
                GameObject PL = GameObject.Find("Player_L1");
                GameObject PR = GameObject.Find("Player_R1_Ma");
                //GameObject P_L1 = GameObject.Find("P_L1");
                //GameObject P_R1 = GameObject.Find("P_R1");
                //本体削除
                PL.SetActive(false);
                PR.SetActive(false);
                //P_L1.SetActive(false);
                //P_R1.SetActive(false);
            }
            else if (this.gameObject.CompareTag("Hit_Body_P2"))
            {
                Syouhai.GetComponent<Setting>().WINER = true; ;   //L１の勝ちにする
                GameObject PL = GameObject.Find("Player_L2");
                GameObject PR = GameObject.Find("Player_R2_Ma");
                //GameObject P_L2 = GameObject.Find("P_L2");
                //GameObject P_R2 = GameObject.Find("P_R2");
                //本体削除
                PL.SetActive(false);
                PR.SetActive(false);
                //P_L2.SetActive(false);
                //P_R2.SetActive(false);
            }
            #endregion
            Debug.Log("体力が [0] になりました。");
            //弾の発射を止める
            Syouhai.GetComponent<Setting>().syouhai = true;
            Debug.Log("ゲーム終了");
        }
    }

//--------------------------------------------------------------------------------------
//弾に当たった際の処理
    public void Damage(float damage)
    {
        //ダメージ倍率の計算
        damage *= PA.GetComponent<Player_Manager_L>().AttackPower_percent;
        //現在の体力からダメージを引く(倍率計算は行う)
        m_Player_HP -= damage;
        Debug.Log(damage + "ダメージを受けて残り" + m_Player_HP + "です");
    }
//--------------------------------------------------------------------------------------
}
