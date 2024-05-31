using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ItemManager itemManager;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.GameObject());
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.GameObject());

        itemManager = GetComponent<ItemManager>();
    }
}
