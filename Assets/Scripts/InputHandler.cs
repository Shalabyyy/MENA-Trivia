using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static InputHandler instance;
    [SerializeField] private AnswerLocalizationHandler localizer;

    private AnswerBarAssigner localAnswerBarReference;

    // TO DO -> track pairs
    void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }
    public void LetterClicked(LetterButton letterButton)
    {
        UpdateAnswerBarLocalReference();

        if (localAnswerBarReference.isAnswerFull()) return;

        Debug.Log("Clicked on letter " + letterButton.GetAssignedLetter());
        localAnswerBarReference.AddLetter(letterButton);
        letterButton.OnEntryAccepted();

    }
    public void LetterFrozen(LetterButton letterButton)
    {
        UpdateAnswerBarLocalReference();

        if (localAnswerBarReference.isAnswerFull()) return;

        Debug.Log("Frozen letter " + letterButton.GetAssignedLetter());
        localAnswerBarReference.AddFrozenLetter(letterButton);
        letterButton.OnButtonFreezed();
    }
    private void UpdateAnswerBarLocalReference()
    {
        localAnswerBarReference = localizer.GetCurrentPair().GetAnswerBar();
    }
}
