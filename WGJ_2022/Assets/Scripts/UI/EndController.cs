using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndController : MonoBehaviour
{
    public GameObject endCanvas;
    public Image endPanel;
    public TextMeshProUGUI endText;
    public int points;

    [SerializeField]
    private Sprite amazingEnd;
    [SerializeField]
    private Sprite badEnd;
    [SerializeField]
    private Sprite neutralEnd;
    [SerializeField]
    private List<string> amazingEndTexts;
    [SerializeField]
    private List<string> goodEndTexts;
    [SerializeField]
    private List<string> neutralEndTexts;
    [SerializeField]
    private List<string> badEndTexts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEnd()
    {
        if (points >= 500)
        {
            endPanel.sprite = amazingEnd;
            endText.text = ChooseText(amazingEndTexts);
        }           
        else if(points >= 300)
        {
            endPanel.sprite = neutralEnd;
            endText.text = ChooseText(goodEndTexts);
        }
        else if (points >= 50)
        {
            endPanel.sprite = neutralEnd;
            endText.text = ChooseText(neutralEndTexts);
        }
        else
        {
            endPanel.sprite = badEnd;
            endText.text = ChooseText(badEndTexts);
        }
        endCanvas.SetActive(true);
    }

    private string ChooseText(List<string> texts)
    {
        switch (LanguageManager.instance.activeLanguage)
        {
            case Language.Portuguese:
                return texts[0];
            default:
                return texts[1];
        }
    }

}
