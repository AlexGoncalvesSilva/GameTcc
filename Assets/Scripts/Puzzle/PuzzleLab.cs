using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLab : MonoBehaviour
{
    //public Text letterText;
    public TextMeshProUGUI letterText;
    public bool resolve;
    public Image feedbackImage;
    public Color correctColor;
    public int score = 0;
    public TextMeshProUGUI text;

    public GameObject buttonFinalResolve;
    public GameObject buttonFinalReject;
    public GameObject senha;

    private List<char> letterSequence = new List<char> { 'C', 'I', 'B', 'N', 'M', 'N', 'A', 'K', 'A', 'F', 'J', 'B', 'A', 'F', 'K', 'D', 'L', 'E', 'B', 'A', 'Q', 'J', 'A', 'M', 'O', 'F', 'P', 'A', 'B' };
    private int currentLetterIndex = 0;

    public static PuzzleLab instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ShowNextLetter();
    }

    private void Update()
    {
        CheckAnswer();

        if (resolve == true)
        {
            PlayerInteraction.instance.canFinish = true;
        }
        else { PlayerInteraction.instance.canFinish = false; }
    }

    void CheckAnswer()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            char currentLetter = letterSequence[currentLetterIndex - 1];
            if (currentLetter == 'B')
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }
        }else if (Input.GetKeyDown(KeyCode.M))
        {
            char currentLetter = letterSequence[currentLetterIndex - 1];
            if (currentLetter == 'M')
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            char currentLetter = letterSequence[currentLetterIndex - 1];
            if (currentLetter == 'L')
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            char currentLetter = letterSequence[currentLetterIndex - 1];
            if (currentLetter == 'F')
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }
        }
    }

    public void ShowNextLetter()
    {
        if (currentLetterIndex < letterSequence.Count)
        {
            char letter = letterSequence[currentLetterIndex];
            letterText.text = letter.ToString();
            currentLetterIndex++;
            StartCoroutine(WaitBeforeNextLetter());

            List<char> validLetters = new List<char> { 'B', 'M', 'L', 'F' };
            SetImageColor(validLetters.Contains(letter) ? correctColor : Color.blue);
        }
        else
        {
            resolvePuzzle();
            Debug.Log("Game over. Final score: " + score);
        }
    }
    
    public void resolvePuzzle()
    {
        if (score >= 10)
        {
            resolve = true;
            text.text = "Consegui!!";
            senha.SetActive(true);
            buttonFinalResolve.SetActive(true);
            StartCoroutine("RotinaText");
        }
        else
        {
            resolve = false;
            text.text = "Droga, não consegui, vou tentar de novo.";
            buttonFinalReject.SetActive(true);
            StartCoroutine("RotinaText");
        }

    }

    IEnumerator WaitBeforeNextLetter()
    {
        yield return new WaitForSeconds(1.5f);
        ShowNextLetter();
    }

    void SetImageColor(Color color)
    {
        feedbackImage.color = color;
    }
    IEnumerator RotinaText()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }

    public void RestartPuzzle()
    {
        currentLetterIndex = 0;
        score = 0;
        ShowNextLetter();
        text.text = "";
        buttonFinalReject.SetActive(false);
    }
}
