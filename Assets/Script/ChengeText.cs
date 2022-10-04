using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChengeText : MonoBehaviour
{

    public TextMesh ChangeSpeedUI;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        ChangeSpeedUI.text = "5";
    }
}
