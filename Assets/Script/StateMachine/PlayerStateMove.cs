using UnityEngine;

public class PlayerStateMove : PlayerState
{
    public float speed = 5f;
    private Vector3 _targetPos;

    public override void StateEnter()
    {
        Debug.Log("State move youpi");
        if (StateMachine.targetTransform != null)
        {
            _targetPos = StateMachine.targetTransform.transform.position;
        }
        else if (StateMachine.targetTransform == null)
        {
            StateMachine.targetTransform = new GameObject("ClickTarget");
            StateMachine.targetTransform.hideFlags = HideFlags.HideInHierarchy;
        }
    }

    public override void StateUpdate()
    {
        Vector3 direction = (_targetPos - StateMachine.transform.position);
        direction.y = 0;

        if (direction.magnitude < 0.1f)
        {
            if (StateMachine.clickEvent != null)
            {
                StateMachine.clickEvent.SendEventMessage(StateMachine.gameObject, StateMachine.targetTransform.transform);
            }
            ChangeState(StateMachine.idle);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ChangeState(StateMachine.attack);
        }

        direction.Normalize();
        StateMachine.transform.position += direction * speed * Time.deltaTime;
    }
}
