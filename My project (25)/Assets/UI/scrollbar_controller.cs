using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollbar_controller : MonoBehaviour
{
    public spawner_controller target;
    public GameObject gameobj_target;
    private void Awake()
    {

    }
    void Start()
    {
        
    }
    public void hide_menu()
    {
        transform.parent.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
