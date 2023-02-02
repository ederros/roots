using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_hider : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();
    bool is_spawn_active = false;
    public bool is_blocked = true;
    public ContactFilter2D filter;
    Vector2 box_pos, box_size;
    public float cost;
    float box_angle;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("spawn"))
            {
                spawners.Add(transform.GetChild(i).gameObject);
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (gameObject.GetComponent<BoxCollider2D>()!=null)
        {
            box_size = gameObject.GetComponent<BoxCollider2D>().size;
            box_pos = transform.position;
            box_angle = transform.rotation.eulerAngles.z;
        }
        
    }
    public void spawners_activation(bool value)
    {
        for (int i = spawners.Count - 1; i >= 0; i--)
        {
            if (spawners[i] == null)
            {
                spawners.RemoveAt(i);
                continue;
            }
            spawners[i].SetActive(value);
        }
        is_spawn_active = value;
    }

    
    void activate()
    {
        is_blocked = false;
        if (gameObject.name.Contains("root"))
        {
            statics.Tree.core.water.max += 1;
            statics.Tree.core.minerals.max += 1;
            statics.Tree.core.nutritions.max += 1;
            List<Collider2D> res = new List<Collider2D>();
            res.AddRange(Physics2D.OverlapBoxAll(box_pos, box_size, box_angle));

            foreach (var r in res)
            {
                if (r.tag.Contains("fluid"))
                {
                    r.gameObject.GetComponent<fluid_controller>().harvest_per_second += 1;
                }
            }
        }
        if (gameObject.name.Contains("water storage"))
        {
            statics.Tree.core.water.max += GetComponent<storage_controller>().capacity;
            statics.Tree.water_storages.Add(GetComponent<storage_controller>());
        }
        if (gameObject.name.Contains("minerals storage"))
        {
            statics.Tree.core.minerals.max += GetComponent<storage_controller>().capacity;
            statics.Tree.minerals_storages.Add(GetComponent<storage_controller>());
        }
        if (gameObject.name.Contains("nutrients storage"))
        {
            statics.Tree.core.nutritions.max += GetComponent<storage_controller>().capacity;
            statics.Tree.nutrients_storages.Add(GetComponent<storage_controller>());
        }
        statics.Tree.show_vals();
    }
    private void OnDestroy()
    {
        if (gameObject.name.Contains("root"))
        {
            
            statics.Tree.core.water.max -= 1;
            statics.Tree.core.minerals.max -= 1;
            statics.Tree.core.nutritions.max -= 1;
            List<Collider2D> res = new List<Collider2D>();
            
            res.AddRange(Physics2D.OverlapBoxAll(box_pos,box_size,box_angle));
            
            foreach (var r in res)
            {
                if (r.tag.Contains("fluid"))
                {
                    r.gameObject.GetComponent<fluid_controller>().harvest_per_second -= 1;
                }
            }
        }
        if (gameObject.name.Contains("water storage"))
        {
            statics.Tree.core.water.max -= GetComponent<storage_controller>().capacity;
            statics.Tree.water_storages.Remove(GetComponent<storage_controller>());
        }
        if (gameObject.name.Contains("minerals storage"))
        {
            statics.Tree.core.minerals.max -= GetComponent<storage_controller>().capacity;
            statics.Tree.minerals_storages.Remove(GetComponent<storage_controller>());
        }
        if (gameObject.name.Contains("nutrients storage"))
        {
            statics.Tree.core.nutritions.max -= GetComponent<storage_controller>().capacity;
            statics.Tree.nutrients_storages.Remove(GetComponent<storage_controller>());
        }
        statics.Tree.show_vals();
        
    }
    private void OnMouseDown()
    {
        if (UI_Listener.isUIOverride) return;
        if (is_blocked) return;
        if (statics.last_root != null) statics.last_root.spawners_activation(false);
        statics.last_root = this;
        spawners_activation(!is_spawn_active);
    }
}
