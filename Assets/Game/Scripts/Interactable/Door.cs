using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string _name;

    public string Name => _name;

    public void Interact()
    {
        // Membuka atau menutup pintu
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
