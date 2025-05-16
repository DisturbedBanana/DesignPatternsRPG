using UnityEngine;

public class PlayerStateMove : PlayerState
{
    public float speed = 5f;
    private Vector3 _targetPos;

    public override void StateEnter()
    {
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
        if (StateMachine.gameObject .GetComponent<EntityHealth>().IsDead) return;
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

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            StateMachine.transform.rotation = Quaternion.Slerp(StateMachine.transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        direction.Normalize();
        StateMachine.transform.position += direction * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(1))
        {
            ChangeState(StateMachine.attack);
        }

        direction.Normalize();
        StateMachine.transform.position += direction * speed * Time.deltaTime;
    }
}
