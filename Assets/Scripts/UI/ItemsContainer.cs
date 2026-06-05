using UnityEngine;
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;

public class ItemsContainer : Singleton<ItemsContainer>
{
    public SerializedDictionary<string, ItemModel> dicItems = new SerializedDictionary<string, ItemModel>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);


    }
}
