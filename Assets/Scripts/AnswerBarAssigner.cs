using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerBarAssigner : MonoBehaviour
{
    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private List<AnswerButton> buttons;

    private string correctAnswer;
    private bool isFull = false;
    private bool isCorrect = false;
    private int index = 0;

    public void SetUpAnswerbar(string letters)
    {
        int charCounter;
        correctAnswer = letters;
        Debug.Log("Proccessing Answer Buttons.. for String " + letters);
        for (charCounter = 0; charCounter < letters.Length; charCounter++)
        {
            AnswerButton newButton = Instantiate(answerButtonPrefab).GetComponent<AnswerButton>();
            newButton.Init(charCounter, this);
            buttons.Add(newButton);
            Debug.Log("New Button Added");
        }
        Debug.Log("Proccessed " + charCounter + " Characters");
    }

    public void AddLetter(LetterButton letterButton)
    {
        if (isAnswerFull())
        {
            Debug.Log("Bar is Full, Not Accepting answers");
            return;
        }
        Debug.Log("Adding Letter at Point" + index);
        buttons[index].CoupleLetterButton(letterButton);
        GetNextIndex();


    }
    public void OnLetterRemoved(int indexAt)
    {
        GetNextIndex();
    }
    private void GetNextIndex()
    {

        for (int i = 0; index < buttons.Count; i++)
        {
            if (!buttons[i].isSlotOccupied())
            {
                index = i;
                return;
            }
                
        }
         

    }
    public bool isAnswerFull()
    {
        return isFull;
    }
}
