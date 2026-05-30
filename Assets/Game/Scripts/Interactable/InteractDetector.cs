using UnityEngine;

public class InteractDetector : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacter _owner;

    [SerializeField]
    private float _detectorDistance;

    [SerializeField]
    private Vector3 _detectorBoxSize = new Vector3(1.0f, 1.0f, 1.0f);

    [SerializeField]
    private LayerMask _interactableLayer;

    private IInteractable _detectedInteractable;
    
    private bool _isInteracting;

    public bool Enabled { get; private set; } = true;

    /// <summary>
    /// Draw Detector
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        // Mendapatkan reference ke component transform camera
        Transform cameraTransform = Camera.main.transform;

        if (Enabled == true)
        {
            bool isDetectingInteractable = Physics.BoxCast(
                cameraTransform.position,
                _detectorBoxSize * 0.5f,
                cameraTransform.forward,
                out RaycastHit hit,
                Quaternion.identity,                                            
                _detectorDistance,
                _interactableLayer
            );

            if (isDetectingInteractable)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(cameraTransform.position, cameraTransform.position + cameraTransform.forward * hit.distance);

                Gizmos.DrawWireCube(cameraTransform.position + cameraTransform.forward * hit.distance, _detectorBoxSize);
            }
            else
            {
                Gizmos.DrawLine(cameraTransform.position, cameraTransform.position + cameraTransform.forward * _detectorDistance);
                Gizmos.DrawWireCube(cameraTransform.position + cameraTransform.forward * _detectorDistance, _detectorBoxSize);
            }
        }
    }

    /// <summary>
    /// Input Manager
    /// </summary>
    public void Interact()
    {
        if (_detectedInteractable != null && Enabled == true)
        {
            _detectedInteractable.Interact(_owner);
            _detectedInteractable = null;
            
            _isInteracting = true;
        }
    }

    /// SET ENABLE MOVEMENT
    public void SetEnabled(bool isEnabled)
    {
        Enabled = isEnabled;
    }

    /// <summary>
    /// Find Object to Detect
    /// </summary>
    private void UpdateDetection()
    {
        if (_isInteracting)
        {
            _isInteracting = false;
            return;
        }

        if (Enabled == true)
        {
            Transform cameraTransform = Camera.main.transform;

            bool isDetectingInteractable = Physics.BoxCast(
                cameraTransform.position,
                _detectorBoxSize * 0.5f,
                cameraTransform.forward,
                out RaycastHit hit,
                Quaternion.identity,
                _detectorDistance,
                _interactableLayer
            );

            if (isDetectingInteractable)
            {
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    _detectedInteractable = interactable;
                }
            }
        }
    }

    private void Update()
    {
        UpdateDetection();
    }
}
