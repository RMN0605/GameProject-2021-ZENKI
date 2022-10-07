using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WINLOSE : MonoBehaviour
{
    GameObject System;

    public Image image1;
    public Image image2;
    public  Sprite sprite1;
    public Sprite sprite2;
    void Start()
    {
        System = GameObject.Find("Game_Setting");
    }

    // Update is called once per frame
    void Update()
    {
        if (System.GetComponent<Setting>().syouhai && System.GetComponent<Setting>().check)
        {
            if (System.GetComponent<Setting>().WINER)
            {
                image1.sprite = sprite1;
                image2.sprite = sprite2;
            }
            else if (!System.GetComponent<Setting>().WINER)
            {
                image1.sprite = sprite2;
                image2.sprite = sprite1;
            }
        }
    }
}
