using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button clickButton;
    public GameObject dialogueCanvas;
    public GameObject clickCanvas;
    public GameObject descriptionText;

    private Queue<string> _sentences;

    private bool _isIntroduction;
    private bool _isAnswer;
    private SelectionController _selectionController;

    void Start()
    {
        _sentences = new Queue<string>();
        _selectionController = GetComponent<SelectionController>();
    }

    public void StartDialog(Dialogue dialogue, bool isIntroduction)
    {
        dialogueCanvas.SetActive(true);
        clickCanvas.SetActive(true);
        _isIntroduction = isIntroduction;
        _isAnswer = !isIntroduction;
        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        clickButton.interactable = false;
        if (_sentences.Count == 0)
        {
            dialogueCanvas.SetActive(false);
            clickCanvas.SetActive(false);
            if (_isIntroduction)
            {
                descriptionText.SetActive(true);
                _isIntroduction = false;
            }
            if (_isAnswer)
            {
                _isAnswer = false;
                _selectionController.Next();
            }
            return;
        }

        if (_sentences.Count != 0)
        {
            StopAllCoroutines();
            string sentence = _sentences.Dequeue();
            StartCoroutine(TextWritingEffect(sentence));
        }

        return;
    }


    IEnumerator TextWritingEffect(string sentence)
    {
        float lettersRate = 0.01f;
        for (int i = 0; i <= sentence.Length; i++)
        {
            text.text = sentence.Substring(0, i);
            yield return new WaitForSeconds(lettersRate);
        }
        clickButton.interactable = true;
    }
}
