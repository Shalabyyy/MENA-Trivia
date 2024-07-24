using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerBarAssigner : MonoBehaviour
{
    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private List<AnswerButton> buttons;

    private string correctAnswer;
    private string currentAnswer;
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
        if (isAnswerFull() || isAnswerCorrect())
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
        //Reconstruct answer from ittereartion

        currentAnswer = "";
        for (int i = 0; i < buttons.Count; i++)
        {
            if (!buttons[i].isSlotOccupied())
            {
                index = i;
                isFull = false;
                Debug.Log("Current Answer = " + currentAnswer);
                return;
            }
            else
            {
                currentAnswer += buttons[i].GetAttachedLetter();
                
            }

        }

        //If this part is reached it means that the all spaces are occupied

        isFull = true;
        CheckWinningCondition();


    }
    public void CheckWinningCondition()
    {
        isCorrect = currentAnswer.Equals(correctAnswer);
        if (isCorrect)
        {
            Debug.Log("Player Won");
        }
    }
    public bool isAnswerFull()
    {
        return isFull;
    }
    public bool isAnswerCorrect()
    {
        return isCorrect;
    }

}
