using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/PlayerClick")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "PlayerClick", message: "[Player] has clicked at [Location]", category: "Events", id: "30989e6dec74ad8aa6c30fb10ea522bf")]
public partial class PlayerClick : EventChannelBase
{
    public delegate void PlayerClickEventHandler(GameObject Player, Transform Location);
    public event PlayerClickEventHandler Event; 

    public void SendEventMessage(GameObject Player, Transform Location)
    {
        Event?.Invoke(Player, Location);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> PlayerBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Player = PlayerBlackboardVariable != null ? PlayerBlackboardVariable.Value : default(GameObject);

        BlackboardVariable<Transform> LocationBlackboardVariable = messageData[1] as BlackboardVariable<Transform>;
        var Location = LocationBlackboardVariable != null ? LocationBlackboardVariable.Value : default(Transform);

        Event?.Invoke(Player, Location);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        PlayerClickEventHandler del = (Player, Location) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Player;

            BlackboardVariable<Transform> var1 = vars[1] as BlackboardVariable<Transform>;
            if(var1 != null)
                var1.Value = Location;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as PlayerClickEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as PlayerClickEventHandler;
    }
}

