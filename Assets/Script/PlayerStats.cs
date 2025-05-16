using NaughtyAttributes.Test;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float _atk;
    private float _speed;
    private float _atkSpeed;
    private float _health;
    private float _def;
    //private SO_SOCurrentStats;

    [SerializeField] private SOStatsAlterable baseStats;

    private void Start()
    {
        ApplyStats(baseStats);
    }

    public void AddStats(SOStatsAlterable statsToAdd)
    {
        _atk += statsToAdd.ATK;
        _speed += statsToAdd.SPEED;
        _atkSpeed += statsToAdd.ATKSPEED;
        _health += statsToAdd.HEALTH;
        _def += statsToAdd.DEF;

        Debug.Log($"Stats updated! ATK: {_atk}, SPEED: {_speed}, HEALTH: {_health}");
    }

    private void ApplyStats(SOStatsAlterable stats)
    {
        _atk = stats.ATK;
        _speed = stats.SPEED;
        _atkSpeed = stats.ATKSPEED;
        _health = stats.HEALTH;
        _def = stats.DEF;
    }
}
