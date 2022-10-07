using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject effectObject_chara1;
    [SerializeField]
    private GameObject effectObject_chara2;
    public GameObject chara;
    void Start()
    {
        if (chara.GetComponent<Player_Manager_L>().Character == 1 || chara.GetComponent<Player_Manager_L>().Character == 3)
        {
            effectObject_chara1 = GameObject.Instantiate(effectObject_chara1, transform.position + new Vector3(0f, 0f, -1f), Quaternion.identity) as GameObject;
            effectObject_chara1.transform.parent = transform;
        }
        else if (chara.GetComponent<Player_Manager_L>().Character == 2 || chara.GetComponent<Player_Manager_L>().Character == 4)
        {
            effectObject_chara2 = GameObject.Instantiate(effectObject_chara2, transform.position + new Vector3(-0.05f, 0f, -1f), Quaternion.identity) as GameObject;
            effectObject_chara2.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
