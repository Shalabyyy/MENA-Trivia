using System;
using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;

public class GameGuess : MonoBehaviour
{
    private int maxCharacters = 25;
    private List<char> letters;

    [SerializeField] private AnswerLocalizationHandler answerLocalizer;
    [SerializeField] private GuessEntry testEntry;
    [SerializeField][Range( 1.1f , 2.5f)] private float characterIncreaseRate = 1.75f;

    //Arabic Letters
    public static List<int> arabicLetterList = new ArabicLetterLibrary().addresses;

    void Start()
    {
        letters = new List<char>();
        GenerateLetters(testEntry);

    }

    private void GenerateLetters(GuessEntry level)
    {

        GenerateLetters(level, true);
        GenerateLetters(level, false);

    }
    private void GenerateLetters(GuessEntry level , bool isEnglish)
    {
        string result = isEnglish ? level.nameEN : level.nameAR;
        AnswerPair pair = answerLocalizer.GetPair(isEnglish);
        pair.GetAnswerBar().SetUpAnswerbar(result, isEnglish);
        ReturnLetterList(result, pair.GetKeyboard() , isEnglish);
    }

    private void ReturnLetterList(string brandname, KeyboardManager assigner , bool isEnglish)
    {
        // Clear Previous Value and Create Char Array
        letters.Clear();
        brandname = brandname.ToUpper();
        char[] brandLetters = brandname.ToCharArray();

        int numberToGenerate =    (int)(brandname.Length * characterIncreaseRate);
        numberToGenerate = Math.Clamp( numberToGenerate, brandname.Length, maxCharacters);
        Debug.Log("Number of Letters to Generated " + numberToGenerate);
        //Add Characters to List
        for (int i = 0; i < numberToGenerate; i++)
        {
            if (i < brandname.Length)
            {
                letters.Add(brandLetters[i]);
            }
            else
            {
                //TODO Fetch Arabic Letter Addresses from button ArabicSupprt/GeneralArabicLetters Enum
                letters.Add(GetRandomChar(isEnglish));
            }
        }
        Debug.Log("Total Buttons Generated =" + letters.Count);
        DisplayStringInEditor(isEnglish);
        FisherYatesRandomize();
        DisplayStringInEditor(isEnglish);
        assigner.AssignButtonCharacters(ConvertCharacterListToString()  , brandname);

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

    public static char GetRandomChar(bool isEngllishChar)
    {

        if (isEngllishChar) return (char)('A' + UnityEngine.Random.Range(0, 26));
        else
        {
            int listLocation = UnityEngine.Random.Range(0, arabicLetterList.Count - 1);
            return (char)arabicLetterList[listLocation];
        }
    }
    public void ToggleLanguage()
    {
       // isEnglish = !isEnglish;
        letters.Clear();
        GenerateLetters(testEntry);
    }
}
