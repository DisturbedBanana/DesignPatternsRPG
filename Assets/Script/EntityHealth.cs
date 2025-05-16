using System;
using System.Collections;
using Script;
using UnityEngine;
using UnityEngine.Serialization;
using static GameplayEnums;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int health = 10;
    
    private bool canTakeDamage = true;
    private bool isDead = false;

    private EffectsPlayer effectsPlayer;

    private void Start()
    {
        effectsPlayer = GetComponent<EffectsPlayer>();
    }

    private void Reset()
    {
        gameObject.AddComponent<EffectsPlayer>();
    }

    public bool IsDead { get { return isDead; } }
    
    public void TakeDamage(int damage)
    {
        if (!canTakeDamage)
            return;
        
        if (damage <= 0)
            return;
        
        health -= damage;
        canTakeDamage = false;
        CheckIfDead();
    }

    public void Heal()
    {
        
    }

    private void CheckIfDead()
    {
        if (health > 0)
        {
            effectsPlayer.PlayEffect(EffectType.Damage);
            StartCoroutine(DamageTimerCoroutine());
        }
        else
        {
            Debug.Log(gameObject.name + " is dead");
            effectsPlayer.PlayEffect(EffectType.Death);
            isDead = true;
        }
    }
    
    private IEnumerator DamageTimerCoroutine()
    {
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
}
