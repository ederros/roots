using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluid_controller : MonoBehaviour
{
    public float resources = 100;
    float max_res;
    public float harvest_per_second = 0;
    public fluid_type type;
    Color clr;
    public enum fluid_type
    {
        water,
        minerals,
        nutriens,
    }
    float delta = 0;
    value res;
    void Start()
    {
        clr = transform.Find("body").GetComponent<SpriteRenderer>().color;
        max_res = resources;
        switch (type)
        {
            case fluid_type.water:
                res = statics.Tree.core.water;
                break;
            case fluid_type.minerals:
                res = statics.Tree.core.minerals;
                break;
            case fluid_type.nutriens:
                res = statics.Tree.core.nutritions;
                break;

            default:
                Debug.LogError("unknown type using");
                break;
        }
    }

    void Update()
    {
        if (harvest_per_second <= 0) return;
        float cur_harvest = harvest_per_second * statics.Tree.tick;
        delta += Time.deltaTime;
        if (delta >= statics.Tree.tick)
        {
            delta = statics.Tree.tick - delta;
            if (resources < cur_harvest) cur_harvest = resources;
            resources -= cur_harvest;
            float har_val = res.add(cur_harvest);
            if (har_val < 0)
            {
                resources -= har_val;
            }

            if (resources == 0)
            {
                Destroy(gameObject);
            }
            transform.Find("body").GetComponent<SpriteRenderer>().color = new Color(clr.r,clr.g,clr.b,resources/max_res);
        }
    }
}
