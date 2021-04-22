using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using MunizCodeKit.Systems;

/*********************************************************************************************
 * Throw Input Handler
 * Author: Muniz
 * Youtube: https://www.youtube.com/channel/UCAOamcXgoT0gVjV1AG5b1Fg
 * Twitter: @MrFBMuniz
 * Created: 24/01/2021 : dd/mm/yyyy
 * 
 *  Event: BlackthornProd GameJam #3
 * *******************************************************************************************/

//Handler of the player input for the main mechanic. 
public class ThrowInputHandlerSAFEMODE : MonoBehaviour
{
    [Header("Input Control")]
    [SerializeField] float maxPullDistance;//Max distance in world units that the player can actually pull and have any effect
    [SerializeField] float maxPullForce;//Max force that the object can be thrown
    [SerializeField] float minPullForce;//Min force that the object can be thrown
    [SerializeField] float raycastRadius;//Raycast (circle) size. We use this raycast to locate the nearest NPC to throw

    [Header("Tween")]
    [SerializeField] float CameraShakeForce;
    [SerializeField] float CameraShakeDuration;

    [Header("Raycast2D")]
    [SerializeField] LayerMask throwableMask; //Mask of the throwable object for the RayCast2D
    float forcemultiplier;
    GameObject targetObject;
    ThrowObjectSystem throwObjectSystem;
    bool startPulling;
    Vector3 mouseOnWorldPosition;
    Vector3 launchDirection;

    bool isHoldingSomething;

    //quick-temporary fix
    bool pulled;
    //




    public static float impulseForceRead;
    private void Awake()
    {
        throwObjectSystem = new ThrowObjectSystem();
        DirectionalArrowBehaviour.SetupArrow(() => launchDirection);
    }

   /* void Update()
    {
        try
        {
            if (GameManager.isGameRunning)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    mouseOnWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hitInfo = Physics2D.CircleCast(mouseOnWorldPosition, raycastRadius, Vector2.zero, 0, throwableMask);
                    if (hitInfo && hitInfo.transform.gameObject != null  )
                    {
                        targetObject = hitInfo.transform.gameObject;
                         startPulling = true;
                        SoundSystem.instance.PlaySound(SoundSystem.Sound.GarbageCollect);
                    }
                }
                //this boolean is to make sure the this function only cares about the "onButtonUnclicked" once the "onButtonClicked" is triggered
                if (startPulling)
                {
                    targetObject.transform.SetParent(null);
                    mouseOnWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mouseOnWorldPosition.z = 0;
                    float distance = Vector2.Distance(mouseOnWorldPosition, targetObject.transform.position);
                    if (distance > maxPullDistance) forcemultiplier = 1;
                    else
                    {
                        forcemultiplier = distance / maxPullDistance;
                    }
                    float finalForce = forcemultiplier * maxPullForce;
                    if (finalForce < minPullForce)
                    {
                        finalForce = minPullForce;
                    }
                    launchDirection = (targetObject.transform.position - mouseOnWorldPosition).normalized;
                    //  Debug.DrawRay(targetObject.transform.position, launchDirection * finalForce);
                    if (!pulled)
                    {
                        DirectionalArrowBehaviour.instance.ShowArrow(targetObject.transform.position);
                        pulled = true;
                    }
                    //enter the if statement if the player let go of the left mouse button
                    if (Input.GetMouseButtonUp(0))
                    {
                        startPulling = false;

                        DoAction(finalForce);
                        pulled = false;

                        SoundSystem.instance.PlaySound(SoundSystem.Sound.GarbageThrow);
                    }

                }
            }
        }
        catch
        {
            Debug.Log("Transform destroyed");
        }

    }


    /// <summary>
    /// Handles the main action of the if statement. In this case: Throws the object
    /// </summary>
    void DoAction(float finalforce)
    {

        if (targetObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.None)
        {
            targetObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        throwObjectSystem.ThrowObject(targetObject, launchDirection, finalforce);
        MunizCodeKit.MonoBehaviours.CameraController.ShakeCamera(CameraShakeForce,CameraShakeDuration);





        targetObject = null;
        DirectionalArrowBehaviour.instance.HideArrow();

    }


 
*/
}