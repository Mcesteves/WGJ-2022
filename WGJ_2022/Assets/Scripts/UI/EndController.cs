using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    public GameObject EndCanvas;
    public Image EndPanel;
    public int points;

    [SerializeField]
    private Sprite goodEnd;
    [SerializeField]
    private Sprite badEnd;
    [SerializeField]
    private Sprite neutralEnd;
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
        if (points >= 300)
            EndPanel.sprite = goodEnd;
        else if(points >= 500 )
            EndPanel.sprite = neutralEnd;
        else
            EndPanel.sprite = badEnd;

        EndCanvas.SetActive(true);
    }


}
