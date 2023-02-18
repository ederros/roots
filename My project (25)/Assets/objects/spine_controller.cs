using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spine_controller : MonoBehaviour
{
    float attack_delay = 1;
    float pause=0;
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        pause += Time.deltaTime;
        if (collision.name.Contains("bug")&&pause>=attack_delay)
        {
            pause -= attack_delay;
            collision.GetComponent<bug_controller>().get_damage(1);
            Debug.Log(collision.GetComponent<bug_controller>());
            if (collision.GetComponent<bug_controller>().hp <= 0) Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
