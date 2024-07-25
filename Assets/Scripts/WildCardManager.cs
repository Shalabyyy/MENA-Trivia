using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildCardManager : MonoBehaviour
{

    private ButtonAssigner keyboard;
    private AnswerBarAssigner answerBar;
    private GameGuess generator;
    private bool wasFiftyPercentActivated;

    private void Start()
    {
        keyboard = FindObjectOfType<ButtonAssigner>();
        answerBar = FindObjectOfType<AnswerBarAssigner>();
        generator = FindObjectOfType<GameGuess>();

    }

    [ContextMenu("Remove 50% of decoy letters")]
    public void ActivateFiftyPercentWildcard()
    {
        answerBar.ClearAnswerBar();
        keyboard.RemoveHalfTheLetters();
    }
    [ContextMenu("Clear bar and Add first 3 letters")]
    public void AddFirstThreeLetters()
    {
        answerBar.ClearAnswerBar();
        keyboard.AddFirstThreeLetters(answerBar.GetFirstCorrectThreeCharachters());
    }

    [ContextMenu("Re Roll Faulty Letters")]
    public void RerollDecoyCards()
    {
        answerBar.ClearAnswerBar();
        keyboard.ReRollFaultyLetterButtons(generator.isEnglishLang());
    }

}
