using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public PlayerStateAttack State;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Ennemi touch� : " + other.name);
        }
    }
}
