using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    private Button button;
    private Text letterText;
    private string assignedLetter;
    private KeyboardButonState state;
    void OnEnable()
    {
        button = GetComponent<Button>();
        letterText = GetComponentInChildren<Text>();
    }

    public void InitalizeButton(string letter , Transform parent)
    {
        transform.parent = parent;
        transform.localScale = Vector3.one;
        Debug.Log("INIT -> " + letterText.text);
        letterText.text = letter;
        assignedLetter = letter;
        state = KeyboardButonState.AVAILABLE;
        button.onClick.AddListener(RegisterButtonListner);

    }
    private void RegisterButtonListner()
    {
        Debug.Log("Registered");
        InputHandler.instance?.LetterClicked(this);
    }
    public void OnEntryAccepted()
    {
        button.interactable = false;
        state = KeyboardButonState.IN_ANSWER;
    }
    public string GetAssignedLetter()
    {
        return assignedLetter;
    }
}

public enum KeyboardButonState
{
    AVAILABLE,
    IN_ANSWER
}