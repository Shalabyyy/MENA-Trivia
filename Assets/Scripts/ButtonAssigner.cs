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
        char[] charachterArray = letters.ToCharArray();
        int charCounter;

        for (charCounter = 0; charCounter < charachterArray.Length; charCounter++)
        {
            if (!char.IsWhiteSpace(charachterArray[charCounter]))
            {
                LetterButton newButton = Instantiate(answerButtonPrefab).GetComponent<LetterButton>();
                newButton.InitalizeButton(charachterArray[charCounter].ToString(), this.transform);
                buttons.Add(newButton);
            }
            else Debug.LogWarning("White Space Detected at Keyboard Generation");
        }
        Debug.Log("Proccessed " + charCounter + " Characters");

    }

}
