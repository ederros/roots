using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storage_controller : MonoBehaviour
{
    public List<Sprite> stages;
    public float capacity;
    void Start()
    {
        
    }
    public void stages_update(float val) 
    {
        SpriteRenderer spr = transform.Find("body").GetComponent<SpriteRenderer>();
        spr.sprite = stages[Mathf.RoundToInt(val*(stages.Count-1))];
    }


    void Update()
    {
        
    }
}
