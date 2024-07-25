using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    private Button button;
    private Text letterText;
    private string assignedLetter;
    private bool isInAnswer;
    private KeyboardButonState state;

    void OnEnable()
    {
        button = GetComponent<Button>();
        letterText = GetComponentInChildren<Text>();
    }

    public void InitalizeButton(string letter, Transform parent)
    {
        transform.SetParent(parent);
        transform.localScale = Vector3.one;
        letterText.text = letter;
        assignedLetter = letter;
        state = KeyboardButonState.AVAILABLE;
        Debug.Log("INIT -> " + letterText.text);
        button.onClick.AddListener(RegisterButtonListner);

    }
    public void RerollButton(string letter)
    {
        if (!MatchState(KeyboardButonState.AVAILABLE)) return;
        letterText.text = letter;
        assignedLetter = letter;
    }
    private void RegisterButtonListner()
    {
        InputHandler.instance?.LetterClicked(this);
    }
    public void FreezeButton()
    {
        InputHandler.instance?.LetterFrozen(this);

    }
    public void SetLetterIsSubstring()
    {
        isInAnswer = true;
    }

    public void OnLetterRevealedFaulty()
    {
        letterText.color = Color.red;
        button.interactable = false;
        button.onClick.RemoveAllListeners();
        state = KeyboardButonState.REVEALED_FAULTY;

    }
    public void OnButtonFreezed() {
        button.interactable = false;
        letterText.color = Color.green;
        state = KeyboardButonState.FROZEN;

    }
    public void OnEntryAccepted()
    {
        button.interactable = false;
        state = KeyboardButonState.IN_ANSWER;
    }
    public void OnLetterRemoved()
    {
        button.interactable = true;
        state = KeyboardButonState.AVAILABLE;
    }
    public bool MatchState(KeyboardButonState wantedState)
    {
        return wantedState.Equals(state);
    }
    public string GetAssignedLetter()
    {
        return assignedLetter;
    }
    public bool isSubstringOfAnswer()
    {
        return isInAnswer;
    }
    

}

public enum KeyboardButonState
{
    AVAILABLE,
    IN_ANSWER,
    REVEALED_FAULTY,
    FROZEN
}