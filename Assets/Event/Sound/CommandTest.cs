using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CommandTest : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //ˆ—‚ğ‘‚­
                    Debug.Log(code);
                    break;
                }
            }
        }
    }
}
