using UnityEngine;

public abstract class PlayerState
{
    public PlayerStateMachine StateMachine;
    public Rigidbody Rb => StateMachine.rb;
    protected Camera _mainCam;

    protected Ray _ray;

    public virtual void StateEnter()
    {
        //Debug.Log("StateEnter" + GetType().Name);
    }
    public virtual void StateUpdate()
    {
        //Debug.Log("StateUpdate" + GetType().Name);
    }
    public virtual void StateFixedUpdate()
    {

    }
    public virtual void StateExit()
    {
        //Debug.Log("StateExit" + GetType().Name);
    }
    public virtual void StateOnTriggerEnter(Collider other)
    {

    }
    public void ChangeState(PlayerState nextState)
    {
        StateMachine.ChangeState(nextState);
    }

}
