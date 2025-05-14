using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "NullCheck", story: "Check if [Var] is null", category: "Conditions", id: "2823d7d5745aca9fc469fc3ac164a531")]
public partial class NullCheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Transform> Var;

    public override bool IsTrue()
    {
        return Var == null;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
