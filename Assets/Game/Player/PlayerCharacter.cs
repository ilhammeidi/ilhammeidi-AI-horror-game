using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _movement;
    public PlayerMovement Movement => _movement;

    [SerializeField]
    private PlayerStamina _stamina;
    public PlayerStamina Stamina => _stamina;

    [SerializeField]
    private InventoryManager _inventory;
    public InventoryManager Inventory => _inventory;

    [SerializeField]
    private InteractDetector _interactDetector;
    public InteractDetector InteractDetector => _interactDetector;

    [SerializeField]
    private CameraManager _camera;
    public CameraManager Camera => _camera;

    [SerializeField]
    private InputManager _input;
    public InputManager Input => _input;

    public bool IsHiding { get; private set; }
    public void SetIsHiding(bool isHiding)
    {
        IsHiding = isHiding;
    }

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
