using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class statics
{
    public static tree_statics Tree;
    public static spawner_hider last_root;
   
}
public class tree_statics : MonoBehaviour
{
    public world_generator generator;
    public GameObject build_spawn_menu;
    public GameObject build_action_menu;
    public core_controller core;
    public List<GameObject> roots_prefab;
    public List<string> root_tags_ignore;
    public List<storage_controller> water_storages = new List<storage_controller>();
    public List<storage_controller> minerals_storages = new List<storage_controller>();
    public List<storage_controller> nutrients_storages = new List<storage_controller>();
    public Text water;
    public Text minerals;
    public Text nutritions;
    public Text hp;
    public Slider bar_water;
    public Slider bar_minerals;
    public Slider bar_nutritions;
    public Slider bar_hp;
    public List<GameObject> builds;
    public GameObject spawner_prefab;
    public float build_time;
    public Animator build_anim;
    public float tick = 0.5f;
    public float water_consume = 0.1f;//water per second
    public float water_consume_per_root = 0.01f;
    float delta = 0;
    public GameObject game_over;

    public void show_vals()
    {
        statics.Tree.core.water.add(0);
        statics.Tree.core.minerals.add(0);
        statics.Tree.core.nutritions.add(0);
        statics.Tree.core.hp.add(0);
    }
    private void Awake()
    {
        //build_anim.speed = 1 / build_time;
        statics.Tree = this;
        statics.Tree.core.water.text = water;
        statics.Tree.core.minerals.text = minerals;
        statics.Tree.core.nutritions.text = nutritions;
        statics.Tree.core.hp.text = hp;
        statics.Tree.core.water.bar = bar_water;
        statics.Tree.core.minerals.bar = bar_minerals;
        statics.Tree.core.nutritions.bar = bar_nutritions;
        statics.Tree.core.hp.bar = bar_hp;
        show_vals();
    }
    void ap_quit()
    {
        Application.Quit();
    }
    public void tree_destroy()
    {
        Destroy(core.gameObject);
        game_over.SetActive(true);
        Invoke("ap_quit", 5);
    }
    private void Update()
    {
        delta += Time.deltaTime;
        if (delta > tick)
        {
            if (core.water.sub(water_consume * tick))
            {
                tree_destroy();
            }
            core.nutritions.add(water_consume * tick * 0.5f);
            foreach (var s in water_storages)
            {
                s.stages_update(core.water.cur/ core.water.max);
            }
            foreach (var s in minerals_storages)
            {
                s.stages_update(core.minerals.cur / core.minerals.max);
            }
            foreach (var s in nutrients_storages)
            {
                s.stages_update(core.nutritions.cur / core.nutritions.max);
            }
            delta -= tick;
        }
    }
}
