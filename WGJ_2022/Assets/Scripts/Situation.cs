using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum SituationType
{
    Christmas,
    MovieTheatre,
    MusicFestival,
    Funeral,
    VintageGala,
    Tree
}

[CreateAssetMenu(fileName = "Situation", menuName = "Situation", order = 0)]
public class Situation : ScriptableObject
{
    public SituationType type;
    public AccessoryType rightOption;
    public AccessoryType wrongOption;
    public List<string> rightOptionAnswer;
    public List<string> wrongOptionAnswer;
    public List<string> neutralOptionAnswer;

    private string _answer;
    private void Start()
    {

    }

    public int CheckChoice(AccessoryType choosenType)
    {
        if(choosenType == rightOption)
        {
            _answer = BuildText(rightOptionAnswer);
            return 100;
        }
        else if(choosenType == wrongOption)
        {
            _answer = BuildText(wrongOptionAnswer);
            return 0;
        }
        else
        {
            _answer = BuildText(neutralOptionAnswer);
            return 50;
        }
    }

    public string GetAnswer()
    {
        return _answer;
    }

    private string BuildText(IEnumerable optionList)
    {
        string answer = "";

        foreach(var text in optionList)
        {
            answer += text + "\n";
        }

        return answer;
    }
}
