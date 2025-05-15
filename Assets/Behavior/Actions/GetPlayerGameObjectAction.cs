using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Get Player GameObject", story: "Gets [Player] GameObject from [Transform]", category: "Action", id: "afd6a8082c9e90601b067248928fa3fd")]
public partial class GetPlayerGameObjectAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<Transform> Transform;
    //BlackboardVariable
    
    protected override Status OnStart()
    {
        Player.Value = Transform.Value.gameObject;
        return Status.Success;
    }
}

