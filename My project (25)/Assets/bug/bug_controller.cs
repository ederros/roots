using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_controller : MonoBehaviour
{

    public Transform target;
    Vector2 target_pos = Vector2.zero;
    public float min_step = 1,
                 max_step = 2,
                 sight_radius = 1,
                 speed = 1,
                 stop_distance = 0.1f,
                 stay_max_time = 1,
                 stay_min_time = 1,
                 attack_delay = 0.5f,
                 attack_distance = 0.15f,
                 attack_damage = 1f,
                 hp = 5;
                
    
    public LayerMask attack_filter;
    private float delay = 0, stay_time = 0, attack_pause = 0;
    Rigidbody2D rb;


    void Start()
    {
        target_pos = (Vector2)transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    bool move(Vector2 pos)
    {
        if (((Vector2)transform.position - pos).magnitude < stop_distance)
        {
            rb.velocity = Vector2.zero;
            return false;
        }
        rb.velocity = (pos-(Vector2)transform.position).normalized * speed;
        transform.up = pos - (Vector2)transform.position;
        
        return true;
    }

    Vector2 find_target()
    {
        List<Collider2D> colls = new List<Collider2D>();
        colls.AddRange(Physics2D.OverlapCircleAll(transform.position, sight_radius));
        if (target != null) return target.position;
        foreach (var c in colls)
        {
            if (c.tag == "root")
            {
                target = c.transform;
                return c.transform.position;
            }
        }
        target = null;
        return transform.position+(Quaternion.Euler(0,0,Random.Range(0f,360f))* (Vector2.up* Random.Range(0,sight_radius)));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position+ transform.up* attack_distance);
    }
    void ap_quit()
    {
        Application.Quit();
    }
    void attack()
    {
        RaycastHit2D r_hit = Physics2D.Raycast(transform.position, transform.up,attack_distance,attack_filter);
        if (r_hit.collider == null) return;
        target = r_hit.collider.transform;
        if (target.name == "tree")
        {
            if (statics.Tree.core.hp.sub(attack_damage))
            {
                Destroy(statics.Tree.core.gameObject);
                statics.Tree.game_over.SetActive(true);
                Invoke("ap_quit", 5);
                
            }
        }
        else if (target.name.Contains("spine"))
        {
            target.GetComponent<spawner_hider>().hp -= attack_damage;
            if (target.GetComponent<spawner_hider>().hp <= 0) button_controller.destroy(target.gameObject);
            hp = 1;
            Debug.Log("bug hp = " + hp);
            if (hp <= 0) Destroy(this.gameObject);
        }
        else
        {
            target.GetComponent<spawner_hider>().hp-=attack_damage;
            if (target.GetComponent<spawner_hider>().hp <= 0) button_controller.destroy(target.gameObject);
        }
    }

    void Update()
    {
        if (target != null && target_pos != Vector2.zero) target_pos = target.position;
        move(target_pos);
        delay += Time.deltaTime;
        if (stay_time == 0) stay_time = Random.Range(stay_min_time, stay_max_time);
        if (delay>stay_time) {
            target_pos = find_target();
            stay_time = 0;
            delay = 0;
        }
        
        if (target != null)
        {
            attack_pause += Time.deltaTime;
            if (attack_pause>attack_delay)
            {
                attack_pause -= attack_delay;
                attack();
            }
        }
        
    }
}
