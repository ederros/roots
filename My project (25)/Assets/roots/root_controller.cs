using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root_controller : MonoBehaviour
{
    
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (UI_Listener.isUIOverride) return;
        //statics.Tree.build_action_menu.transform.position = Input.mousePosition;
        statics.Tree.build_action_menu.transform.GetChild(0).GetComponent<scrollbar_controller>().gameobj_target = this.gameObject;
        statics.Tree.build_action_menu.SetActive(true);
        statics.Tree.build_spawn_menu.SetActive(false);
       
    }
}
