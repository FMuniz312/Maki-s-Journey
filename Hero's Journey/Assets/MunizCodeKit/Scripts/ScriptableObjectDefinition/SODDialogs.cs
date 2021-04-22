using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Dialog")]
public class SODDialogs : ScriptableObject
{
     public DialogDataHolder[] dialogArray;
     

    [System.Serializable]
    public class DialogDataHolder
    {
        public DialogEnum dialogEnum;
        public string dialogText;
        public Sprite image;
    }
}
public enum DialogEnum
{
    Narrator1,
    Narrator2,
    Narrator3,
    Narrator4,
    Planet1,
    Planet2,
    Planet3,
    Planet4,
    Planet5,
    Planet6,
    Planet7,
    Planet8,
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4,
    Enemy5,
    WinGame1,
    WinGame2,
    LoseGame1,
    LoseGame2

}
 