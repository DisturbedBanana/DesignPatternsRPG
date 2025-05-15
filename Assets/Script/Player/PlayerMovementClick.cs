using UnityEngine;
using Unity.Behavior;

public class PlayerMovementClick : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxClickDistance = 100f;
    [SerializeField] private PlayerClick clickEvent;
    //[SerializeField] private BehaviorGraphAgent m_Agent;
    
    [SerializeField] private GameObject targetMarker;

    private Camera mainCamera;
    private Transform targetTransform; 
    private bool hasTarget = false; 


    void Start()
    {
        mainCamera = Camera.main;

        if (targetMarker == null)
        {
            targetMarker = new GameObject("ClickTarget");
            targetMarker.hideFlags = HideFlags.HideInHierarchy; 
        }

        targetTransform = targetMarker.transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    void HandleMouseClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxClickDistance, groundLayer))
        {
            targetTransform.position = hit.point;
            hasTarget = true;
            
            if (clickEvent != null)
            {
                clickEvent.SendEventMessage(this.gameObject, targetTransform);
            }
        }
    }

    private void OnDestroy()
    {
        // Destroy the target marker if we created it
        if (targetMarker != null && targetMarker.hideFlags == HideFlags.HideInHierarchy)
        {
            Destroy(targetMarker);
        }
    }
}
