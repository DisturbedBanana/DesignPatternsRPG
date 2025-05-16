using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamewideEventsManager : MonoBehaviour
{
    public static GamewideEventsManager instance;

    [SerializeField] private ApplyDamage applyDamage;

    private EntityHealth healthComponent;

    [SerializeField] private GameObject deathCanvas;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void ActivateDeathCanvas()
    {
        if (deathCanvas != null)
        {
            deathCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("DeathCanvas not found in the scene.");
        }
    }
    
    public void CanvasRestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
