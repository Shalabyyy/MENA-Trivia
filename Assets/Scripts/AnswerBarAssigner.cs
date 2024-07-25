using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerBarAssigner : MonoBehaviour
{
    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private List<AnswerButton> buttons;

    private GridLayoutGroup answerbarLayout;
    private string correctAnswer;
    private string currentAnswer;
    private bool isFull = false;
    private bool isCorrect = false;
    private int index = 0;



    public void SetUpAnswerbar(string letters, bool isEnglish)
    {
        /*To Avoid Confusion and Collision with input systm, we can make the following: 
         * keyboard Grid start from the right for arabic
         * start from the left in English
         * since the first character in both langauges are indexed at 0
         * */
        answerbarLayout = GetComponent<GridLayoutGroup>();
        answerbarLayout.startCorner = isEnglish ? GridLayoutGroup.Corner.UpperLeft : GridLayoutGroup.Corner.UpperRight;

        int charCounter;
        correctAnswer = letters.Replace(" ", "");
        char[] letterArray = letters.ToCharArray();
        Debug.Log("Proccessing Answer Buttons.. for String " + letters);

        for (charCounter = 0; charCounter < letterArray.Length; charCounter++)
        {
            Debug.Log("Letter at Index " + charCounter + " = " + letterArray[charCounter]);
            AnswerButton newButton = Instantiate(answerButtonPrefab).GetComponent<AnswerButton>();

            if (char.IsWhiteSpace(letterArray[charCounter]))
            {
                newButton.Init(-charCounter, this);
                Debug.Log("New Whitespace Added");

            }
            else
            {
                newButton.Init(charCounter, this);
                buttons.Add(newButton);
                Debug.Log("New Button Added");
            }

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
