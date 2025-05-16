using UnityEngine;

public class GamewideEventsManager : MonoBehaviour
{
    public static GamewideEventsManager instance;

    [SerializeField] private ApplyDamage applyDamage;

    private EntityHealth healthComponent;


    private void OnEnable()
    {
        applyDamage.Event += ApplyDamageToEntity;
    }

    private void OnDisable()
    {
        applyDamage.Event -= ApplyDamageToEntity;
    }

    public void ApplyDamageToEntity(GameObject damageGiver, GameObject damageReceiver)
    {
        if (damageReceiver == null)
        {
            Debug.LogError("No DamageReceiver assigned");
            return;
        }

        healthComponent = damageReceiver.GetComponent<EntityHealth>();
        healthComponent?.TakeDamage(healthComponent.IsDead ? 0 : 1);
    }
}
