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
    public List<Situation> situations;
    [HideInInspector] public AccessoryType selectedAccessory;

    private DialogueManager _dialogueManager;
    private EndController _endController;
    private int clients;
    [SerializeField]
    private Sprite earlessHappyCat;


    private void Awake()
    {
        foreach(Situation situation in situations)
        {
            situation.isDone = false;
        }
        _dialogueManager = GetComponent<DialogueManager>();
        _endController = GetComponent<EndController>();
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
        _endController.points += activeSituation.CheckChoice(selectedAccessory);
        SelectCatSprite();
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

    IEnumerator ShowNextCustomer()
    {
        clients++;
        if (clients == 6)
        {
            yield return new WaitForSeconds(0.5f);
            _endController.ShowEnd();
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

    public void SelectCatSprite()
    {
        Result result = activeSituation.GetResult();
        if(result == Result.Happy)
        {
            catObject.GetComponent<Image>().sprite = activeCat.happySprite;
        }
        else if(result == Result.Sad)
        {
            catObject.GetComponent<Image>().sprite = activeCat.sadSprite;
        }
    }

}
