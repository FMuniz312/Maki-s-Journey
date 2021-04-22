using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Interface;

public class CharacterAnimatorHandler : MonoBehaviour
{
    IMovementUser movementScript;
    Animator characterAnimator;
 
   

    void Awake()
    {
        movementScript = GetComponent<IMovementUser>();
        characterAnimator = GetComponent<Animator>();

    }

    
    void FixedUpdate()
    {
        if(movementScript.GetMovementSpeed() != 0)
        {
            characterAnimator.SetBool("movementSpeed", true);
            if(movementScript.GetMovementSpeed() > 1)
            {

                transform.localScale = new Vector3(-1, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector3(1, transform.localScale.y);

            }
        }
        else
        {
            characterAnimator.SetBool("movementSpeed", false);

        }
    }

    public void StartAttackAnimation()
    {
        if(Random.Range(0, 100) < 50)
        {
            characterAnimator.SetTrigger("Attack");
        }
        else
        {
            characterAnimator.SetTrigger("Attack2");

        }
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPositionTransform.position, attackRayCastRadius);
   }
    */
}
