using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class statics
{
    public static tree_statics Tree;
    public static GameObject build_spawn_menu;
    public static spawner_hider last_root;
}

public class tree_statics : MonoBehaviour
{
    public List<GameObject> roots_prefab;
    public List<GameObject> builds;
    public GameObject spawner_prefab;
    private void Awake()
    {
        statics.Tree = this;
    }
}
