using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluid_controller : MonoBehaviour
{
    public float resources = 100;
    public float harvest_per_second = 0;
    public float tick = 0.5f;
    public fluid_type type;
    public enum fluid_type
    {
        water,

    }
    float delta = 0;
    value res;
    void Start()
    {
        switch (type)
        {
            case fluid_type.water:
                res = statics.Tree.core.water;
                break;
            default:
                Debug.LogError("unknown type using");
                break;
        }
    }

    void Update()
    {
        if (harvest_per_second <= 0) return;
        float cur_harvest = harvest_per_second * tick;
        delta += Time.deltaTime;
        if (delta >= tick)
        {
            delta = tick - delta;
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
        }
    }
}
