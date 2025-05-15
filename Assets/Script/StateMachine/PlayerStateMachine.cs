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

    public LayerMask groundLayer;
    public float maxClickDistance = 100f;
    public GameObject targetTransform;
    public PlayerClick clickEvent;
    //public BehaviorGraphAgent m_Agent;

    private void Start()
    {
        if (targetTransform == null)
        {
            targetTransform = new GameObject("ClickTarget");
            targetTransform.hideFlags = HideFlags.HideInHierarchy;
        }

        foreach (PlayerState State in _allStates)
        {
            State.StateMachine = this;
        }
        ChangeState(idle);
    }


    private void Update()
    {
        currentState?.StateUpdate();
    }

    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
    }

    public void OnTriggerEnter(Collider other)
    {
        currentState?.StateOnTriggerEnter(other);
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
