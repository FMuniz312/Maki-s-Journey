using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MunizCodeKit.Systems
{
    [System.Serializable]
    public class PlayerSaveData
    {
        public int highScoreValue;
       
        public bool PassedThroughTutorial;
        public float musicVolume = 1;
        public float sfxVolume = 1;
    }
 
}