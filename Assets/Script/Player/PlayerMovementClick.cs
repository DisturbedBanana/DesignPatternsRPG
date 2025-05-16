using UnityEngine;
using Unity.Behavior;
using UnityEngine.Serialization;

public class PlayerMovementClick : MonoBehaviour
{
    [FormerlySerializedAs("groundLayer")] [SerializeField] private LayerMask _groundLayer;
    [FormerlySerializedAs("maxClickDistance")] [SerializeField] private float _maxClickDistance = 100f;
    [FormerlySerializedAs("clickEvent")] [SerializeField] private PlayerClick _clickEvent;
    
    [FormerlySerializedAs("targetMarker")] [SerializeField] private GameObject _targetMarker;

    private Camera _mainCamera;
    private Transform _targetTransform; 
    private bool _hasTarget = false; 


    void Start()
    {
        _mainCamera = Camera.main;

        if (_targetMarker == null)
        {
            _targetMarker = new GameObject("ClickTarget");
            _targetMarker.hideFlags = HideFlags.HideInHierarchy; 
        }

        _targetTransform = _targetMarker.transform;
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
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, _maxClickDistance, _groundLayer))
        {
            _targetTransform.position = hit.point;
            _hasTarget = true;
            
            if (_clickEvent != null)
            {
                _clickEvent.SendEventMessage(this.gameObject, _targetTransform);
            }
        }
    }

    private void OnDestroy()
    {
        // Destroy the target marker if we created it
        if (_targetMarker != null && _targetMarker.hideFlags == HideFlags.HideInHierarchy)
        {
            Destroy(_targetMarker);
        }
    }
}
