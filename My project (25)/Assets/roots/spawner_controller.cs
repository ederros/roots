using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spawner_controller : MonoBehaviour
{
    public Transform parent;
    public GameObject build_building(int index, int order_add)
    {
        GameObject new_Root = statics.Tree.builds[index];
        new_Root.transform.position = (Vector2)transform.position;
        new_Root.transform.Find("body").GetComponent<SpriteRenderer>().sortingOrder = transform.parent.Find("body").GetComponent<SpriteRenderer>().sortingOrder + order_add;
        if (Random.value > 0.5) new_Root.transform.localScale = new Vector3(-new_Root.transform.localScale.x, new_Root.transform.localScale.y, new_Root.transform.localScale.z);
        new_Root.transform.localRotation = transform.localRotation;
        statics.Tree.build_spawn_menu.SetActive(false);
        //Destroy(gameObject);
        return new_Root;
    }
    public GameObject build_root()
    {
        
        RaycastHit2D[] r_hit = Physics2D.RaycastAll(transform.position, transform.up, 1.5f);
       
        foreach (var hit in r_hit)
        {
            bool is_ignore = false;
            foreach (string s in statics.Tree.root_tags_ignore)
            {
                if (hit.collider.tag == s)
                {
                    is_ignore = true;
                    break;
                }
            }
            if (is_ignore) continue;
            if (hit.collider.gameObject == transform.gameObject) continue;
            if (hit.collider.gameObject == transform.parent.gameObject) continue;
            if (transform.parent.parent != null && hit.collider.gameObject == transform.parent.parent.gameObject) continue;
            return null;
        }
        GameObject new_Root = statics.Tree.roots_prefab[Random.Range(0,statics.Tree.roots_prefab.Count)];
        new_Root.transform.position = (Vector2)transform.position;
        new_Root.transform.Find("body").GetComponent<SpriteRenderer>().sortingOrder = transform.parent.Find("body").GetComponent<SpriteRenderer>().sortingOrder-1;
        if (Random.value > 0.5) new_Root.transform.localScale = new Vector3(-new_Root.transform.localScale.x, new_Root.transform.localScale.y, new_Root.transform.localScale.z);
        new_Root.transform.localRotation = transform.localRotation;
        transform.parent.GetComponent<root_controller>();
        statics.Tree.build_spawn_menu.SetActive(false);

        //Destroy(gameObject);
        return new_Root;
    }
    private void Awake()
    {
        parent = transform.parent;
    }

    
    
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (UI_Listener.isUIOverride) return;
        //statics.Tree.build_spawn_menu.transform.position = Input.mousePosition;
        statics.Tree.build_spawn_menu.transform.GetChild(0).GetComponent<scrollbar_controller>().target = this;
        statics.Tree.build_spawn_menu.SetActive(true);
        statics.Tree.build_action_menu.SetActive(false);
    }
}
