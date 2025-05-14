using UnityEngine;
using UnityEngine.Events;

public class PointClick : MonoBehaviour
{
    private Transform _playerPos;
    private Vector3 _targetPos;

    //[SerializeField] UnityEvent moveEvent;

    private void Awake()
    {
        _playerPos = GetComponent<Transform>();
    }

    private void Start()
    {
        //if (moveEvent == null)
        //    moveEvent = new UnityEvent();
        //
        //moveEvent.AddListener(OnEventTriggered);
        if (_playerPos == null)
        {
            Debug.Log("_playerPosError");
        }
        if (_targetPos == null)
        {
            Debug.Log("_targetPosError");
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToTarget(MouseWorld.GetPosition());
            _playerPos.position = _targetPos;
        }
        

    }
    private void MoveToTarget(Vector3 targetPosition)
    {
        Debug.Log(targetPosition);
        this._targetPos = targetPosition;
    }

    //public void OnEventTriggered()
    //{
    //    Debug.Log("EmptyEventCalled");
    //}
}
