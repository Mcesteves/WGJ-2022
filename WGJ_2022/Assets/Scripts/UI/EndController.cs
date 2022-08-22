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
    private string amazingEndText;
    [SerializeField]
    private string goodEndText;
    [SerializeField]
    private string neutralEndText;
    [SerializeField]
    private string badEndText;

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
            endText.text = amazingEndText;
        }           
        else if(points >= 300)
        {
            endPanel.sprite = neutralEnd;
            endText.text = goodEndText;
        }
        else if (points >= 50)
        {
            endPanel.sprite = neutralEnd;
            endText.text = neutralEndText;
        }
        else
        {
            endPanel.sprite = badEnd;
            endText.text = badEndText;
        }
        endCanvas.SetActive(true);
    }


}
