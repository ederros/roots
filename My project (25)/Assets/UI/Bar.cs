using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Bar : MonoBehaviour
{
    public TMP_Text m_TextComponent;
    public Slider slider;
    public int Water;
    public int MaxWater;
    private void Awake(){
      SetBar(50,100);
    }
    public void SetBar(int X,int max)
    {
        Water=X;
        MaxWater=max;
        slider.maxValue=MaxWater;
        slider.value = Water;
        m_TextComponent.text = X.ToString()+"/"+max.ToString();
        m_TextComponent.ForceMeshUpdate(true);
    }
}
