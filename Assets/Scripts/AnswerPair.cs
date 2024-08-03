using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPair : MonoBehaviour
{
    private AnswerBarAssigner answerBar;
    private KeyboardManager keyboard;

    void Awake()
    {
        answerBar = GetComponentInChildren<AnswerBarAssigner>();
        keyboard = GetComponentInChildren<KeyboardManager>();
    }

    public AnswerBarAssigner GetAnswerBar()
    {
        return answerBar;
    }
    public KeyboardManager GetKeyboard()
    {
        return keyboard;
    }
}
