using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    public UnityEvent OnDoorOpen;
    public UnityEvent OnDoorClose;

    protected Coroutine _animatingDoorCoroutine;

    [SerializeField]
    private string _name;
    public string Name => _name;

    [SerializeField]
    protected Transform _doorTransform;

    [SerializeField]
    protected float _duration = 1f;

    [SerializeField]
    protected bool _isLocked;
    
    protected bool _isAnimating;
    public bool IsAnimating => _isAnimating;

    protected bool _isOpen;

    [ContextMenu("Interact Door")]
    public void Interact(PlayerCharacter character)
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
