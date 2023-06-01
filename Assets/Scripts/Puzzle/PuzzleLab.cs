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
    public bool isLetterScored;
    public Image feedbackImage;
    public Color correctColor;
    public int score = 0;
    public int Wrong = 0;
    public TextMeshProUGUI text;
    public TextMeshProUGUI passwordText; // Texto para exibir as letras corretas da senha

    public AudioSource audioSource;

    public AudioClip correct;
    public AudioClip wrong;

    public GameObject buttonFinalResolve;
    public GameObject buttonFinalReject;

    public bool finished;

    private List<char> letterSequence = new List<char> { 'C', 'I', 'B', 'N', 'M', 'N', 'A', 'K', 'A', 'F', 'J', 'B', 'A', 'F', 'K', 'D', 'L', 'E', 'B', 'A', 'Q', 'J', 'A', 'M', 'O', 'F', 'P', 'A', 'B' };
    private int currentLetterIndex = 0;

    private List<char> passwordLetters = new List<char>(); // Lista das letras corretas digitadas pelo jogador

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
        if (resolve == false)
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

            if (Input.GetKeyDown(KeyCode.B) && currentLetter == 'B')
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
            else if (Input.GetKeyDown(KeyCode.M) && currentLetter == 'M')
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

            List<char> validLetters = new List<char> { 'B', 'M', 'L', 'F' };
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
            resolve = true;
            PuzzleController.instance.conseguiu();
            buttonFinalResolve.SetActive(true);
        }
        else
        {
            finished = true;
            resolve = false;
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

    IEnumerator RotinaText()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }

    public void RestartPuzzle()
    {
        ButtonsNotLab.instance.panelPuzzleCam.SetActive(true);
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

    void UpdatePasswordText()
    {
        passwordText.text = string.Join(" ", passwordLetters); // Atualiza o texto da senha com as letras corretas separadas por espaço
    }
}