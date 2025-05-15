using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;
using static GameplayEnums;

namespace Script
{
    public class EffectsPlayer : MonoBehaviour
    {
        [BoxGroup("Template")]
        [OnValueChanged("OnTemplateChanged")]
        [SerializeField] EffectsPlayerTemplate effectsTemplate;
        [BoxGroup("DebugList")]
        [ReadOnly]
        [SerializeField]private List<GameObject> effectsObjects = new List<GameObject>();
    
        private void Reset()
        {
            OnTemplateChanged();
        }

        public void PlayEffect(EffectType effectType)
        {
            if (effectsObjects.Count == 0) return;
        
            foreach (var effect in effectsTemplate.Effects)
            {
                if (effect.Type == effectType)
                {
                    // Find the corresponding object in our list
                    GameObject effectObject = effectsObjects.FirstOrDefault(obj => obj.name == effect.name);
            
                    if (effectObject != null)
                    {
                        // Get the particle system and play it
                        ParticleSystem particleSystem = effectObject.GetComponent<ParticleSystem>();
                        if (particleSystem != null)
                        {
                            particleSystem.Play();
                        }
                        else
                        {
                            Debug.LogWarning($"No particle system found on effect object: {effect.name}");
                        }
                        return;
                    }
                }
            }
    
            Debug.LogWarning($"Effect of type {effectType} not found");
        }
    
        private void OnTemplateChanged()
        {
            if (effectsObjects.Count != 0)
            {
                foreach (var effectObject in effectsObjects.ToList())
                {
                    effectsObjects.Remove(effectObject);
                    DestroyImmediate(effectObject);
                }
            }
        
            if (effectsTemplate == null)
            {
                return;
            }
        
            foreach (Effect effect in effectsTemplate.Effects)
            {
                // Instantiate the effect's GameObject and parent it to our container
                if (effect.EffectObject != null)
                {
                    GameObject instantiatedEffect = Instantiate(effect.EffectObject, transform);
                    
                    instantiatedEffect.name = effect.name;
                    instantiatedEffect.transform.localPosition = Vector3.zero + new Vector3(0, 1, 0); 
                    instantiatedEffect.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                    instantiatedEffect.transform.SetParent(transform);
                    
                    ParticleSystem[] particleSystems = instantiatedEffect.GetComponentsInChildren<ParticleSystem>();
                    foreach (var system in particleSystems)
                    {
                        system.Stop();
                    }
                    
                    effectsObjects.Add(instantiatedEffect);
                }
                else
                {
                    Debug.LogWarning($"Effect {effect.name} has no EffectObject assigned");
                }
            }
        }
    }
}
