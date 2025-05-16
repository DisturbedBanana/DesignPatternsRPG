using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    private GameObject _hitCollider;
    private bool _hasEnded;
    private Animator _anim;

    public override void StateEnter()
    {
        Debug.Log("Player attaque !");

        Rb.linearVelocity = Vector3.zero;

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

        _anim = StateMachine.GetComponentInChildren<Animator>();
        _anim.SetTrigger("PlayerAttack");

        _hitCollider.SetActive(true);
        _hasEnded = false;
    }

    public override void StateUpdate()
    {
        base.StateUpdate();

        var stateInfo = _anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f)
        {
            OnAttackAnimationEnd();
            ChangeState(StateMachine.idle);
        }
    }

    public void OnAttackAnimationEnd()
    {
        Debug.Log("Attack animation finished");
        _hasEnded = true;
    }

    public override void StateExit()
    {
        _hitCollider?.SetActive(false);
        _hasEnded = false;
    }
}
