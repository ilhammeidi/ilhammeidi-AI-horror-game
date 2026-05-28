using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<ItemData> _item = new List<ItemData>();
    public List<ItemData> Items => _item;

    public void AddItems(ItemData item)
    {
        Items.Add(item);
    }

    public void RemoveItem(ItemData item)
    {
        Items.Remove(item);
    }

    public bool CheckItem(string id)
    {
        bool isExsists = Items.Exists(itemData => string.Equals(itemData.ID, id));
        return isExsists;
    }
}
