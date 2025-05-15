using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float _ATK;
    private float _SPEED;
    private float _ATKSPEED;
    private float _HEALTH;
    private float _DEF;

    [SerializeField] private SOStatsAlterable baseStats;

    private void Start()
    {
        ApplyStats(baseStats);
    }

    public void AddStats(SOStatsAlterable statsToAdd)
    {
        _ATK += statsToAdd.ATK;
        _SPEED += statsToAdd.SPEED;
        _ATKSPEED += statsToAdd.ATKSPEED;
        _HEALTH += statsToAdd.HEALTH;
        _DEF += statsToAdd.DEF;

        Debug.Log($"Stats updated! ATK: {_ATK}, SPEED: {_SPEED}, HEALTH: {_HEALTH}");
    }

    private void ApplyStats(SOStatsAlterable stats)
    {
        _ATK = stats.ATK;
        _SPEED = stats.SPEED;
        _ATKSPEED = stats.ATKSPEED;
        _HEALTH = stats.HEALTH;
        _DEF = stats.DEF;
    }
}
