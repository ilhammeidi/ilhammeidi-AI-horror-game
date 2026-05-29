using System;
using UnityEngine; 
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GameInputAction;

public class InputManager : MonoBehaviour, IPlayerActions
{
    private GameInputAction _inputAction;
    public UnityEvent<Vector2> OnMoveInput; 
    public UnityEvent<bool> OnSprintInput; 
    public UnityEvent OnInteractInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveInput?.Invoke(context.ReadValue<Vector2>()); 
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interaksi"); 
        if (context.performed)
        {
            // Jika input ditekan maka trigger event OnInteractInput
            OnInteractInput?.Invoke();
        }
    }
    
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed) 
        { 
            OnSprintInput?.Invoke(true); 
        } 
        // Mengecek apakah input dilepas 
        if (context.canceled) 
        { 
            OnSprintInput?.Invoke(false); 
        } 
    }
    

    private void Awake()
    {
        _inputAction = new GameInputAction();
        _inputAction.Enable();
        _inputAction.Player.Enable();
        _inputAction.Player.SetCallbacks(this); 
    }

    private void OnDisable()
    {
        _inputAction.Player.Disable();
        _inputAction.Disable();
    }

    private void OnDestroy()
    {
        _inputAction.Player.SetCallbacks(null);
        _inputAction.Dispose();
    }
} 