using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonAssigner : MonoBehaviour
{
    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private List<LetterButton> buttons;


    public void AssignButtonCharacters(string letters, string answerLetters)
    {
        letters = letters.ToUpper();
        char[] charachterArray = letters.ToCharArray();
        int charCounter;
        Debug.Log("Recieved Buttons Generated in ButtonAssigner = " + charachterArray.Length);

        for (charCounter = 0; charCounter < charachterArray.Length; charCounter++)
        {
            if (!char.IsWhiteSpace(charachterArray[charCounter]))
            {
                LetterButton newButton = Instantiate(answerButtonPrefab).GetComponent<LetterButton>();

                //For Future Optimization it would be best to know if the letter is an answer button or not to optimize wild card
                newButton.InitalizeButton(charachterArray[charCounter].ToString(), this.transform);
                if (answerLetters.Contains(newButton.GetAssignedLetter())) newButton.SetLetterIsSubstring();

                //Add New Button 
                buttons.Add(newButton);
            }
            else Debug.LogWarning("White Space Detected at Keyboard Generation");
        }
        Debug.Log("Proccessed " + charCounter + " Characters");

    }
    [ContextMenu("Trigger 50% Wild Card")]
    public void RemoveHalfTheLetters()
    {
        //Remove 50% of the fake letters, Clear Bar
        Debug.Log("Invoking 50/50 Wildcard");
        int mod = 1;
        foreach (LetterButton button in buttons)
        {
            if (!button.isSubstringOfAnswer() && button.MatchState(KeyboardButonState.AVAILABLE))
            {
                mod++;
                if (mod % 2 == 0)
                {
                    Debug.Log(mod / 2 + " Removed");
                    button.OnLetterRevealedFaulty();
                }
            }
        }
    }
    [ContextMenu("Add First 3 Characters")]
    public void AddFirstThreeLetters(string substringOfThree)
    {
        substringOfThree = substringOfThree.ToUpper();

        Debug.Log("Charachters Recieved " + substringOfThree);

        foreach (char letter in substringOfThree.ToCharArray())
        {
            //Find the button where the letter is stored.
            LetterButton result = buttons.Find( button => button.GetAssignedLetter().Equals(letter.ToString()));
            result?.FreezeButton();
        }
    }
    [ContextMenu("Re Roll Faulty Letters")]

    public void ReRollFaultyLetterButtons(bool isEnglish)
    {
        foreach(LetterButton button in buttons)
        {
            if (!button.isSubstringOfAnswer() && button.MatchState(KeyboardButonState.AVAILABLE))
            {
                button.RerollButton(GameGuess.GetRandomChar(isEnglish).ToString());
            }

        }
    }

    public void OnLanguageChanged()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i].gameObject);
        }
        buttons.Clear();
    }

}

