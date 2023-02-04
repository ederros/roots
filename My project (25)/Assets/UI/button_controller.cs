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
        scrollbar_controller sc = statics.Tree.build_spawn_menu.transform.GetChild(0).GetComponent<scrollbar_controller>();
        GameObject temp = sc.target.build_root();
        before_build(temp, sc);
        
    }

    bool buy_building(spawner_hider rc)
    {
        if (rc.cost > statics.Tree.core.nutritions.cur) return false;
        statics.Tree.core.nutritions.sub(rc.cost);
        return true;
    }

    public bool before_build(GameObject targ, scrollbar_controller sc){
        if (targ == null) return false;
        if (!buy_building(targ.GetComponent<spawner_hider>())) return false;

        Instantiate(targ, sc.target.parent).transform.position = new Vector3(sc.target.transform.position.x, sc.target.transform.position.y, sc.target.transform.parent.position.z);
        Destroy(sc.target.gameObject);
        return true;
    }
    public bool build_building(int build_id)
    {
        scrollbar_controller sc = statics.Tree.build_spawn_menu.transform.GetChild(0).GetComponent<scrollbar_controller>();
        GameObject temp = sc.target.build_building(build_id, build_id == 1 ? -1 : 1);
        if (!before_build(temp, sc)) return false;
        return true;
    }
    public void click_to_waterstorage()
    {
        build_building(0);
    }
    public void click_to_mineralsstorage()
    {
        build_building(1);
    }
    public void click_to_nutrientstorage()
    {
        build_building(2);
    }
    public void click_to_spine()
    {
        build_building(3);
    }
    public static void destroy(GameObject target)
    {
        
        GameObject G_obj = Instantiate(statics.Tree.spawner_prefab, target.transform.parent);
        G_obj.transform.position = target.transform.position;
        G_obj.transform.rotation = target.transform.rotation;
        target.transform.parent.GetComponent<spawner_hider>().spawners.Add(G_obj);
        G_obj.SetActive(false);
        statics.Tree.build_action_menu.SetActive(false);
        Destroy(target);
    }
    public void click_to_destroy()
    {
        scrollbar_controller sc = statics.Tree.build_action_menu.transform.GetChild(0).GetComponent<scrollbar_controller>();
        destroy(sc.gameobj_target);
    }
    // Update is called once per frame
    void Update()
    {
        scrollbar_controller sc = statics.Tree.build_action_menu.transform.GetChild(0).GetComponent<scrollbar_controller>();
    }
}
