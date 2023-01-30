using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI_Listener : MonoBehaviour
{
    static public bool isUIOverride { get; private set; }

    void Update()
    {
        isUIOverride = EventSystem.current.IsPointerOverGameObject();
    }
}

