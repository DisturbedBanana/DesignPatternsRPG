using UnityEngine;
using Unity.Behavior;

public class eventtest : MonoBehaviour
{
    [SerializeField] private BehaviorGraphAgent m_Agent;

    private PlayerClick m_playerClickEvent;

    private void OnPlayerClick(Transform targetTransform)
    {
        m_playerClickEvent.SendEventMessage(m_Agent.gameObject, targetTransform);
    }

    private void OnStateValueChanged()
    {
        
    }
}
