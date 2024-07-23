using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerBarAssigner : MonoBehaviour
{
    [SerializeField ]private List<Button> buttons;

    private string correctAnswer;
    private string currentAnswer;
    private bool isFull = false;
    private int index = 0;
    void Start()
    {
        buttons.AddRange(GetComponentsInChildren<Button>());
    }
    public void SetUpAnswerbar(string letters)
    {
        int charCounter;
        int j = 0;
        correctAnswer = letters;
        Debug.Log("Proccessing Answer Buttons.. for String " + letters);
        for (charCounter = 0; charCounter < letters.Length; charCounter++)
        {
            if (j == buttons.Count - 1)
            {
                Button newButton = Instantiate(buttons[0]);
                newButton.transform.parent = this.transform;
                newButton.transform.localScale = Vector3.one;
                newButton.GetComponentInChildren<Text>().text = "";
                buttons.Add(newButton);
                j++;
            }
            else
            {
                buttons[j].GetComponentInChildren<Text>().text = "";
                j++;
            }

        }
        Debug.Log("Proccessed " + charCounter + " Characters");
    }
    
    public void AddLetter(string newLetter)
    {
        if(isAnswerFull())
        {
            Debug.Log("Bar is Full, Not Accepting answers");
            return;
        }
        currentAnswer += newLetter;
        buttons[index].GetComponentInChildren<Text>().text = newLetter;
        index++;

        if (currentAnswer.Length == correctAnswer.Length) isFull = true;
        if (currentAnswer.Equals(correctAnswer)) Debug.Log("Player Won!");

    }
    public bool isAnswerFull()
    {
        return isFull;
    }
}