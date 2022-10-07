using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    public GameObject Player;

    public Slider HPGauge;
    private GameObject Gs;

    private float PlayerHP, PlayerHPMax, CurrentHP;

    void Start()
    {
        PlayerHPMax = Player.GetComponent<Player_Manager_R>().m_Player_MAXHP;
        Gs = GameObject.Find("Game_Setting");
        HPGauge.maxValue = PlayerHPMax;
    }

    private void Update()
    {
        if (!Gs.GetComponent<Setting>().syouhai)
        {
            PlayerHP = Player.GetComponent<Player_Manager_R>().m_Player_HP;
            HPGauge.value = PlayerHP;
        }
    }
}
