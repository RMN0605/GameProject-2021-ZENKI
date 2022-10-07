using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float ScaleMax;

    [SerializeField]
    private float ScaleLeast;

    [SerializeField]
    private float ChangeSpeed;

    Vector3 E_Scale;
    Vector3 ChangeScale;
    bool ScaleSwitch;

    void Start()
    {
        E_Scale = transform.localScale;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        rectTransform.position += new Vector3(0f, 0f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(E_Scale.x >= ScaleMax)
        {
            ScaleSwitch = true;
        }
        else if(E_Scale.x <= ScaleLeast)
        {
            ScaleSwitch = false;
        }
        
        if(ScaleSwitch == true)
        {
            E_Scale.x = E_Scale.y = E_Scale.z -= ChangeSpeed;
            gameObject.transform.localScale = E_Scale;
            //Debug.Log("¬‚³‚­‚µ‚Ä‚é");
        }
        else
        {
            E_Scale.x = E_Scale.y = E_Scale.z += ChangeSpeed;
            gameObject.transform.localScale = E_Scale;
            //Debug.Log("‘å‚«‚­‚µ‚Ä‚é");
        }
    }
}
