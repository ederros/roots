using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hower_OverScale : MonoBehaviour
{
    public float overscale = 1.2f;
    Vector3 standart_scale = Vector3.one;
    void Start()
    {
        standart_scale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        transform.localScale = standart_scale * overscale;
    }
    private void OnMouseExit()
    {
        transform.localScale = standart_scale;
    }
}
