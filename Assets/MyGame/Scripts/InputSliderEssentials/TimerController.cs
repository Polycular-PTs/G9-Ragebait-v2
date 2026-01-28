using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SliderController sliderController;
    [SerializeField] private CountdownUi countdownUi;

    [Header("Idle Settings")]
    [Min(0f)]
    [SerializeField] private float idleTimeRequired = 3f;

    private float idleTimer;
    private int lastStep;

    private void Start()
    {
        if (!sliderController || !countdownUi)
        {
            enabled = false;
            return;
        }

        lastStep = sliderController.GetCurrentStep();
    }

    private void Update()
    {
        CheckIdle();
    }

    private void CheckIdle()
    {
        int currentStep = sliderController.GetCurrentStep();

        if (currentStep != lastStep)
        {
            ResetIdle();
            lastStep = currentStep;
            return;
        }

        idleTimer += Time.deltaTime;

        if (currentStep == 0)
        {
            return;
        }

        if (idleTimer >= idleTimeRequired && !countdownUi.IsRunning)
        {
            countdownUi.StartCountdown(OnCountdownFinished);
        }
    }

    private void ResetIdle()
    {
        idleTimer = 0f;
        countdownUi.StopCountdown();
    }

    private void OnCountdownFinished()
    {
        int step = sliderController.GetCurrentStep();

        if (step != 0 && VoteManager.Instance != null)
        {
            VoteManager.Instance.AddVote(step);
        }

        idleTimer = 0f;

        if (!string.IsNullOrEmpty("GraphTest"))
        {
            SceneManager.LoadScene("GraphTest");
        }
    }
}
