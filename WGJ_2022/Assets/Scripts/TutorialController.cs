using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public Situation tutorialSituation;
    private SelectionController _selectionController;
    private DialogueManager _dialogueManager;

    private void Awake()
    {
        _selectionController = GetComponent<SelectionController>();
        _dialogueManager = GetComponent<DialogueManager>();
    }
    void Start()
    {
        StartCoroutine(StartTutorialCoroutine());
    }

    public void StartTutorial()
    {
        _selectionController.catObject.SetActive(true);
        _selectionController.SetActiveSituation(tutorialSituation);
        _dialogueManager.StartDialog(_selectionController.activeSituation.GetIntroduction(), true);
        _selectionController.ShowSituation();
    }


    IEnumerator StartTutorialCoroutine()
    {
        yield return new WaitForSeconds(1f);
        StartTutorial();
    }
}
