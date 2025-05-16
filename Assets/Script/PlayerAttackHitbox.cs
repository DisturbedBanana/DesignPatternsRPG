using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public PlayerStateAttack State;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GamewideEventsManager.instance.ApplyDamageToEntity(this.transform.parent.gameObject, other.gameObject);
            Debug.Log("Ennemi touché : " + other.name);
        }
    }
}
