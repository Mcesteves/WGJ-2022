using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionController : MonoBehaviour
{
    // Start is called before the first frame update

    public Cat activeCat;
    public Situation activeSituation;
    public GameObject catObject;
    public TextMeshProUGUI situationDescription;

    public List<Situation> situations;

    private DialogueManager _dialogueManager;
    [HideInInspector]public AccessoryType selectedAccessory;

    void Start()
    {
        _dialogueManager = GetComponent<DialogueManager>();      
    }

    public void SortSituation()
    {
        int option = Random.Range(0, situations.Count);
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
        int points = activeSituation.CheckChoice(selectedAccessory);
        _dialogueManager.StartDialog(activeSituation.GetAnswer(), false);
        //Next();
    }

    public void PressNo()
    {
        return;
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
        catObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        SortSituation();
        catObject.SetActive(true);
        _dialogueManager.StartDialog(activeSituation.GetIntroduction(), true);
    }

}
