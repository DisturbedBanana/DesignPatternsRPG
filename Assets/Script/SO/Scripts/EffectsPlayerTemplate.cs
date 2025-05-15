using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "EffectsPlayerTemplate", menuName = "Scriptable Objects/EffectsPlayerTemplate")]
public class EffectsPlayerTemplate : ScriptableObject
{
    [SerializeField] private List<Effect> effects = new List<Effect>();
    
    public List<Effect> Effects
    {
        get { return effects; }
    }
}
