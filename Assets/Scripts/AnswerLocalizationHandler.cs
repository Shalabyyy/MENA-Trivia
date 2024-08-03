using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerLocalizationHandler : MonoBehaviour
{
    [SerializeField] private AnswerPair englishView;
    [SerializeField] private AnswerPair arabicView;

    [SerializeField] private bool isEnglish = true;

    private void Start()
    {
        UpdatePanelViewport();
    }
    public AnswerPair GetEnglishAnswerPair()
    {
        return englishView;
    }
    public AnswerPair GetArabicAnswerPair()
    {
        return arabicView;
    }
    public AnswerPair GetPair(bool isEnglishRequest)
    {
        return isEnglishRequest ? GetEnglishAnswerPair() : GetArabicAnswerPair();
    }
    public AnswerPair GetCurrentPair()
    {
        return GetPair(isEnglish);
    }
    public bool isLanguageEnglish()
    {
        return isEnglish;
    }
    //Viewport Functionality
    public void SwitchLanguage()
    {
        isEnglish = !isEnglish;
        UpdatePanelViewport();
    }
    private void UpdatePanelViewport()
    {
        englishView.gameObject.SetActive(isEnglish);
        arabicView.gameObject.SetActive(!isEnglish);
    }
}
