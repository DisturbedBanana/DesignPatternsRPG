using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _ATK;
    [SerializeField] private float _ATKSPEED;
    [SerializeField] private float _SPEED;
    [SerializeField] private float _HEALTH;
    [SerializeField] private float _DEF;

    [SerializeField] private SOStatsAlterable _SOStats;

    private UnityEvent m_StatsUP;

    private void Start()
    {
        _ATK = _SOStats._ATK;
        _ATKSPEED = _SOStats._ATKSPEED;
        _SPEED = _SOStats._SPEED;
        _HEALTH = _SOStats._HEALTH;
        _DEF = _SOStats._DEF;

        m_StatsUP = new UnityEvent();
        m_StatsUP.AddListener(ONEventTriggered);
    }

    private void Update()
    {
        
    }

    public void ONEventTriggered()
    {

    }

    public void GetStatsSOStatsUp(SOStatsAlterable _stats)
    {

    }

}
