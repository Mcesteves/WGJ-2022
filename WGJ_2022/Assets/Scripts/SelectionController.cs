using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionController : MonoBehaviour
{
    public Cat activeCat;
    public Situation activeSituation;
    public GameObject catObject;
    public GameObject accessory;
    public GameObject accessoryBack;
    public TextMeshProUGUI situationDescription;
    public GameObject EndCanvas;
    public List<Situation> situations;
    [HideInInspector] public AccessoryType selectedAccessory;

    private DialogueManager _dialogueManager;
    private int clients;
    private int _points;
    [SerializeField]
    private Sprite earlessHappyCat;
    private Sprite earlessSadCat;


    private void Awake()
    {
        foreach(Situation situation in situations)
        {
            situation.isDone = false;
        }
    }
    void Start()
    {
        _dialogueManager = GetComponent<DialogueManager>();      
    }

    public void SortSituation()
    {
        int option = Random.Range(0, situations.Count);
        while (situations[option].isDone)
            option = Random.Range(0, situations.Count);
        SetActiveSituation(situations[option]);
    }

    public void SetActiveSituation(Situation situation)
    {
        activeSituation = situation;
        activeCat = activeSituation.cat;
        catObject.GetComponent<Image>().sprite = activeCat.neutralSprite;
    }

    public void PressYes()
    {
        _points += activeSituation.CheckChoice(selectedAccessory);
        _dialogueManager.StartDialog(activeSituation.GetAnswer(), false);
    }

    public void ShowSituation()
    {
        situationDescription.text = activeSituation.GetDescription();
    }

    public void Next()
    {
        StartCoroutine(ShowNextCustomer());
    }

    public void ShowEnd()
    {
        EndCanvas.SetActive(true);
    }

    IEnumerator ShowNextCustomer()
    {
        clients++;
        if (clients == 5)
        {
            yield return new WaitForSeconds(0.5f);
            ShowEnd();
            yield break;
        }  
        catObject.SetActive(false);
        accessory.SetActive(false);
        accessoryBack.SetActive(false);
        activeSituation.isDone = true;
        yield return new WaitForSeconds(2f);
        SortSituation();
        catObject.SetActive(true);
        _dialogueManager.StartDialog(activeSituation.GetIntroduction(), true);
        ShowSituation();
    }

}
