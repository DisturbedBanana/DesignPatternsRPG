using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    private GameObject _hitCollider;
    private float _attackDuration = 0.5f;
    private float _timer = 0f;

    public override void StateEnter()
    {
        Debug.Log("Player attaque !");

        rb.linearVelocity = Vector3.zero;

        if (_hitCollider == null)
        {
            _hitCollider = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _hitCollider.transform.SetParent(StateMachine.transform);
            _hitCollider.transform.localPosition = new Vector3(0, 1, 1);
            _hitCollider.transform.localScale = new Vector3(2f, 2f, 2f);
            Object.Destroy(_hitCollider.GetComponent<MeshRenderer>());
            var col = _hitCollider.GetComponent<Collider>();
            col.isTrigger = true;
            _hitCollider.AddComponent<PlayerAttackHitbox>().State = this;
        }

        _hitCollider.SetActive(true);
        _timer = 0f;
    }

    public override void StateUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= _attackDuration)
        {
            _hitCollider.SetActive(false);
            ChangeState(StateMachine.idle);
        }
    }

    public override void StateExit()
    {
        _hitCollider?.SetActive(false);
    }
}
