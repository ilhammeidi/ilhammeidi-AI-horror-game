using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _movement;

    [SerializeField]
    private PlayerStamina _stamina;

    [SerializeField]
    private InventoryManager _inventory;

    public PlayerMovement Movement => _movement;
    public PlayerStamina Stamina => _stamina;
    public InventoryManager Inventory => _inventory;

}
