using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLab1 : MonoBehaviour
{
    //public Text letterText;
    public TextMeshProUGUI letterText;
    public bool resolve1;
    public Image feedbackImage;
    public Color correctColor;
    public int score = 0;
    public TextMeshProUGUI text;

    public GameObject buttonFinalResolve;
    public GameObject buttonFinalReject;
    public GameObject senha;

    private List<char> letterSequence = new List<char> { 'C', 'I', 'B', 'M', 'N', 'A', 'K', 'N', 'A', 'F', 'J', 'B', 'A', 'F', 'K', 'L', 'D', 'E', 'B', 'A', 'Q', 'J', 'A', 'M', 'O', 'F', 'P', 'A', 'B' };
    private int currentLetterIndex = 0;

    public static PuzzleLab1 instance;
    
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
            
        if (resolve1 == true)
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
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            char currentLetter = letterSequence[currentLetterIndex - 1];
            if (currentLetter == 'N')
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
        }
        else if (Input.GetKeyDown(KeyCode.F))
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
            SetImageColor(letter == 'B' || letter == 'N' || letter == 'L' || letter == 'F' ? correctColor : Color.blue);
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
            resolve1 = true;
            text.text = "Consegui!!";
            senha.SetActive(true);
            buttonFinalResolve.SetActive(true);
            StartCoroutine("RotinaTextNormal");
        }
        else
        {
            resolve1 = false;
            text.text = "Droga, não consegui, vou tentar de novo.";
            buttonFinalReject.SetActive(true);
            StartCoroutine("RotinaTextNormal");
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
    public void RestartPuzzle()
    {
        currentLetterIndex = 0;
        score = 0;
        ShowNextLetter();
        text.text = "";
        buttonFinalReject.SetActive(false);
    }

    IEnumerator RotinaTextNormal()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }
}
