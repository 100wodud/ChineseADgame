using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected CharacterStatsHandler Stats { get; private set; }

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStates.attackSO == null)
            return;

        if (_timeSinceLastAttack <= Stats.CurrentStates.attackSO.delay * 0.01f)    // TODO
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStates.attackSO.delay * 0.01f)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStates.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direciton)
    {
        OnMoveEvent?.Invoke(direciton);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
