using System;
using System.Collections;
using NaughtyAttributes;
using Script;
using Unity.Behavior;
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

    [Button ("Heal")]
    public void TestHeal()
    {
        Heal(1);
    }
    
    public void Heal(int healAmount)
    {
        if (isDead)
            return;
        
        if (health + healAmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmount;
        }
        
        effectsPlayer.PlayEffect(EffectType.Heal);
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
            gameObject.GetComponentInChildren<BehaviorGraphAgent>().enabled = false;
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Die");
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
    
    private IEnumerator DamageTimerCoroutine()
    {
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
}
