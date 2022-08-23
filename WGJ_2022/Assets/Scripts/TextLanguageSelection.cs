using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLanguageSelection : MonoBehaviour
{
    public List<string> texts;
    void Update()
    {
        Language language = LanguageManager.instance.activeLanguage;
        if (language == Language.Portuguese)
            GetComponent<TextMeshProUGUI>().text = texts[0];
        else
            GetComponent<TextMeshProUGUI>().text = texts[1];
    }
}
