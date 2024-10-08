using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OperationManager : MonoBehaviour
{
    // Parameters

    public Button numbersButton;  
    public Button addminusButton;  
    public Button multiplyButton;  
    public Button divideButton;  
    public Button startButton;
    public Button stopButton;

    public Button[] numbersPanelButton;

    public GameObject Panel;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerInput;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;

    public Sprite[] numbersPanelSprite;
    public Sprite[] operatorsSprite;
    public Sprite Empty;

    public Image Number1;
    public Image Number2;
    public Image Operator;
    public Image Answer;

    private float timeRemaining = 360f;
    private int score = 0;
    private int maxScore = 0;
    private bool isQuizActive = false;
    private string currentOperation;
    private int correctAnswer; 

    public void Start()
    {
        Panel.SetActive(false);
        stopButton.gameObject.SetActive(false);
        enableNumbers();
        timeRemaining = 360f;
        timerText.text = "Time: " + timeRemaining.ToString("F0");
        scoreText.text = "Score: " + score;
        maxScoreText.text = "Max Score: " + maxScore;
    }

    public void StartQuiz()
    {
        startButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(true);
        disableModes();
        enableNumbers();

        isQuizActive = true;

        score = 0;
        scoreText.text = "Score: " + score;
        questionText.text = "";

        timeRemaining = 360f;
        timerText.text = "Time: " + timeRemaining.ToString("F0");

        StartCoroutine(QuizTimer());
        GenerateQuestion();
    }

    private IEnumerator QuizTimer()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            timerText.text = "Time: " + timeRemaining.ToString("F0");
        }
        EndQuiz();
    }

    private void GenerateQuestion()
    {
        int num1 = Random.Range(0, 10);
        int num2 = Random.Range(0, 10);
        correctAnswer = 0;

        switch (currentOperation)
        {
            case "addition":
                num2 = Random.Range(0, 10 - num1);
                correctAnswer = num1 + num2;

                Number1.sprite = numbersPanelSprite[num1];
                Number2.sprite = numbersPanelSprite[num2];
                break;

            case "subtraction":
                if (num2 > num1)
                {
                    int temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
                correctAnswer = num1 - num2;

                Number1.sprite = numbersPanelSprite[num1];
                Number2.sprite = numbersPanelSprite[num2];
                break;

            case "multiplication":
                num2 = Random.Range(0, (9 / num1) + 1);
                correctAnswer = num1 * num2;

                Number1.sprite = numbersPanelSprite[num1];
                Number2.sprite = numbersPanelSprite[num2];
                break;

            case "division":
                while (num1 % num2 != 0 && num2 != 0)
                {
                    num1 = Random.Range(1, 10);
                    num2 = Random.Range(1, 10);
                }
                correctAnswer = num1 / num2;

                Number1.sprite = numbersPanelSprite[num1];
                Number2.sprite = numbersPanelSprite[num2];
                break;
        }
    }

    public void CheckAnswer(int givenAnswer)
    {
        StartCoroutine(CheckAnswerCoroutine(givenAnswer));
    }

    private IEnumerator CheckAnswerCoroutine(int givenAnswer)
    {
        if (givenAnswer == correctAnswer)
        {
            score += 100;
            scoreText.text = "Score: " + score;
            questionText.text = "Correct!";
        }
        else
        {
            questionText.text = "Incorrect!";
        }
        yield return new WaitForSeconds(2f);

        Answer.sprite = Empty;

        GenerateQuestion();
    }

    public void EndQuiz()
    {
        isQuizActive = false;
        questionText.text = "Quiz Over! Your score: " + score;
        maxScore = Mathf.Max(maxScore, score);
        maxScoreText.text = "Max Score: " + maxScore;
        disableNumbers();
        enableModes();
        startButton.gameObject.SetActive(true);
        stopButton.gameObject.SetActive(false);
    }

    public void showPanel()
    {
        Panel.SetActive(true);
    }

    public void hidePanel()
    {
        Panel.SetActive(false);
    }

    public void changeSpriteAnswer(int givenAnswer)
    {
        Answer.sprite = numbersPanelSprite[givenAnswer];
    }

    private void enableNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            numbersPanelButton[i].interactable = true;
        }
    }

    private void disableNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            numbersPanelButton[i].interactable = false;
        }
    }

    public void enableModes()
    {
        numbersButton.interactable = true;
        addminusButton.interactable = true;
        multiplyButton.interactable = true;
        divideButton.interactable = true;
    }

    private void disableModes()
    {
        numbersButton.interactable = false;
        addminusButton.interactable = false;
        multiplyButton.interactable = false;
        divideButton.interactable = false;
    }

    public void changeOperation(int operation)
    {
        switch (operation)
        {
            case 0:
                if (isQuizActive)
                {
                    timeRemaining = 360f;
                    score = 0;
                    isQuizActive = false;
                }

                currentOperation = "addition";
                Operator.sprite = operatorsSprite[0];
                break;
            case 1:
                if (isQuizActive)
                {
                    timeRemaining = 360f;
                    score = 0;
                    isQuizActive = false;
                }

                currentOperation = "subtraction";
                Operator.sprite = operatorsSprite[1];
                break;
            case 2:
                if (isQuizActive)
                {
                    timeRemaining = 360f;
                    score = 0;
                    isQuizActive = false;
                }

                currentOperation = "multiplication";
                Operator.sprite = operatorsSprite[2];
                break;
            case 3:
                if (isQuizActive)
                {
                    timeRemaining = 360f;
                    score = 0;
                    isQuizActive = false;
                }

                currentOperation = "division";
                Operator.sprite = operatorsSprite[3];
                break;
        }
    }
}
