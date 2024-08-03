using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildCardManager : SingletonBehaviour<WildCardManager>
{
    private AnswerLocalizationHandler localizer;


    private void Start()
    {
        localizer = FindObjectOfType<AnswerLocalizationHandler>();


    }

    [ContextMenu("Remove 50% of decoy letters")]
    public void ActivateFiftyPercentWildcard()
    {
        localizer.GetCurrentPair().GetAnswerBar().ClearAnswerBar();
        localizer.GetCurrentPair().GetKeyboard().RemoveHalfTheLetters();
    }
    [ContextMenu("Clear bar and Add first 3 letters")]
    public void AddFirstThreeLetters()
    {
        localizer.GetCurrentPair().GetAnswerBar().ClearAnswerBar();
        localizer.GetCurrentPair().GetKeyboard().AddFirstThreeLetters(localizer.GetCurrentPair().GetAnswerBar().GetFirstCorrectThreeCharachters());
    }

    [ContextMenu("Re Roll Faulty Letters")]
    public void RerollDecoyCards()
    {
        localizer.GetCurrentPair().GetAnswerBar().ClearAnswerBar();
        localizer.GetCurrentPair().GetKeyboard().ReRollFaultyLetterButtons(localizer.isLanguageEnglish());
    }
    public void ChangeLanguage()
    {
        //answerBar.ReRollBar();
        //keyboard.OnLanguageChanged();
        //generator.ToggleLanguage();
    }
}
