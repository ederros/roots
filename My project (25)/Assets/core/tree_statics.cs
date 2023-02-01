using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class statics
{
    public static tree_statics Tree;
    public static GameObject build_spawn_menu;
    
    public static spawner_hider last_root;
}
public class tree_statics : MonoBehaviour
{
    public core_controller core;
    public List<GameObject> roots_prefab;
    public List<string> root_tags_ignore;
    public List<storage_controller> water_storages = new List<storage_controller>();
    public Text water;
    public List<GameObject> builds;
    public GameObject spawner_prefab;
    public float tick = 0.5f;
    public float delta = 0;

    public void show_vals()
    {
        statics.Tree.core.water.add(0);
        statics.Tree.core.minerals.add(0);
        statics.Tree.core.nutritions.add(0);
    }
    private void Awake()
    {
        statics.Tree = this;
        statics.Tree.core.water.text = water;
    }
    private void Update()
    {
        delta += Time.deltaTime;
        if (delta > tick)
        {
            foreach(var s in water_storages)
            {
                s.stages_update(core.water.cur/ core.water.max);
            }
        }

    }
}
