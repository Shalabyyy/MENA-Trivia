using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerButton : MonoBehaviour
{
    private bool isWhiteSpace;
    private int indexInKeyboard;
    private LetterButton assignedButton;
    private AnswerBarAssigner answerBar;
    private Text letterTextUI;
    private Button button;
    private bool isOccupied = false;

    public void Init (int index , AnswerBarAssigner parent)
    {
        
        indexInKeyboard = index;
        answerBar = parent;

        //Fetch Components in Prefabs
        letterTextUI = GetComponentInChildren<Text>();
        button = GetComponent<Button>();

        //Set Refereneces
        transform.parent = answerBar.transform;
        transform.localScale = Vector3.one;  
        letterTextUI.text = "";

        if (index < 0)
        {
            InitalizeWhiteSpaceButton();
        }
        else button.onClick.AddListener(DecoupleLetterButton);
    }

    public void CoupleLetterButton(LetterButton buttonPair)
    {
        if (isOccupied) return;

        Debug.Log("Slot at Index " + indexInKeyboard + " Has Been filled with" + buttonPair.GetAssignedLetter());
        assignedButton = buttonPair;
        letterTextUI.text = assignedButton.GetAssignedLetter();
        isOccupied = true;
    }
    public void DecoupleLetterButton()
    {
        if (!isOccupied) return;

        assignedButton.OnLetterRemoved();
        assignedButton = null;
        letterTextUI.text = "";
        isOccupied = false;
        answerBar.OnLetterRemoved(indexInKeyboard);
    }
    public bool isSlotOccupied()
    {
        return isOccupied;
    }
    public string GetAttachedLetter()
    {
        return letterTextUI.text;
    }
    private void InitalizeWhiteSpaceButton()
    {
        GetComponent<Image>().enabled = false;
        button.transition = Selectable.Transition.None;
        button.interactable = false;
        transform.name = "White Space Button";
    }
}
