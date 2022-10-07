using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_efect_object : MonoBehaviour
{
    float time = 0;
    void Update()
    {
        time += Time.deltaTime;
        if( time >= 3)
        {
            Destroy(this.gameObject);
        }

    }
}
