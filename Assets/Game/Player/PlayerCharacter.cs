using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _movement;

    [SerializeField]
    private PlayerStamina _stamina;

    [SerializeField]
    private InventoryManager _inventory;

    [SerializeField]
    private InteractDetector _interactDetector;
    public InteractDetector InteractDetector => _interactDetector;

    public PlayerMovement Movement => _movement;
    public PlayerStamina Stamina => _stamina;
    public InventoryManager Inventory => _inventory;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
