using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Rigidbody rb;

    public PlayerState idle = new PlayerStateIdle();
    public PlayerState move = new PlayerStateMove();
    public PlayerState attack = new PlayerStateAttack();

    private PlayerState[] _allStates => new PlayerState[]{
        idle,
        move,
        attack,
    };

    public PlayerState startState => idle;
    public PlayerState currentState;
    public PlayerState PreviousState;

    private void Start()
    {
        foreach (PlayerState State in _allStates)
        {
            State.StateMachine = this;
        }
        ChangeState(idle);
        return;
    }
    public void ChangeState(PlayerState nextState)
    {
        currentState?.StateExit();
        PreviousState = currentState;
        currentState = nextState;
        currentState?.StateEnter();
    }

#if (UNITY_EDITOR)
    private void OnGUI()
    {
        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label($"== Hero State Machine ==");
        GUILayout.Label($"Current State = {currentState}");
        GUILayout.Label($"Previous State = {PreviousState}");
        GUILayout.Label($"Velocity X={rb.linearVelocity.x}, Y={rb.linearVelocity.y}");
        GUILayout.EndVertical();
    }
#endif
}
