using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_controller : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void click_to_root()
    {
        scrollbar_controller sc = statics.build_spawn_menu.transform.GetChild(0).GetComponent<scrollbar_controller>();
        sc.target.build_root();
    }
    public void click_to_waterstorage()
    {
        scrollbar_controller sc = statics.build_spawn_menu.transform.GetChild(0).GetComponent<scrollbar_controller>();
        sc.target.build_building(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
