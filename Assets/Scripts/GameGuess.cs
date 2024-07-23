using System;
using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;

public class GameGuess : MonoBehaviour
{
    private int maxCharacters = 20;
    private List<char> letters;

    [SerializeField] private ButtonAssigner assigner;
    [SerializeField] private AnswerBarAssigner answerBar;
    [SerializeField] private GuessEntry testEntry;
    [SerializeField] private bool isEnglish;

    void Start()
    {
        letters = new List<char>();

        Debug.Log("Genreating for Arabic Word: " + ArabicFixer.Fix(testEntry.nameAR));
        //GenerateLetters(testEntry);
        //DisplayStringInEditor();
        isEnglish = true;
        Debug.Log("Genreating for English Word: " + testEntry.nameEN);
        GenerateLetters(testEntry);


    }

    private void GenerateLetters(GuessEntry level)
    {
        //TODO Handle White Space
        if (isEnglish)
        {
            answerBar.SetUpAnswerbar(level.nameEN.ToUpper());
            ReturnEnglishList(level.nameEN.ToUpper());       
        }

        else
        {
            answerBar.SetUpAnswerbar(level.nameAR);
            ReturnArabicList(level.nameAR);
        }
    }

    private void ReturnEnglishList(string brandname)
    {
        //Clear Previous Value and Create Char Array
        letters.Clear();
        brandname.ToUpper();
        char[] brandLetters = brandname.ToCharArray();

        //Add Characters to List
        for (int i = 0; i < maxCharacters; i++)
        {
            if (i < brandname.Length)
            {
                letters.Add(brandLetters[i]);
            }
            else
            {
                letters.Add((char)('A' + UnityEngine.Random.Range(0, 26)));
            }
        }
        DisplayStringInEditor(true);
        FisherYatesRandomize();
        DisplayStringInEditor(true);
        assigner.AssignButtonCharacters(ConvertCharacterListToString());
    }
    private void ReturnArabicList(string brandname)
    {
        //Clear Previous Value and Create Char Array
        letters.Clear();
        System.Random random = new System.Random();
        char[] brandLetters = brandname.ToCharArray();

        //Add Characters to List
        for (int i = 0; i < maxCharacters; i++)
        {
            if (i < brandname.Length)
            {
                letters.Add(brandLetters[i]);
            }
            else
            {
                letters.Add((char)random.Next(0x0621, 0x0652 + 1));
            }
        }
        DisplayStringInEditor(false);
        FisherYatesRandomize();
        DisplayStringInEditor(false);
    }

    private void FisherYatesRandomize()
    {
        int j; char temp;
        for (int i = letters.Count - 1; i > 0; i--)
        {
            j = UnityEngine.Random.Range(0, i + 1);
            temp = letters[i];
            letters[i] = letters[j];
            letters[j] = temp;
        }


    }
    private void DisplayStringInEditor(bool isEnglish)
    {
        string result = "";
        foreach (char letter in letters)
            result += letter;

        if (isEnglish) Debug.Log(result);
        else Debug.Log(ArabicFixer.Fix(result));
    }
    private string ConvertCharacterListToString()
    {
        string result = "";
        foreach (char letter in letters)
            result += letter;
        return result;
    }
}