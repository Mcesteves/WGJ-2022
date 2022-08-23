using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteSelection : MonoBehaviour
{
    public List<Sprite> sprites;
    void Update()
    {
        Language language = LanguageManager.instance.activeLanguage;
        if (language == Language.Portuguese)
            GetComponent<Image>().sprite = sprites[0];
        else
            GetComponent<Image>().sprite = sprites[1];
    }
}
