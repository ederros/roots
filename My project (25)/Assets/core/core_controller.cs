using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class value
{
    public float max, cur;
    public Slider bar;
    public Text text;
    public float add(float val)
    {
        float ret = max - cur - val;
        cur += val;
        if (cur > max) cur = max;
        show_ui();
        return ret;
        
    }

    void show_ui()
    {
        if (bar != null) bar.value = cur / max;
        if (text != null) text.text = Mathf.Round(cur*100)/100f+ "/" + max;
    }
    public bool sub(float val)
    {
        cur -= val;
        if (cur <= 0) cur = 0;
        show_ui();
        if (cur == 0) return true;
        return false;
    }
    public value(float cur, float max)
    {
        this.max = max;
        this.cur = cur;
    }
}

public class core_controller : MonoBehaviour
{
    public value hp = new value(100,100);
    public value water = new value(100, 100);
    public value nutritions = new value(50, 100);
    public value minerals = new value(30, 100);
    private void Awake()
    {
    }
    void Start()
    {

    }

    
    void Update()
    {
       
        
    }
}
