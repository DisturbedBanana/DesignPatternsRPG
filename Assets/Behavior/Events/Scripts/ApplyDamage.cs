using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/ApplyDamage")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "ApplyDamage", message: "[A] applies damage to [B]", category: "Events", id: "4eee47040fd5a61f77a88d3e5011850f")]
public partial class ApplyDamage : EventChannelBase
{
    public delegate void ApplyDamageEventHandler(GameObject A, GameObject B);
    public event ApplyDamageEventHandler Event; 

    public void SendEventMessage(GameObject A, GameObject B)
    {
        Event?.Invoke(A, B);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> ABlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var A = ABlackboardVariable != null ? ABlackboardVariable.Value : default(GameObject);

        BlackboardVariable<GameObject> BBlackboardVariable = messageData[1] as BlackboardVariable<GameObject>;
        var B = BBlackboardVariable != null ? BBlackboardVariable.Value : default(GameObject);

            Event?.Invoke(A, B);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        ApplyDamageEventHandler del = (A, B) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = A;

            BlackboardVariable<GameObject> var1 = vars[1] as BlackboardVariable<GameObject>;
            if(var1 != null)
                var1.Value = B;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as ApplyDamageEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as ApplyDamageEventHandler;
    }
}

