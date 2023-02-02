using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world_generator : MonoBehaviour
{
    public float min_spawn_dist,
                 max_spawn_dist;
    public Transform objects_parent;
    public List<GameObject> objects = new List<GameObject>();

    public int kol = 1;
    public bool generate_object()
    {
        Vector3 pos = random_in_circle(min_spawn_dist,max_spawn_dist);
        pos.z = 1;
        GameObject obj = objects[Random.Range(0, objects.Count)];
        float radius = obj.GetComponent<object_controller>().radius;
        if (Physics2D.OverlapCircle(pos, radius) != null) return false;
        Instantiate(obj,pos,Quaternion.Euler(0,0,Random.Range(0,360)),objects_parent);
        return true;
    }

    void Start()
    {
        generate_world();
    }
    Vector2 random_in_circle(float min_radius, float radius)
    {
        min_radius *= min_radius;
        radius *= radius;
        float angle = Random.Range(0f, 360f);
        float rad = Random.Range(min_radius, radius);
        rad = Mathf.Sqrt(rad);

        return Quaternion.Euler(0, 0, angle) * (Vector2.up * rad);
    }

    void generate_world()
    {
        for (int i = 0;i<kol;i++)
        {
            generate_object();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}