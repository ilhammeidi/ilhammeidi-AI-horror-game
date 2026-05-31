using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    public UnityEvent OnDoorOpen;
    public UnityEvent OnDoorClose;

    protected Coroutine _animatingDoorCoroutine;

    [SerializeField]
    private string _name;

    [SerializeField]
    private string _keyID;
    public string Id => _keyID;

    [SerializeField]
    protected Transform _doorTransform;

    [SerializeField]
    protected float _duration = 1f;

    [SerializeField]
    protected bool _isLocked;
    
    protected bool _isAnimating;
    public bool IsAnimating => _isAnimating;

    protected bool _isOpen;

    /// <summary>
    /// ACCESS INTERFACE
    /// </summary>
    public string Name => _name;

    [ContextMenu("Interact Door")]
    public void Interact(PlayerCharacter character)
    {
        if (_isLocked == true)
        {
            bool hasKey = character.Inventory.CheckItem(_keyID);
            if (hasKey == true)
            {
                _isLocked = false;
                Open();
            }
        }
        else
        {
            if (_isOpen == true)
            {
                // Jika pintu terbuka maka tutup pintu
                Close();
            }
            else
            {
                // Jika pintu tertutup maka buka pintu
                Open();
            }
        }
    }

    public virtual void Open()
    {
        _isOpen = true;
        OnDoorOpen?.Invoke();
    }

    public virtual void Close()
    {
        _isOpen = false;
        OnDoorClose?.Invoke();
    }
}
