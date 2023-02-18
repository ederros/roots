using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_controller : MonoBehaviour
{
    Renderer my_rend;
    float last_scale = 0;
    public void ResizeSpriteToScreen()
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height,1);
        Set_speed(width/ worldScreenWidth, height/ worldScreenHeight);
        Set_scale(worldScreenHeight / height);
    }
    
    public void Set_speed(float speedX, float speedY)
    {
        my_rend.material.SetFloat("_SpeedX", speedX);
        my_rend.material.SetFloat("_SpeedY", speedY);
    }
    public void Set_scale(float scale)
    {
        
        my_rend.material.SetFloat("_Scale", scale);
        //my_rend.material.mainTextureOffset -= Vector2.one *delta_scale /scale/2;
    }
    void Awake()
    {
        my_rend = GetComponent<SpriteRenderer>();
        ResizeSpriteToScreen();
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
