using UnityEngine;

[CreateAssetMenu(fileName = "SOStatsAlterable", menuName = "Scriptable Objects/SOStatsAlterable")]
public class SOStatsAlterable : ScriptableObject
{
    [SerializeField] private float _ATK;
    [SerializeField] private float _SPEED;
    [SerializeField] private float _ATKSPEED;
    [SerializeField] private float _HEALTH;
    [SerializeField] private float _DEF;

    public float ATK => _ATK;
    public float SPEED => _SPEED;
    public float ATKSPEED => _ATKSPEED;
    public float HEALTH => _HEALTH;
    public float DEF => _DEF;
}
