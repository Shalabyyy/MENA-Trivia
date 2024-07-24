using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static InputHandler instance;
    [SerializeField] private AnswerBarAssigner answerBar;
    [SerializeField] private ButtonAssigner keyboard;


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
        if (answerBar.isAnswerFull()) return;

        Debug.Log("Clicked on letter " +
            letterButton.GetAssignedLetter());
        answerBar.AddLetter(letterButton);
        letterButton.OnEntryAccepted();

    }
}
