using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    public override void StateEnter()
    {
        _mainCam = Camera.main;
    }

    public override void StateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out RaycastHit hit, StateMachine.maxClickDistance, StateMachine.groundLayer))
            {
                StateMachine.targetTransform.transform.position = hit.point;    
                ChangeState(StateMachine.move);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ChangeState(StateMachine.attack);
        }
    }
}
