using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DialogSystem : MonoBehaviour
{


    [Header("Main Dialog")]
    [SerializeField] DialogDataHolder[] arrayDialogDataHolder;
    const float TEXT_DELAY = 3f;

    #region singleton
    static public DialogSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
    #endregion

    public void StartDialog(DialogEnum dialogenum)
    {
        DialogDataHolder dialogDataHolder = GetDialogDataHolder(dialogenum);
        string text = GetLanguageText(dialogDataHolder);
        Sprite sprite = GetLanguageImage(dialogDataHolder);
        try
        {
            DialogBoxController.instance.ShowDialogBox(text, TEXT_DELAY, sprite);
        }

        catch
        {
            Debug.LogError("something went wrong when looking up the key in the dictionary");
        }

    }

    public void StartDialog(DialogEnum dialogenum, UnityEngine.Events.UnityAction afterbuttonclicked)
    {
        DialogDataHolder dialogDataHolder = GetDialogDataHolder(dialogenum);
        string text = GetLanguageText(dialogDataHolder);
        Sprite sprite = GetLanguageImage(dialogDataHolder);
        DialogBoxController.instance.ShowDialogBox(text, TEXT_DELAY, sprite, afterbuttonclicked);

    }
    public void StartDialog(DialogEnum dialogenum, UnityEngine.Events.UnityAction afterbuttonclicked, string closebuttontext)
    {
        DialogDataHolder dialogDataHolder = GetDialogDataHolder(dialogenum);
        string text = GetLanguageText(dialogDataHolder);
        Sprite sprite = GetLanguageImage(dialogDataHolder);

        DialogBoxController.instance.ShowDialogBox(text, TEXT_DELAY, sprite, afterbuttonclicked, closebuttontext);

    }

    string GetLanguageText(DialogDataHolder dialogdataholder)
    {
        
             return dialogdataholder.englishText;  
            
 
    }
    Sprite GetLanguageImage(DialogDataHolder dialogdataholder)
    {
        
              return dialogdataholder.imageENG;  
           
    }

    DialogDataHolder GetDialogDataHolder(DialogEnum dialogenum)
    {
        return arrayDialogDataHolder.Where(p => p.dialogEnum == dialogenum).First();
    }

    [System.Serializable]
    public class DialogDataHolder
    {
        public DialogEnum dialogEnum;
       
        public string englishText;
      
        public Sprite imageENG;
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
}

