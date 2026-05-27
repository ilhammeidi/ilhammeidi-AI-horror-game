using UnityEngine;

public class Item : MonoBehaviour, IInteractable, IPickable
{
    [SerializeField]
    private ItemData _itemData;

    public string Name => _itemData.Name;

    public void Interact()
    {
        // Ketika interact dengan item, item akan diambil
        Pickup();
    }

    public void Pickup()
    {
        // Membuat kode program ketika item diambil
    }
}
