using UnityEngine;

[CreateAssetMenu(fileName = "SOStatsAlterable", menuName = "Scriptable Objects/SOStatsAlterable")]
public class SOStatsAlterable : ScriptableObject
{
    [SerializeField] public float _ATK { get; private set; }
    [SerializeField] public float _SPEED { get; private set; }
    [SerializeField] public float _ATKSPEED { get; private set; }
    [SerializeField] public float _HEALTH { get; private set; }
    [SerializeField] public float _DEF { get; private set; }
}
