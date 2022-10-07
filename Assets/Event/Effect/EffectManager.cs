using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("エフェクトを表示する順に入れる")]
    [SerializeField]
    private List<GameObject> EffectList;

    [Header("各エフェクトを切り替えるまでの時間")]
    [SerializeField]
    private List<float> EffectTime;

    [Header("各effectの大きさ")]
    [SerializeField]
    private List<float> EffectSize;

    private float CountTime = 0;
    private bool EffectUp = false;
    private int E_No = 0;
    private GameObject BuckEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EffectUp == false)
        {
            //エフェクトを表示
            BuckEffect = Instantiate(EffectList[E_No]);
            Vector3 EffectScale;
            EffectScale.x = EffectScale.y = EffectScale.z = EffectSize[E_No];
            BuckEffect.transform.localScale = EffectScale;

            EffectUp = true;
            //Debug.Log(E_No);
        }

        //エフェクトを切り替えるまでのカウント
        CountTime += Time.deltaTime;

        if(CountTime >= EffectTime[E_No])
        {
            //表示中のエフェクトを消す
            Destroy(BuckEffect);

            //次のエフェクトに切り替える
            if(E_No == 4)
            {
                E_No = 0;
            }
            else
            {
                E_No += 1;
            }

            CountTime = 0;
            EffectUp = false;
        }
    }
}
