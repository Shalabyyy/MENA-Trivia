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
    public void OnLetterRemoved()
    {
        button.interactable = true;
        state = KeyboardButonState.AVAILABLE;
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