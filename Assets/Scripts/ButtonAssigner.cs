using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonAssigner : MonoBehaviour
{
    [SerializeField] private List<LetterButton> buttons;

    void Start()
    {
        buttons.AddRange(GetComponentsInChildren<LetterButton>());
    }


    public void AssignButtonCharacters(string letters)
    {
        letters = letters.ToUpper();
        int charCounter;
        int j = 0;

        Debug.Log("Proccessing Buttons.. for String " + letters);
        Debug.Log("1- Character Initalizing -> " + letters.ToCharArray()[0].ToString());
        buttons[j].InitalizeButton(letters.ToCharArray()[0].ToString(), this.transform);

        for (charCounter = 1; charCounter < letters.Length; charCounter++)
        {


            LetterButton newButton = Instantiate(buttons[0].gameObject).GetComponent<LetterButton>();
            //Debug.Log("2- Character Initalizing -> " + letters.ToCharArray()[charCounter].ToString());
            newButton.InitalizeButton(letters.ToCharArray()[charCounter].ToString(), this.transform);
            buttons.Add(newButton);



        }
        Debug.Log("Proccessed " + charCounter + " Characters");

    }

}
