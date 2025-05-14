using UnityEngine;

public class CollectiblesStats : MonoBehaviour
{
    [SerializeField] SOStatsAlterable _Stats;
    private PlayerStats _playerStats;

    private void OnTriggerEnter(Collider other)
    {
        _playerStats.GetStatsSOStatsUp(_Stats);
    }
}
