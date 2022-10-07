//ル
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//参照系

    public Text syouhai_text_L1;  //テキストをいじるためにテキストを格納するものだよ
    public Text syouhai_text_L2;  //テキストをいじるためにテキストを格納するものだよ

//--------------------------------------------------------------------------------------
//変数系

    public bool last_of_agaki_check = false;  //最後のあがきを使ったかどうかチェック
    public bool syouhai = false;//勝敗が決まったか  false= また終わっていない。 true= 終わった
    public bool WINER;  //L1がかったらtrue、L2がかったらfalse
    public bool check = false; //消す処理や勝敗を表示する処理が行われたかチェック

    //--------------------------------------------------------------------------------------
    //最初の準備

    void Awake()
    {
        Application.targetFrameRate = 240; //FPSを240に設定 
    }

    //--------------------------------------------------------------------------------------
    //ゲームの勝敗に関する処理と弾の後処理

    private void Update()
    {
        if (syouhai)
        {
            if (!check)//勝敗がついたら消去開始
            {
                zenkesi();

                check = true;   //処理が終わったよ
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");   //スペース押したらタイトルへ
            }

        }

    }
    //消去の中身
    void zenkesi()
    {
        //ありとあらゆる弾を一つにまとめる
        GameObject[] Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_1");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_2");
        Clean(Bullets);
    }
    //消すぜえええええ
    void Clean(GameObject[] Bullets)
    {
        foreach (GameObject AllBullet in Bullets)
        {
            //ありとあらゆる弾を破壊
            Destroy(AllBullet);
        }
    }
}
