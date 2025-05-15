using System;
using UnityEngine;
using Unity.Behavior;

public class GamewideEventsManager : MonoBehaviour
{
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

    private void ApplyDamageToEntity(GameObject damageGiver, GameObject damageReceiver)
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
