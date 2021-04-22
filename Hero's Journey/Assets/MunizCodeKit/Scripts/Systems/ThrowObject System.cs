using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*********************************************************************************************
 * Throw Object System
 * Author: Muniz
 * Youtube: https://www.youtube.com/channel/UCAOamcXgoT0gVjV1AG5b1Fg
 * Twitter: @MrFBMuniz
 * Created: 23/01/2021 : dd/mm/yyyy
 * 
 * Event: BlackthornProd GameJam #3
 * *******************************************************************************************/


/// <summary>
/// Class to handle the logic around Thowing objects using its RigidBody2D component
/// </summary>
public class ThrowObjectSystem
{
    Rigidbody2D objectRigidBody;
    static public event EventHandler<CustomEventArgsData> onObjectThrown;



    /// <summary>
    /// Throws an object using its RigidBody2D component by adding Impulse force to it
    /// </summary>
    /// <param name="objectgameobject">Object that is going to be thrown (it has to have the RigidBody2D component)</param>
    /// <param name="direction">Direction to where the object should be thrown to</param>
    /// <param name="force">Amount of force of the thrown</param>
    public void ThrowObject(GameObject objectgameobject,Vector3 direction, float force)
    {
        if(objectgameobject != null && objectgameobject.GetComponent<Rigidbody2D>() != null)
        {
             
            objectRigidBody = objectgameobject.GetComponent<Rigidbody2D>();
            objectRigidBody.AddForce(force * direction, ForceMode2D.Impulse);
            CustomEventArgsData customEventArgsData = new CustomEventArgsData(objectgameobject);
            onObjectThrown?.Invoke(this, customEventArgsData);
           // Debug.DrawRay(objectgameobject.transform.position, direction * force, Color.green, 100);
        }
        else
        {
            Debug.LogError("either the gameobject is null or the gameobject doesn't have the RigidBody2D component attached");
        }
    }
    /// <summary>
    /// Throws an object using its RigidBody2D component by adding Impulse force to it 
    /// <para>Reminder: Angle in unity begins at the "top of the clock" instead of the right side of it</para>
    /// </summary>
    /// <remarks>
    /// Use 45° (sharp 45 right) and -45° (sharp 45 left) instead of 45°(sharp 45 right) and 315°(sharp 45 left)
    /// </remarks>
    /// <param name="objectgameobject">Object that is going to be thrown (it has to have the RigidBody2D component)</param>
    /// <param name="angle">Angle(degrees) to where the object should be thrown to</param>
    /// <param name="force">Amount of force of the thrown</param>
    public void ThrowObject(GameObject objectgameobject, float angle, float force)
    {//this is so we can use -45(left) or 45(right) instead of 135(left) and 45(right)
        float auxAngle;

        if(angle >= 0)
        {
            auxAngle = angle;
        }
        else
        {
            auxAngle = 180 + angle;
        }
        //this fixes the weird way that Unity handles the angle units initial position
        auxAngle -= 90;  
        Quaternion rotation = Quaternion.AngleAxis(auxAngle, Vector3.forward);
        Vector3 direction = rotation*Vector3.up ;
        ThrowObject(objectgameobject, direction, force);
    }

    public class CustomEventArgsData : EventArgs
    {
       public GameObject objectGameObject;

        public CustomEventArgsData(GameObject objectgameobject)
        {
            objectGameObject = objectgameobject;
        }
    }

}
