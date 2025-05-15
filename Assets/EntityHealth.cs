using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int health = 10;
    [FormerlySerializedAs("damageEffect")] [SerializeField] private GameObject damageParticlesObject;
    [FormerlySerializedAs("deathEffect")] [SerializeField] private GameObject deathParticlesObject;
    
    private bool canTakeDamage = true;
    private bool isDead = false;
    
    private ParticleSystem damageParticles;
    private ParticleSystem deathParticles;

    private void Start()
    {
        damageParticles = damageParticlesObject.GetComponent<ParticleSystem>();
        deathParticles = deathParticlesObject.GetComponent<ParticleSystem>();
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

    private void CheckIfDead()
    {
        if (health > 0)
        {
            damageParticles.Play();
            StartCoroutine(DamageTimerCoroutine());
        }
        else
        {
            Debug.Log("Entity is dead");
            deathParticles.Play();
            isDead = true;
        }
    }
    
    private IEnumerator DamageTimerCoroutine()
    {
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
}
