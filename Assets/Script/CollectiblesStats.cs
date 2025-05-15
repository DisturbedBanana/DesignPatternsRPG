using UnityEngine;

public class CollectiblesStats : MonoBehaviour
{
    [SerializeField] private SOStatsAlterable stats;

    private void OnTriggerEnter(Collider other)
    {
        /*        IStatsReceiver receiver = other.GetComponent<IStatsReceiver>();
                if (receiver != null)
                {
                    receiver.AddStats(stats);
                    Destroy(gameObject);
                }*/

        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null)
        {
            Debug.Log("triggered");
            player.AddStats(stats);
            Destroy(gameObject);
        }
    }
}
