using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Situation tutorialSituation;

    private SelectionController _selectionController;
    private DialogueManager _dialogueManager;
    private int _points;

    private void Awake()
    {
        _selectionController = GetComponent<SelectionController>();
        _dialogueManager = GetComponent<DialogueManager>();
    }
    void Start()
    {
        StartCoroutine(StartTutorialCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTutorial()
    {
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
