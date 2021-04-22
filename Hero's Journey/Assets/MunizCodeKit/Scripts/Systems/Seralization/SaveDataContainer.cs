using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MunizCodeKit.Systems
{
    [System.Serializable]
    public class SaveDataContainer
    {
        static private SaveDataContainer _i;
        static public SaveDataContainer instance
        {
            get
            {
                if (_i == null)
                {
                    _i = new SaveDataContainer();

                }

                return _i;
            }



        }

        public PlayerSaveData PlayerSaveData;
    }
}