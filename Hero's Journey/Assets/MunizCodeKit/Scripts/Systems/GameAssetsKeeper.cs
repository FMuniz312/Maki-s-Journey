using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MunizCodeKit.Systems
{
    public class GameAssetsKeeper : MonoBehaviour
    {
        static GameAssetsKeeper _i;
        static public GameAssetsKeeper instance
        {
            get
            {
               
                return _i;
            }
            set { }
        }

        private void Awake()
        {
            if (_i == null) _i = this;
        }

        public GameObject prefabTextPopUp;

        

    }
}