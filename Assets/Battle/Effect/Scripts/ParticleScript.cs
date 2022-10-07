using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public GameObject particleObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hit_Body_P1" || collision.gameObject.tag == "Hit_Body_P2") //Objectタグの付いたゲームオブジェクトと衝突したか判別
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
            Destroy(this.gameObject); //衝突したゲームオブジェクトを削除
        }
    }
}
