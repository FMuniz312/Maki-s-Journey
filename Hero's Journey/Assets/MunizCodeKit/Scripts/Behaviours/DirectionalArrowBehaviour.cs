using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrowBehaviour : MonoBehaviour
{
    static Func<Vector3> launchDirection;
    SpriteRenderer spriteRenderer;
    Quaternion rotation;
    bool isArrowActive;
    #region singleton
    static public DirectionalArrowBehaviour instance;
    private void Awake()
    {
        if (instance == null) instance = this;
         spriteRenderer = GetComponent<SpriteRenderer>();
        HideArrow();

    }
    #endregion
    static public void SetupArrow(Func<Vector3> launchdirection)
    {
        launchDirection = launchdirection;


    }

    private void Update()
    {
        if (isArrowActive)
        {
            rotation = Quaternion.AngleAxis(MunizCodeKit.Systems.UtilsClass.GetAngleFromVectorFloat(launchDirection()) - 90, Vector3.forward) ;
            transform.rotation = rotation;
        }
    }

    public void HideArrow()
    {
        Color alpha = spriteRenderer.color;
        alpha.a = 0;
        spriteRenderer.color = alpha;
        isArrowActive = false;
    }

    public void ShowArrow(Vector3 pos)
    {
        transform.position = pos;
        Color alpha = spriteRenderer.color;
        alpha.a = 1;
        spriteRenderer.color = alpha;
        isArrowActive = true;
    }
}
