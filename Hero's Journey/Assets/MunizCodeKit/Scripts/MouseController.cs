using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Systems;

public class MouseController : MonoBehaviour
{
    bool isHoldingTrash;
    Transform trashTransform;
    private void Update()
    {
        if (!isHoldingTrash)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D info = MouseHelper.MouseRayCast();
                if (info && info.collider.CompareTag("trash"))
                {
                    trashTransform = info.transform;
                    isHoldingTrash = true;
                    SoundSystem.instance.PlaySound(SoundSystem.Sound.GarbageCollect);
                }
            }
        }
        else
        {
            if (trashTransform)
            {
                if (Input.GetMouseButtonUp(0))
                {
                  //  trashTransform.GetComponent<TrashBehaviour>().CheckGarbageCan();
                    trashTransform = null;
                    isHoldingTrash = false;
                }
                if (isHoldingTrash) trashTransform.position = MouseHelper.MouseWorldPos();
            }
        }

    }
}
