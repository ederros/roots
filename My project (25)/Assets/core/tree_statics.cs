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
    public Text water;
    public List<GameObject> builds;
    public GameObject spawner_prefab;
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
}
