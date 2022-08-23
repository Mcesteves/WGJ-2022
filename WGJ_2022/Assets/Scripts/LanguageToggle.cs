using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageToggle : MonoBehaviour
{
    public Language toggleLanguage;
    public Toggle otherToggle;
    void Start()
    {
        if (LanguageManager.instance.activeLanguage == toggleLanguage)
            GetComponent<Toggle>().isOn = true;
    }

    public void SelectLanguage()
    {
        if (GetComponent<Toggle>().isOn)
        {
            LanguageManager.instance.SetLanguage(toggleLanguage);
            otherToggle.isOn = false;
        }
        else
        {
            LanguageManager.instance.SetLanguage(otherToggle.GetComponent<LanguageToggle>().toggleLanguage);
            otherToggle.isOn = true;
        }
            
    }
}
