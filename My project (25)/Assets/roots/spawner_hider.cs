using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_hider : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();
    bool is_spawn_active = false;
    public bool is_blocked = true;
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
