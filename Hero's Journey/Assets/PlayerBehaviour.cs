using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Interface;
using MunizCodeKit.Systems;

public class PlayerBehaviour : MonoBehaviour, IAttackTarget
{
    [SerializeField] Transform attackPositionTransform;
    [SerializeField] float attackRayCastRadius;
    [SerializeField] LayerMask attackTargetLayer;
    [SerializeField] float attackCoolDown;
    bool canAttack;
    float attackDelay;

    private void Awake()
    {
        attackDelay = attackCoolDown;
    }
    void Update()
    {
        if(canAttack==false) attackDelay -= Time.deltaTime;
        if (attackDelay < 0)
        {
            canAttack = true;
               
            if (Input.GetKeyDown(KeyCode.E))
            {
                attackDelay += attackCoolDown;
                GetComponent<CharacterAnimatorHandler>().StartAttackAnimation();
                canAttack = false;
            }
        }
    }
    public void Attack()
    {
        RaycastHit2D info = Physics2D.CircleCast(attackPositionTransform.position, attackRayCastRadius, Vector2.zero, Mathf.Infinity, attackTargetLayer);
        if (info)
        {
            info.transform.GetComponent<IAttackTarget>().Attacked();
        }
    }

    public PointsSystem GetHealthSystem()
    {
        throw new System.NotImplementedException();
    }

    public void Attacked()
    {
        Debug.Log("player damaged");
    }

    public void Attacked(float damage)
    {
        throw new System.NotImplementedException();
    }
}
