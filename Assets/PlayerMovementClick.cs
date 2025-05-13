using UnityEngine;
using Unity.Behavior;

public class PlayerMovementClick : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; // Layer mask for ground detection
    [SerializeField] private float maxClickDistance = 100f; // Maximum raycast distance
    [SerializeField] private PlayerClick clickEvent; // Reference to your behavior event

    // GameObject to hold our target transform
    [SerializeField] private GameObject targetMarker;

    private Camera mainCamera;
    private Transform targetTransform; // The clicked position as a transform
    private bool hasTarget = false; // Whether we have a valid target position

    [SerializeField] private BehaviorGraphAgent m_Agent;

    private PlayerClick m_playerClickEvent;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Make sure your camera is tagged as 'MainCamera'.");
        }

        // Create target marker if not assigned
        if (targetMarker == null)
        {
            targetMarker = new GameObject("ClickTarget");
            targetMarker.hideFlags = HideFlags.HideInHierarchy; // Optional: hide in hierarchy
        }

        targetTransform = targetMarker.transform;
    }

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    void HandleMouseClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Cast ray to detect ground
        if (Physics.Raycast(ray, out hit, maxClickDistance, groundLayer))
        {
            // Update our transform position
            targetTransform.position = hit.point;
            hasTarget = true;

            // Debug visual - can be removed in production
            Debug.DrawLine(mainCamera.transform.position, hit.point, Color.red, 1.0f);

            // Trigger the click event with the game object and transform
            if (clickEvent != null)
            {
                clickEvent.SendEventMessage(this.gameObject, targetTransform);
            }

            // Log position for debugging
            //Debug.Log($"Ground clicked at: {targetTransform.position}");

            clickEvent.SendEventMessage(m_Agent.gameObject, targetTransform);
        }
    }

    // Public getter for the target transform
    public Transform GetTargetTransform()
    {
        return targetTransform;
    }

    // Check if we have a valid target
    public bool HasTarget()
    {
        return hasTarget;
    }

    // Clear the current target
    public void ClearTarget()
    {
        hasTarget = false;
    }

    // Visualize the target in the Scene view
    private void OnDrawGizmos()
    {
        if (hasTarget && targetTransform != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(targetTransform.position, 0.5f);
        }
    }

    // Clean up
    private void OnDestroy()
    {
        // Destroy the target marker if we created it
        if (targetMarker != null && targetMarker.hideFlags == HideFlags.HideInHierarchy)
        {
            Destroy(targetMarker);
        }
    }
}
