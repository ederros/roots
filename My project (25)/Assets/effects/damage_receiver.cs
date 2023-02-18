using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_receiver : MonoBehaviour
{
    public SpriteRenderer target;
    Color natural_color;
    public Color receive_color;
    public float speed = 1;
    void Start()
    {
        if (target == null) target = transform.Find("body").GetComponent<SpriteRenderer>();
        natural_color = target.color;

    }


    public void get_damage()
    {
        target.color = receive_color;
    }
    void Update()
    {
        if (natural_color == receive_color) return;
        target.color = Color.Lerp(target.color,natural_color,Time.deltaTime*speed);
    }
}
