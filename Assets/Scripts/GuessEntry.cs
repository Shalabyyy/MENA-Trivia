using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Guess Entry")]
public class GuessEntry : ScriptableObject
{
    public Image logo; 
    public string nameEN;
    public string nameAR;
    public string hintEN;
    public string hintAR;
    public bool isCompleted;
}
