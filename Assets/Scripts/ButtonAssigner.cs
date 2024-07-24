using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonAssigner : MonoBehaviour
{
    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private List<LetterButton> buttons;

    void Start()
    {
        buttons.AddRange(GetComponentsInChildren<LetterButton>());
    }


    public void AssignButtonCharacters(string letters)
    {
        letters = letters.ToUpper();
        int charCounter;

        for (charCounter = 0; charCounter < letters.Length; charCounter++)
        {
            LetterButton newButton = Instantiate(answerButtonPrefab).GetComponent<LetterButton>();
            newButton.InitalizeButton(letters.ToCharArray()[charCounter].ToString(), this.transform);
            buttons.Add(newButton);

        }
        Debug.Log("Proccessed " + charCounter + " Characters");

    }

}
