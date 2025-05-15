using UnityEngine;
using NaughtyAttributes;
using static GameplayEnums;

[CreateAssetMenu(fileName = "Effect", menuName = "Scriptable Objects/Effect")]
[System.Serializable]
public class Effect : ScriptableObject
{
    [BoxGroup("EffectInfo")]
    [SerializeField] private EffectType type;
    [BoxGroup("EffectInfo")]
    [SerializeField] private GameObject effectObject;
    
    //Getters
    public EffectType Type
    {
        get { return type; }
    }
    public GameObject EffectObject
    {
        get { return effectObject; }
    }
}
