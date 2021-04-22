using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameTimerController 
{
    #region singleton
    static public GameTimerController instance;

    private void Awake()
    {
        if (instance == null) instance = this;

    }
    #endregion

    float sceneStartedTimer;

    //Start the timer
    public GameTimerController()
    {
        sceneStartedTimer = Time.time;
    }

    public TimeSpan GetSceneDurationUntilNow()
    {
        float duration = Time.time - sceneStartedTimer;
        return TimeSpan.FromSeconds(duration);
    }



}
