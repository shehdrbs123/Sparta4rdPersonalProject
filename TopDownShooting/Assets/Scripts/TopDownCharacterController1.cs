using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine;

public class TopDownCharacterController1 : MonoBehaviour
{
    [SerializeField] private float attackDelay;
    [CanBeNull] public event Action<Vector2> OnMoveEvent;
    [CanBeNull] public event Action<Vector2> OnLookEvent;
    [CanBeNull] public event Action<AttackSO> OnAttackEvent;
    [CanBeNull] public event Action OnInventoryEvent;
    [CanBeNull] public event Action<GameObject> OnInteractEvent;
    [CanBeNull] public event Action OnStatusEvent;
    private float _timeSinceLastShoot = 0;
    protected bool IsAttacking = false;
    
    protected CharacterStatsHandler Stats { get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();        
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastShoot < Stats.CurrentStates.attackSO.delay)
        {
            _timeSinceLastShoot += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastShoot > Stats.CurrentStates.attackSO.delay)
        {
            IsAttacking = false;
            CallAttackEvent(Stats.CurrentStates.attackSO);
        }
    }
    
    // Start is called before the first frame update


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 look)
    {
        OnLookEvent?.Invoke(look);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }

    public void CallOnInventoryEvent()
    {
        OnInventoryEvent?.Invoke();
    }

    public void CallOnInteractEvent()
    {
        OnInteractEvent?.Invoke(gameObject);
    }

    public void CallOnStatusEvent()
    {
        OnStatusEvent?.Invoke();   
    }
}
