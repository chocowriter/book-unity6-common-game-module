using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum ItemState
{
    None = 0,
    Usable,
    NotUsable
}

[System.Serializable]
public class ItemModel
{
    public string id;
    public ItemState state;
    public string spriteName;
    public string itemName;
    public int count;
    public Sprite sprite;
    public bool isStackable;

    public ItemModel(string id, ItemState state, string spriteName, string itemName, int count, Sprite sprite, bool isStackable)
    {
        this.id = id;
        this.state = state;
        this.spriteName = spriteName;
        this.itemName = itemName;
        this.count = count;
        this.sprite = sprite;
        this.isStackable = isStackable;
    }
}


/// <summary>
/// Controller 역할
/// </summary>
public class ItemSlot : MonoBehaviour
{
    public string idSlot;
    public string idModel;
    public ItemModel model;

    public Image itemImage;
    public Sprite itemSprite;

    private void Awake()
    {
        itemImage = GetComponent<Image>();

        Init();
    }

    void Init()
    {
        model = ItemsContainer.Instance.dicItems[idModel];
        
        idSlot = "0";
        idModel = model.id;

        itemImage.sprite = model.sprite;
        itemImage.SetNativeSize();

        itemSprite = model.sprite;
    }
}