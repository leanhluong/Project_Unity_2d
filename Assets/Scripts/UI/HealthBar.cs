using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueTxt;


    public void UpdateBar(int curValue, int maxValue)
    {
        fillBar.fillAmount = (float)curValue/(float) maxValue;
        valueTxt.text = curValue.ToString() + "/" + maxValue.ToString();    
    }
}
