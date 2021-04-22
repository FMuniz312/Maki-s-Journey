using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Interface;

public class AIMovement2DPlatformer : MonoBehaviour, IMovementUser
{
    [Header("Setup")]
    [SerializeField] Transform checkBottomRightMoveSafetyTransform;
    [SerializeField] Transform checkBottomLeftMoveSafetyTransform;
    [SerializeField] Transform checkRightMoveSafetyTransform;
    [SerializeField] Transform checkLeftMoveSafetyTransform;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] float checkRadius;

    [Header("Balance")]
    [SerializeField] float jumpForce;

    Rigidbody2D rbody;
    bool isGrounded;
    

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (CheckForJumps() && isGrounded)
        {
            rbody.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (CheckForEndOfGround())
        {
            rbody.velocity = Vector2.zero;
        }
    }

    bool CheckForJumps()
    {
        float speed = rbody.velocity.x;
        if (speed > 0) //walking right
        {
            //check for jump
            RaycastHit2D info = Physics2D.CircleCast(checkRightMoveSafetyTransform.position, checkRadius, Vector2.zero, Mathf.Infinity, groundLayerMask);
            if (info)
            {
                //jump
                return true;
            }

        }
        else if (speed < 0) //walking left
        {
            //check for jump
            RaycastHit2D info = Physics2D.CircleCast(checkLeftMoveSafetyTransform.position, checkRadius, Vector2.zero, Mathf.Infinity, groundLayerMask);
            if (info)
            {
                //jump
                return true;
            }
        }
        return false;
    }

    bool CheckForEndOfGround()
    {
        float speed = rbody.velocity.x;

        if (speed > 0) //walking right
        {
            //check for end of ground
            RaycastHit2D info = Physics2D.CircleCast(checkBottomRightMoveSafetyTransform.position, checkRadius, Vector2.zero, Mathf.Infinity, groundLayerMask);
            if (!info)
            {//stop moving to the right;
                return true;
            }
        }
        else if (speed < 0) //walking left
        {
            //check for end of ground
            RaycastHit2D info = Physics2D.CircleCast(checkBottomLeftMoveSafetyTransform.position, checkRadius, Vector2.zero, Mathf.Infinity, groundLayerMask);
            if (!info)
            {//stop moving to the left;
                return true;
            }
        }
        return false;
    }
    public float GetMovementSpeed()
    {
        throw new System.NotImplementedException();
    }
}
