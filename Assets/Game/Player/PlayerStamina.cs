using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] 
    private float _maxStamina = 100; 

    [SerializeField] 
    private float _sprintStaminaCost = 20; 

    [SerializeField] 
    private float _staminaRegenValue = 20;

    [SerializeField] 
    private PlayerMovement _characterMovement; 

    private float _currentStamina; 

    public void CalculateStamina() 
    { 
        if (_characterMovement.IsSprint) 
        { 
            if (_currentStamina > 0) 
            { 
                // Reduce Stamina
                _currentStamina = _currentStamina - _sprintStaminaCost * Time.deltaTime; 
            } 
            else 
            { 
                // Stamina Runnng Out and Stop Sprint
                _characterMovement.SetSprint(false); 
            } 
        } 
        else 
        { 
            // Gained Stamina
            _currentStamina = _currentStamina + _staminaRegenValue * Time.deltaTime; 
        } 
        _currentStamina = Mathf.Clamp(_currentStamina, 0, _maxStamina); 
    } 

    void Awake()
    {
        _currentStamina = _maxStamina;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateStamina(); 
    }
}
