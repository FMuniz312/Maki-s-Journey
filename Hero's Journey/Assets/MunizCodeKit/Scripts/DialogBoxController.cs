using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using MunizCodeKit.Systems;

public class DialogBoxController : MonoBehaviour
{
    public static DialogBoxController instance { get; private set; }
    [SerializeField] GameObject panelGameObject;
    [SerializeField] Text dialogText;
    [SerializeField] Button closeDialogButton;
    [SerializeField] Image dialogCharImage;

    [Header("Tween")]
    [SerializeField] float dialogBoxPunchForce;
    [SerializeField] float dialogBoxPunchDuration;

    Tween checkTextComplete;
    Tween checkPopUPComplete;

    private void Awake()
    {
        if (instance == null) instance = this;


    }
    private void Start()
    {
        HideDialogBox();
    }

    public void ShowDialogBox(string text, float delay, Sprite dialogcharsprite)
    {
        checkPopUPComplete?.Complete();
        checkTextComplete?.Complete();
        dialogText.text = "";
        dialogCharImage.sprite = dialogcharsprite;

      //  GameManager.PauseGame(true);
        panelGameObject.SetActive(true);
        checkPopUPComplete = panelGameObject.GetComponent<RectTransform>().DOScale(1, dialogBoxPunchDuration).
            OnComplete(() =>
            {
                SoundSystem.instance.PlaySound(SoundSystem.Sound.UIText);
                checkTextComplete = dialogText.DOText(text, delay).OnComplete(() =>
                {
                    SoundSystem.instance.StopTextSound();

                });
            });

        
    }

    public void ShowDialogBox(string text, float delay, Sprite dialogcharsprite, UnityEngine.Events.UnityAction afterbuttonclicked)
    {
        ShowDialogBox(text, delay, dialogcharsprite);
        closeDialogButton.onClick.AddListener(afterbuttonclicked);

    }

    public void ShowDialogBox(string text, float delay, Sprite dialogcharsprite, UnityEngine.Events.UnityAction afterbuttonclicked, string closebuttontext)
    {
        ShowDialogBox(text, delay, dialogcharsprite, afterbuttonclicked);
        closeDialogButton.GetComponentInChildren<Text>().text = closebuttontext;
         

    }
    public void HideDialogBox()
    {
        SoundSystem.instance.StopTextSound();
        SoundSystem.instance.PlaySound(SoundSystem.Sound.UIClick);
        closeDialogButton.onClick.RemoveAllListeners();

        panelGameObject.GetComponent<RectTransform>().localScale = Vector3.zero * .02f;
        panelGameObject.SetActive(false);
    }



}
