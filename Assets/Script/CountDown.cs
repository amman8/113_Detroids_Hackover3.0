using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CountDown : MonoBehaviour
{
    public float countdown = 30f;
    public float curenttime=1f;

    [SerializeField] TextMeshProUGUI CountDownText;
    void Start()
    {
        curenttime = countdown;
    }

    
    void Update()
    {
        if(curenttime >0)
        {
            curenttime -= 1 * Time.deltaTime;
            CountDownText.text = curenttime.ToString("0");
            
            if (curenttime < 10)
            {
                //Debug.Log("ChangeColor");
                CountDownText.color = new Color(255, 0, 0);
                //Debug.Log(curenttime);
            }
            if (curenttime > 10)
            {
                CountDownText.color = new Color(0,255, 0);
            }
        }
        
    }
}
