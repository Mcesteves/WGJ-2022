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
    public Cat cat;
    public AccessoryType rightOption;
    public AccessoryType wrongOption;
    public List<Dialogue> rightOptionAnswers;
    public List<Dialogue> wrongOptionAnswers;
    public List<Dialogue> neutralOptionAnswers;
    public List<Dialogue> introductions;
    public List<string> descriptions;
    public bool isDone;

    private Dialogue _answer;
    private void Start()
    {

    }

    public int CheckChoice(AccessoryType choosenType)
    {
        if(choosenType == rightOption)
        {
            _answer = ChooseDialogue(rightOptionAnswers);
            return 100;
        }
        else if(choosenType == wrongOption)
        {
            _answer = ChooseDialogue(wrongOptionAnswers);
            return 0;
        }
        else
        {
            _answer = ChooseDialogue(neutralOptionAnswers);
            return 50;
        }
    }

    public Dialogue GetIntroduction()
    {
        return ChooseDialogue(introductions);
    }

    public Dialogue GetAnswer()
    {
        return _answer;
    }

    public string GetDescription()
    {
        return ChooseDescription(descriptions);
    }



    public Dialogue ChooseDialogue(List<Dialogue> dialogues)
    {
        switch (LanguageManager.instance.activeLanguage)
        {
            case Language.Portuguese:
                return dialogues[0];
            default:
                return dialogues[1];
        }
    }

    public string ChooseDescription(List<string> strings)
    {
        switch (LanguageManager.instance.activeLanguage)
        {
            case Language.Portuguese:
                return strings[0];
            default:
                return strings[1];
        }
    }
}
