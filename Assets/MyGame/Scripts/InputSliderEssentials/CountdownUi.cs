using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class CountdownUi : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text countdownText;

    [Header("Countdown Settings")]
    [SerializeField] private int countdownSeconds = 5;
    [SerializeField] private float tickIntervalSeconds = 1f;

    private Coroutine routine;

    public bool IsRunning => routine != null;

    private void Awake()
    {
        if (!countdownText)
        {
            enabled = false;
            return;
        }

        countdownText.gameObject.SetActive(false);
    }

    public void StartCountdown(Action onFinished)
    {
        StopCountdown();
        routine = StartCoroutine(CountdownRoutine(onFinished));
    }

    public void StopCountdown()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        routine = null;

        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
        }
    }

    private IEnumerator CountdownRoutine(Action onFinished)
    {
        countdownText.gameObject.SetActive(true);

        for (int i = countdownSeconds; i >= 0; i--)
        {
            countdownText.text = $"saving answers in 00:{i:00}";
            yield return new WaitForSeconds(tickIntervalSeconds);
        }

        StopCountdown();
        onFinished?.Invoke();
    }
}
