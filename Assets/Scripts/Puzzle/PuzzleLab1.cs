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
    public bool isLetterScored;
    public Image feedbackImage;
    public Color correctColor;
    public int score = 0;
    public int Wrong = 0;
    public TextMeshProUGUI text;

    public AudioSource audioSource;
    public TextMeshProUGUI passwordText;

    public AudioClip correct;
    public AudioClip wrong;

    public bool finished;

    public GameObject buttonFinalResolve;
    public GameObject buttonFinalReject;

    private List<char> letterSequence = new List<char> { 'C', 'I', 'A', 'M', 'N', 'B', 'K', 'N', 'B', 'F', 'J', 'B', 'T', 'F', 'K', 'L', 'D', 'E', 'B', 'L', 'Q', 'J', 'A', 'M', 'O', 'F', 'P', 'B', 'A' };
    private int currentLetterIndex = 0;

    private List<char> passwordLetters = new List<char>(); // Lista das letras corretas digitadas pelo jogador

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
        if(resolve1 == false)
        { 
            PlayerInteraction.instance.canFinish = false; 
        }

        if (Wrong >= 3) 
        {
            resolvePuzzle();
        }
    }

    void CheckAnswer()
    {
        if (Input.anyKeyDown && finished == false)
        {
            char currentLetter = letterSequence[currentLetterIndex - 1];
            bool keyPressed = false;

            if (Input.GetKeyDown(KeyCode.A) && currentLetter == 'A')
            {
                if (!isLetterScored)
                {
                    score += 1;
                    isLetterScored = true;
                    keyPressed = true;
                    passwordLetters.Add(currentLetter);
                    UpdatePasswordText();
                    audioSource.PlayOneShot(correct);
                }
            }
            else if (Input.GetKeyDown(KeyCode.N) && currentLetter == 'N')
            {
                if (!isLetterScored)
                {
                    score += 1;
                    isLetterScored = true;
                    keyPressed = true;
                    passwordLetters.Add(currentLetter);
                    UpdatePasswordText();
                    audioSource.PlayOneShot(correct);
                }
            }
            else if (Input.GetKeyDown(KeyCode.L) && currentLetter == 'L')
            {
                if (!isLetterScored)
                {
                    score += 1;
                    isLetterScored = true;
                    keyPressed = true;
                    passwordLetters.Add(currentLetter);
                    UpdatePasswordText();
                    audioSource.PlayOneShot(correct);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F) && currentLetter == 'F')
            {
                if (!isLetterScored)
                {
                    score += 1;
                    isLetterScored = true;
                    keyPressed = true;
                    passwordLetters.Add(currentLetter);
                    UpdatePasswordText();
                    audioSource.PlayOneShot(correct);
                }
            }

            if (!keyPressed)
            {
                score -= 1;
                Wrong += 1;
                audioSource.PlayOneShot(wrong);
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

            List<char> validLetters = new List<char> { 'A', 'N', 'L', 'F' };
            SetImageColor(validLetters.Contains(letter) ? correctColor : Color.blue);
        }
        else
        {
            resolvePuzzle();
            Debug.Log("Game over. Final score: " + score);
        }

        isLetterScored = false;
    }
    
    public void resolvePuzzle()
    {
        if (score >= 9)
        {
            finished = true;
            resolve1 = true;
            PuzzleController.instance.conseguiu();
            buttonFinalResolve.SetActive(true);
        }
        else
        {
            finished = true;
            resolve1 = false;
            StopAllCoroutines();
            PuzzleController.instance.NConseguiu();
            buttonFinalReject.SetActive(true);
            ButtonsNotLab.instance.panelPuzzleCam.SetActive(false);
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
        ButtonsNotLab.instance.panelPuzzleFiles.SetActive(true);
        finished = false;
        currentLetterIndex = 0;
        score = 0;
        Wrong = 0;
        ShowNextLetter();
        text.text = "";
        passwordLetters.Clear(); // Limpa a lista de letras da senha
        UpdatePasswordText(); // Atualiza o texto da senha
        buttonFinalReject.SetActive(false);

    }

    IEnumerator RotinaTextNormal()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }

    void UpdatePasswordText()
    {
        passwordText.text = string.Join(" ", passwordLetters); // Atualiza o texto da senha com as letras corretas separadas por espaço
    }
}
