using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ComplexCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI messageText;
    public Button resetButton;
    public Button stopButton; // Кнопка "Стоп"

    private int count = 0;
    private float timer = 0f;
    private bool isRunning = true; // Флаг, указывающий, работает ли счетчик
    private Stopwatch stopwatch;

    private void Start()
    {
        if (counterText == null || messageText == null || resetButton == null || stopButton == null)
        {
            Debug.LogError("Missing UI elements!");
            enabled = false;
            return;
        }

        resetButton.onClick.AddListener(ResetCounter);
        stopButton.onClick.AddListener(StopCounter); // Подписываемся на кнопку "Стоп"
        messageText.gameObject.SetActive(false);
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    private void Update()
    {
        if (isRunning) // Проверяем, работает ли счетчик
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                count++;
                counterText.text = "Count: " + count;
                timer = 0f;
            }
        }
    }

    private void ResetCounter()
    {
        count = 0;
        counterText.text = "Count: " + count;
        ShowResetMessage();
    }

    private void ShowResetMessage()
    {
        messageText.text = "Counter was reset!";
        messageText.gameObject.SetActive(true);
        Invoke("HideResetMessage", 2f);
    }

    private void HideResetMessage()
    {
        messageText.gameObject.SetActive(false);
    }

    private void StopCounter()
    {
        isRunning = false; // Останавливаем счетчик
        stopwatch.Stop();  // Останавливаем Stopwatch
        Debug.Log("Spaghetti Code execution time: " + stopwatch.ElapsedMilliseconds + " ms");
        // Отключаем кнопки, чтобы избежать повторного нажатия после остановки
        resetButton.interactable = false;
        stopButton.interactable = false;
    }

    private void OnDestroy()
    {
        resetButton.onClick.RemoveListener(ResetCounter);
        stopButton.onClick.RemoveListener(StopCounter);
    }
}