using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public float minSize = 4,
                 maxSize = 10,
                 wheelSpeed = 5,
                 camMoveSpeed = 5;
    private void Update()
    {
        move();   
    }

    void move()
    {
        if (Input.GetMouseButton(2))
        {
            transform.position += new Vector3(-Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"))*Time.deltaTime*50;
        }
        Camera.main.orthographicSize -= Input.mouseScrollDelta.y* Camera.main.orthographicSize * Time.deltaTime*wheelSpeed;
        if (Camera.main.orthographicSize < minSize) Camera.main.orthographicSize = minSize;
        if (Camera.main.orthographicSize > maxSize) Camera.main.orthographicSize = maxSize;
        Vector2 XY_move = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        transform.position += (Vector3)XY_move * Time.deltaTime* camMoveSpeed;
    }
}
