using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/PlayerAttack")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "PlayerAttack", message: "Player attacks", category: "Events", id: "35b15a5273d55fdf580ae28d175246bf")]
public partial class PlayerAttack : EventChannelBase
{
    public delegate void PlayerAttackEventHandler();
    public event PlayerAttackEventHandler Event; 

    public void SendEventMessage()
    {
        Event?.Invoke();
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        Event?.Invoke();
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        PlayerAttackEventHandler del = () =>
        {
            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as PlayerAttackEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as PlayerAttackEventHandler;
    }
}

