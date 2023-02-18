using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_controller : MonoBehaviour
{
    public float radius;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position,radius);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
