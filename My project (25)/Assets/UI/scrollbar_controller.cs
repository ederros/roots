using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollbar_controller : MonoBehaviour
{
    public spawner_controller target;
    private void Awake()
    {
        statics.build_spawn_menu = transform.parent.gameObject;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
