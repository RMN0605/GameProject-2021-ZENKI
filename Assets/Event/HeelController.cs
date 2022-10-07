using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public int HeelPoint;
    public float FallSpeed;
    private Rigidbody2D rb;
    private float posx, posy;

    Player_Manager_R PlayerManager;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        GameObject EMane = GameObject.Find("EventManager");
        Player1 = EMane.GetComponent<EventManager>().L1_Rigid;
        Player2 = EMane.GetComponent<EventManager>().L2_Rigid;
        posx = GetComponent<RectTransform>().localPosition.x;
        posy = GetComponent<RectTransform>().localPosition.y;
    }


    void FixedUpdate()
    {
        if(posx < 0)
        {
            Vector2 Move = new Vector2(0, -FallSpeed);
            rb.velocity = Move;
        }
        else if(posx >0)
        {
            Vector2 Move = new Vector2(0, FallSpeed);
            rb.velocity = Move;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player1 || collision.gameObject == Player2)
        {
            GameObject Player = collision.gameObject;
            PlayerManager = Player.GetComponent<Player_Manager_R>();

            //体力回復
            PlayerManager.m_Player_HP += HeelPoint;
            Debug.Log(PlayerManager.m_Player_HP + "Heel");

            //オーバーしたら
            if (PlayerManager.m_Player_HP > PlayerManager.m_Player_MAXHP)
            {
                PlayerManager.m_Player_HP = PlayerManager.m_Player_MAXHP;
            }
            Debug.Log("体力は" + PlayerManager.m_Player_HP);
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "BackStage")
        {
            Destroy(this.gameObject);
        }
    }
}
